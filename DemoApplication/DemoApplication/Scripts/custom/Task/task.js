function Task(data) {
    var self = this;
    self.Id = ko.observable(data.Id);
    self.Created = ko.observable(data.Created);
    self.RowVersion = ko.observable(data.RowVersion);
    self.Updated = ko.observable(data.Updated);

    self.Name = ko.observable(data.Name);
}

var TaskViewModel = function (tasks) {
    var self = this;

    self.tasks = ko.observableArray(tasks);
    self.selectedItem = ko.observable();
    self.task = null;

    self.errors = ko.observableArray([{ type: 'success', message: 'This is a test message' }]);

    self.addTask = function () {
        var current = self.selectedItem();
        if (current == null) {
            var newItem = new Task({});
            self.tasks.unshift(newItem);
            self.selectedItem(newItem);
        }
    };

    self.editTask = function (task) {
        self.selectedItem(task);
    };

    self.confirmDeleteTask = function (task) {
        self.task = task;
        modal.content('Are you sure to delete the "' + task.Name() + '" task?');
        modal.btnText('Delete Task');
        modal.setCallback(self.removeTask);
        modal.show();
    };

    self.removeTask = function () {
        var model = ko.toJS(self.task);

        $.ajax({
            url: '/api/task/' + model.Id,
            type: 'DELETE',
            success: function (data) {
                self.tasks.remove(self.task);
                modal.hide();
                noty({ text: 'Task removed successfully!', type: 'success' });
            },
            error: function (a, b, c) {
                var errorJSON = JSON.parse(a.responseText);

                var html = '';
                $.each(errorJSON.ModelState, function () {
                    html += '<p>' + this[0] + '</p>';
                });

                modal.content(html);
                modal.hideBtn();
                modal.show();
            }
        });
    };

    self.saveTask = function (task) {
        var viewModel = self.selectedItem(),
            model = ko.toJS(viewModel),
            verb = model.Id ? 'PUT' : 'POST';

        $.ajax({
            url: '/api/task',
            type: verb,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model),
            success: function (data) {
                self.selectedItem().Id(data.Id);
                self.selectedItem().RowVersion(data.RowVersion);
                self.selectedItem(null);
                noty({ text: 'Task saved successfully!', type: 'success' });
            },
            error: function (a, b, c) {
                var errorJSON = JSON.parse(a.responseText);

                var html = '';
                $.each(errorJSON.ModelState, function () {
                    html += '<p>' + this[0] + '</p>';
                });

                modal.content(html);
                modal.hideBtn();
                modal.show();
            }
        });
    };

    self.cancel = function (task) {
        if (task.Id()) {
            self.selectedItem(null);
        } else {
            self.tasks.remove(task);
            self.selectedItem(null);
        }
    };

    self.templateToUse = function (item) {
        return self.selectedItem() === item ? 'editTmpl' : 'itemTmpl';
    };
};

$(function () {
    $.ajax({
        url: '/api/task',
        type: 'GET',
        success: function (data) {
            var initData = [];
            $.each(data, function () {
                var dpt = new Task(this);

                initData.push(dpt);
            });
            ko.applyBindings(new TaskViewModel(initData), document.getElementById('viewArea'));
        }
    });
});