﻿/**
* Template Name: iPortfolio
* Template URL: https://bootstrapmade.com/iportfolio-bootstrap-portfolio-websites-template/
* Updated: Mar 17 2024 with Bootstrap v5.3.3
* Author: BootstrapMade.com
* License: https://bootstrapmade.com/license/
*/

$(function () {
    "use strict";

    /**
     * Easy selector helper function
     */
    const select = (el, all = false) => {
        el = el.trim()
        if (all) {
            return [...document.querySelectorAll(el)]
        } else {
            return document.querySelector(el)
        }
    }

    /**
     * Easy event listener function
     */
    const on = (type, el, listener, all = false) => {
        let selectEl = select(el, all)
        if (selectEl) {
            if (all) {
                selectEl.forEach(e => e.addEventListener(type, listener))
            } else {
                selectEl.addEventListener(type, listener)
            }
        }
    }

    /**
     * Easy on scroll event listener 
     */
    const onscroll = (el, listener) => {
        el.addEventListener('scroll', listener)
    }

    /**
     * Navbar links active state on scroll
     */
    let navbarlinks = select('#navbar .scrollto', true)
    const navbarlinksActive = () => {
        let position = window.scrollY + 200
        navbarlinks.forEach(navbarlink => {
            if (!navbarlink.hash) return
            let section = select(navbarlink.hash)
            if (!section) return
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                navbarlink.classList.add('active')
            } else {
                navbarlink.classList.remove('active')
            }
        })
    }
    window.addEventListener('load', navbarlinksActive)
    onscroll(document, navbarlinksActive)

    /**
     * Scrolls to an element with header offset
     */
    const scrollto = (el) => {
        let elementPos = select(el).offsetTop
        window.scrollTo({
            top: elementPos,
            behavior: 'smooth'
        })
    }

    /**
     * Back to top button
     */
    let backtotop = select('.back-to-top')
    if (backtotop) {
        const toggleBacktotop = () => {
            if (window.scrollY > 100) {
                backtotop.classList.add('active')
            } else {
                backtotop.classList.remove('active')
            }
        }
        window.addEventListener('load', toggleBacktotop)
        onscroll(document, toggleBacktotop)
    }

    /**
     * Mobile nav toggle
     */
    on('click', '.mobile-nav-toggle', function (e) {
        select('body').classList.toggle('mobile-nav-active')
        this.classList.toggle('bi-list')
        this.classList.toggle('bi-x')
    })

    /**
     * Scrool with ofset on links with a class name .scrollto
     */
    on('click', '.scrollto', function (e) {
        if (select(this.hash)) {
            e.preventDefault()

            let body = select('body')
            if (body.classList.contains('mobile-nav-active')) {
                body.classList.remove('mobile-nav-active')
                let navbarToggle = select('.mobile-nav-toggle')
                navbarToggle.classList.toggle('bi-list')
                navbarToggle.classList.toggle('bi-x')
            }
            scrollto(this.hash)
        }
    }, true)

    /**
     * Scroll with ofset on page load with hash links in the url
     */
    window.addEventListener('load', () => {
        if (window.location.hash) {
            if (select(window.location.hash)) {
                scrollto(window.location.hash)
            }
        }
    });

    /**
     * Skills animation
     */
    let skilsContent = select('.skills-content');
    if (skilsContent) {
        new Waypoint({
            element: skilsContent,
            offset: '80%',
            handler: function (direction) {
                let progress = select('.progress .progress-bar', true);
                progress.forEach((el) => {
                    el.style.width = el.getAttribute('aria-valuenow') + '%'
                });
            }
        })
    }

    /**
     * Porfolio isotope and filter
     */
    window.addEventListener('load', () => {
        let galleryContainer = select('.gallery-container');
        if (galleryContainer) {
            let galleryIsotope = new Isotope(galleryContainer, {
                itemSelector: '.gallery-item'
            });

            let galleryFilters = select('#gallery-filters li', true);

            on('click', '#gallery-filters li', function (e) {
                e.preventDefault();
                galleryFilters.forEach(function (el) {
                    el.classList.remove('filter-active');
                });
                this.classList.add('filter-active');

                galleryIsotope.arrange({
                    filter: this.getAttribute('data-filter')
                });
                galleryIsotope.on('arrangeComplete', function () {
                    AOS.refresh()
                });
            }, true);
        }

    });

    /**
     * Initiate gallery lightbox 
     */
    const galleryLightbox = GLightbox({
        selector: '.gallery-lightbox'
    });

    /**
     * Portfolio details slider
     */
    new Swiper('.gallery-details-slider', {
        speed: 400,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        pagination: {
            el: '.swiper-pagination',
            type: 'bullets',
            clickable: true
        }
    });

    /**
     * Testimonials slider
     */
    new Swiper('.testimonials-slider', {
        speed: 600,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: true
        },
        slidesPerView: 'auto',
        pagination: {
            el: '.swiper-pagination',
            type: 'bullets',
            clickable: true
        },
        breakpoints: {
            320: {
                slidesPerView: 1,
                spaceBetween: 20
            },

            1200: {
                slidesPerView: 3,
                spaceBetween: 20
            }
        }
    });

    /**
     * Animation on scroll
     */
    window.addEventListener('load', () => {
        AOS.init({
            duration: 500,
            easing: 'ease-in-out',
            once: true,
            mirror: false
        })
    });

    /**
    * ContactForm validation
    */
    let validator = $('form.contact-form')
        .jbvalidator({
            errorMessage: true,
            successClass: true,
            language: '../assets/vendors/jbvalidator/lang/en.json'
        });

    /**
     * ContactForm submission
     */
    $("#contactSubmit").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();
        $.ajax({
            type: "POST",
            url: "/Index?handler=SubmitChat",
            beforeSend: function (xhr) {
                if (validator.checkAll() > 0) {
                    xhr.abort();
                    return;
                }
                $('.loading').toggle();
                $('.contactSubmit').toggle();
                xhr.setRequestHeader("RequestVerificationToken", $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: {
                "ContactModel": {
                    "Name": $('#contactName').val(),
                    "Email": $('#contactEmail').val(),
                    "Subject": $('#contactSubject').val(),
                    "Message": $('#contactMessage').val()
                }
            },
            success: function (response) {
                $('#contact-form')[0].reset();
                $('#contact-form').find('.is-valid, .is-invalid').removeClass('is-valid is-invalid');
                $('.loading').toggle();
                $('.success-message').toggle();
                setTimeout(function () {
                    $('.success-message').toggle();
                    $('.contactSubmit').toggle();
                }, 5000);
            },
            failure: function (response) {
                $('.loading').toggle();
                $('.error-message').toggle();
                setTimeout(function () {
                    $('.error-message').toggle();
                    $('.contactSubmit').toggle();
                }, 5000);
            },
            error: function (response) {
                $('.loading').toggle();
                $('.error-message').toggle();
                setTimeout(function () {
                    $('.error-message').toggle();
                    $('.contactSubmit').toggle();
                }, 5000);
            }
        });
    });


    /**
     * Email obfuscator
     */
    const obfuscator = {
        obfuscate: function (el) {
            if (el) {

                let mailto = el.attr('href');
                let email = atob(mailto);

                el.attr('href', 'mailTo:' + email);
                el.text(email);
            }
        }
    }
    obfuscator.obfuscate($('.mailto'));
});


$(function () {

    if ($(location).attr('pathname').endsWith('/privacy')) {
        return;
    }

    const GDPR_ACCEPTED = 'gdpr_accepted';

    var gdprElement = $('#gdpr-consent');

    if (!gdprElement) {
        return;
    }

    var gdprAccepted = Cookies.get(GDPR_ACCEPTED);

    if (!gdprAccepted) {
        gdprElement.slideDown();
    }

    $('#accept-btn').on('click', function () {
        gdprElement.slideUp();
        Cookies.set(GDPR_ACCEPTED, 'true', { expires: 30 });
    });

    $('#reject-btn').on('click', function () {
        gdprElement.slideUp();
    });
});