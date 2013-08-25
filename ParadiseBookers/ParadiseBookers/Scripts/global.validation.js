(function ($) {

    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest(".control-group").addClass("error");
            $(element).closest(".control-group").removeClass("success");
        },
        unhighlight: function (element) {
            $(element).closest(".control-group").removeClass("error");
            $(element).closest(".control-group").addClass("success");
        }
    });

})(jQuery);