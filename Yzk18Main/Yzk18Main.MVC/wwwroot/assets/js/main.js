/*
Template Name: Raza
	Author: ithemeslab
    Author URI: https://themeforest.net/user/RegalTheme
    
    Table of content
    1. preloader
    2. header sticky
    3. tesimonial slider
    4. tesimonial box slider
    5. blog slider
    6. service image carousel
    7. sticky sidebar
    8. off canvas
    9. venobox lightbox
    10. back to top
    11. wow js active
    12. nav scroll
    13. map activation
*/

(function ($) {
    "use strict";
    
    var windows = $(window);

    /*1. preloader*/
    windows.on('load', function () {
        $('.preloader').fadeOut('slow', function () {
            $(this).remove();
        })
    });
    
    /*2. header sticky */
    var stickyHeader = $(".sticky-header");
    windows.on('scroll', function () {
        var winPosition = windows.scrollTop();
        if (winPosition > 0) {
            stickyHeader.addClass("fixed-top");
        } else {
            stickyHeader.removeClass("fixed-top");
        }
    });

    /*3. tesimonial slider */
    $(".testimonial-slider").owlCarousel({
        autoplayHoverPause: true,
        loop: true,
        smartSpeed: 500,
        autoplay: false,
        animateIn: 'fadeInUp',
        center: true,
        dots: false,
        navigation: false,
        items: 1,
    });

    /*4. tesimonial box slider */
    $(".testimonial-box-slider").owlCarousel({
        autoplayHoverPause: true,
        loop: true,
        smartSpeed: 500,
        autoplay: false,
        dots: false,
        nav: false,
        items: 3,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1
            },
            480: {
                items: 1
            },

            768: {
                items: 2
            },

            800: {
                items: 1
            },

            1024: {
                items: 2
            },

            1200: {
                items: 3
            }
        },
    });

    /*5. blog slider */
    $(".blog-slider").owlCarousel({
        autoplayHoverPause: true,
        loop: false,
        smartSpeed: 500,
        autoplay: false,
        dots: false,
        nav: false,
        items: 3,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1024: {
                items: 3
            },
        },
    });

    /*6. service image carousel */
    $(".service-image-carousel").owlCarousel({
        loop: true,
        autoplay: true,
        dots: false,
        nav: true,
        navText: ["<i class='fas fa-chevron-left'></i>", "<i class='fas fa-chevron-right'></i>"],
        center: true,
        items: 1,
    });

    /*7. sticky sidebar */
    $('.sidebar').stickySidebar({
        topSpacing: 120,
        bottomSpacing: 120,
        minWidth: 992,
    });

    /*8. off canvas */
    $('.off-canvas-open').on('click', function (e) {
        e.preventDefault();
        $('.off-canvas, .off-canvas-overlay').addClass('active');
    })
    $('.off-canvas-close, .off-canvas-overlay').on('click', function (e) {
        e.preventDefault();
        $('.off-canvas, .off-canvas-overlay').removeClass('active');
    })

    /*9. venobox lightbox */
    $('.venobox').venobox();

    /*10. back to top */
    $('#back-to-top').on('click', function () {
        $("html, body").animate({
            scrollTop: 0
        }, 500);
        return false;
    });

    /*11. wow js active*/
    new WOW().init();

    /*12. nav scroll */
    $('.main-nav').on('click', '.mobile-nav-toggle', function (e) {
        e.preventDefault();
        $('.main-nav ul').slideToggle('fast');
    });
    $('.main-nav').navScroll({
        mobileDropdown: true,
        mobileBreakpoint: 991,
        scrollSpy: true,
        navHeight: 82,
    });

    /*13. map activation*/
    if($('#map').length) {
        function initialize() {
            var map = new google.maps.Map(document.getElementById('map'), {
                center: {
                    lat: 23.810332,
                    lng: 90.412518
                },
                zoom: 10,
                styles: [{"featureType":"water","elementType":"geometry","stylers":[{"color":"#e9e9e9"},{"lightness":17}]},{"featureType":"landscape","elementType":"geometry","stylers":[{"color":"#f5f5f5"},{"lightness":20}]},{"featureType":"road.highway","elementType":"geometry.fill","stylers":[{"color":"#ffffff"},{"lightness":17}]},{"featureType":"road.highway","elementType":"geometry.stroke","stylers":[{"color":"#ffffff"},{"lightness":29},{"weight":0.2}]},{"featureType":"road.arterial","elementType":"geometry","stylers":[{"color":"#ffffff"},{"lightness":18}]},{"featureType":"road.local","elementType":"geometry","stylers":[{"color":"#ffffff"},{"lightness":16}]},{"featureType":"poi","elementType":"geometry","stylers":[{"color":"#f5f5f5"},{"lightness":21}]},{"featureType":"poi.park","elementType":"geometry","stylers":[{"color":"#dedede"},{"lightness":21}]},{"elementType":"labels.text.stroke","stylers":[{"visibility":"on"},{"color":"#ffffff"},{"lightness":16}]},{"elementType":"labels.text.fill","stylers":[{"saturation":36},{"color":"#333333"},{"lightness":40}]},{"elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"featureType":"transit","elementType":"geometry","stylers":[{"color":"#f2f2f2"},{"lightness":19}]},{"featureType":"administrative","elementType":"geometry.fill","stylers":[{"color":"#fefefe"},{"lightness":20}]},{"featureType":"administrative","elementType":"geometry.stroke","stylers":[{"color":"#fefefe"},{"lightness":17},{"weight":1.2}]}]
            });
            var marker = new google.maps.Marker({
                position: map.getCenter(),
                animation: google.maps.Animation.BOUNCE,
                icon: 'assets/images/icon.png',
                map: map
            });
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    }
})(jQuery);