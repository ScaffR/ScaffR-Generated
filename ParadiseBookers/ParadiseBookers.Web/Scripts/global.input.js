$(function () {
    $('[data-mask]').each(function (idx, value) {
        var mask = $(this).attr('data-mask');
        if (mask) {
            $(this).mask(mask);
        }
    });
});
