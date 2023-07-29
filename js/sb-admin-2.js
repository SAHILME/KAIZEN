(function ($) {
    "use strict"; // Start of use strict

    // Toggle the side navigation
    $("#sidebarToggle, #sidebarToggleTop").on('click', function (e) {
        event.preventDefault();
        $("body").toggleClass("sidebar-toggled");
        console.log("Toggle the side navigation");
        event.preventDefault();
        $(".sidebar").toggleClass("toggled");
        console.log("Toggle the side navigation2");
        if ($(".sidebar").hasClass("toggled")) {
            $('.sidebar .collapse').collapse('hide');
            console.log("Toggle the side navigation3");
            
        };
    });

    // Close any open menu accordions when window is resized below 768px
    $(window).resize(function () {
        if ($(window).width() < 768) {
            $('.sidebar .collapse').collapse('hide');
            console.log("Close any open menu accordions when window is resized below 768px");
        };

        // Toggle the side navigation when window is resized below 480px
        if ($(window).width() < 480 && !$(".sidebar").hasClass("toggled")) {
            $("body").addClass("sidebar-toggled");
            console.log("Toggle the side navigation when window is resized below 480px");
            $(".sidebar").addClass("toggled");
            console.log("Toggle the side navigation when window is resized below 480px2");
            $('.sidebar .collapse').collapse('hide');
            console.log("Toggle the side navigation when window is resized below 480px3");
        };
    });

    // Prevent the content wrapper from scrolling when the fixed side navigation hovered over
    $('body.fixed-nav .sidebar').on('mousewheel DOMMouseScroll wheel', function (e) {
        if ($(window).width() > 768) {
            var e0 = e.originalEvent,
              delta = e0.wheelDelta || -e0.detail;
            this.scrollTop += (delta < 0 ? 1 : -1) * 30;
            console.log("Prevent the content wrapper from scrolling when the fixed side navigation hovered over");
            e.preventDefault();
        }
    });

    // Scroll to top button appear
    $(document).on('scroll', function () {
        var scrollDistance = $(this).scrollTop();
        if (scrollDistance > 100) {
            $('.scroll-to-top').fadeIn();
            console.log("Scroll to top button appear1");
        } else {
            $('.scroll-to-top').fadeOut();
            console.log("Scroll to top button appear2");
        }
    });

    // Smooth scrolling using jQuery easing
    $(document).on('click', 'a.scroll-to-top', function (e) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top)
        }, 1000, 'easeInOutExpo');
        console.log("Smooth scrolling using jQuery easing");
        e.preventDefault();
    });

})(jQuery); // End of use strict