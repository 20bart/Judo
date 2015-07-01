//$(document).ready(function() {
//    $('#home > .navbar').addClass('navbar-transparent');
//});
(function () {
    $(window).scroll(function () {
        var top = $(document).scrollTop();
        
        if (top > 100)
            $('#home > .navbar').removeClass('navbar-transparent');
        else
            $('#home > .navbar').addClass('navbar-transparent');
    });
})();
