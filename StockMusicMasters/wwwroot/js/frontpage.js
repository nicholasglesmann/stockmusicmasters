$(document).ready(function () {
    // Transition effect for navbar 
    $('#small-logo').addClass('d-none');
    $('#hack').addClass('d-none');
    $('#mobile-navbar-fix').addClass('d-inline-block');
    $('.navbar').removeClass('bg-dark');
    $('.navbar').removeClass('box-shadow');

    $(window).scroll(function () {
        // checks if window is scrolled more than 700px, adds/removes solid class
        if ($(this).scrollTop() > document.documentElement.clientHeight * .9) {
            $('#navbar-toggler').addClass('slide-up');
            setTimeout(() => {
                $('#navbar-toggler').removeClass('slide-up');
                $('#main-navbar').addClass('slide-down');
                $('#small-logo').removeClass('d-none');
                $('#mobile-navbar-fix').removeClass('d-inline-block');
                $('.navbar').addClass('bg-dark');
                $('.navbar').addClass('box-shadow');
            }, 100);

        } else {
            $('#main-navbar').removeClass('slide-down');
            $('#small-logo').addClass('d-none');
            $('#mobile-navbar-fix').addClass('d-inline-block');
            $('.navbar').removeClass('bg-dark');
            $('.navbar').removeClass('box-shadow');
        }
    });
});
