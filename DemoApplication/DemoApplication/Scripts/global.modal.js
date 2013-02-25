(function ($) {

    var modal = function () {
        var self = this;
        self.instance = null;
        self.callback = $.noop;

        self.initialize();
    };

    modal.prototype = {
        initialize: function () {
            var self = this;
            self.instance = $('#siteModal');
            self.instance.modal({ show: false });
        },

        content: function (html) {
            var self = this;
            self.instance.find('div.modal-body').html(html);
        },

        btnText: function (text) {
            var self = this;
            self.instance.find('div.modal-footer a[data-action]').text(text).show();
        },

        hideBtn: function () {
            var self = this;
            self.instance.find('div.modal-footer a[data-action]').hide();
            self.callback = $.noop;
        },

        show: function () {
            var self = this;
            self.instance.modal('show');
        },

        hide: function () {
            var self = this;
            self.instance.modal('hide');
        },

        setCallback: function (fn) {
            var self = this;
            self.callback = fn;
        }
    };

    $(function () {
        var m = new modal();
        window.modal = m;

        m.instance.on('click', 'div.modal-footer a[data-action]', function () {
            m.callback();
        });
    });

})(jQuery);
