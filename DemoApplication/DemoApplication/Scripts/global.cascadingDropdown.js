(function ($) {

    $('[data-cascading-parent]').each(function(idx, value) {

        var parentId = $(this).data('cascading-parent');
        var $parent = $('#' + parentId);

        var method = $(this).data('method');
        var message = $(this).data('message');

        var setEmpty = function() {
            $(value).empty();
            $(value).append('<option value="">' + message + '</option>');
            $(value).attr('disabled', 'disabled');
            $(value).trigger('reloaded');
        };

        if(!$parent.val()) {
            setEmpty();
        } 

        $parent.bind('change', function () {

            if (!$parent.val()) {
                setEmpty();
            }else {
                $.ajax({
                    url: '/dropdown/getdropdownfor',
                    data: {
                        method: method,
                        parameter: $parent.val()
                    },
                    success: function (data) {
                        $(value).empty();
                        var html = '<option>' + message + '</option>';
                        $(value).append(html);
                        $(value).removeAttr('disabled');
                        for (var i = 0; i < data.length; i++) {
                            if (data[i].Value) {
                                html = '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                                $(value).append(html);
                            }
                        }
                        $(value).trigger('reloaded');
                    }
                });
            }
        });

        $parent.bind('reloaded', function() {
            setEmpty();
        });

    });

})(jQuery);