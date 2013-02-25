(function ($) {

    $(function () {

        $('#myTab a').click(function (e) {
            e.preventDefault();
            $(this).tab('show');
        });

        $('.carousel').carousel({
            interval: 10000000
        });
    });

})(jQuery);