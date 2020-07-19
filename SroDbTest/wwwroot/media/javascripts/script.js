/* ----------------- Start JS Document ----------------- */

// Page Loader
$(window).load(function () {
    "use strict";
    $('#loader').fadeOut();
});

$(document).ready(function ($) {
    "use strict";
    ////	Hidder Header
    var headerEle = function () {
        var $headerHeight = $('header').height();
        $('.hidden-header').css({'height': $headerHeight + "px"});
    };

    $(window).load(function () {
        headerEle();
    });

    $(window).resize(function () {
        headerEle();
    });


    $('#login-modal').click(function (e) {
        e.preventDefault();
        var modal = $('#modal-login');
        modal.find('#lostpw-form').hide();
        modal.find('#modal-login-label').html('Kullanıcı Girişi');
        modal.find('#login-form').show();
        modal.modal();
    });

    $('#lostpw-link').click(function (e) {
        e.preventDefault();
        var modal = $('#modal-login');
        modal.find('#login-form').hide();
        modal.find('#modal-login-label').html('Şifremi Unuttum');
        modal.find('#lostpw-form').show();
    });

    $('#login-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#login-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#login-form', json_obj.status, json_obj.text);
                    if (json_obj.status == 'success') {
                        setTimeout("window.location = 'index.html';", 500);
                        return true;
                    }
                } catch (e) {
                    appendAlertBox('#login-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
            })
            .fail(function () {
                appendAlertBox('#login-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
            });
        return false;
    });

    $('#lostpw-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#lostpw-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#lostpw-form', json_obj.status, json_obj.text);
                } catch (e) {
                    appendAlertBox('#lostpw-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
            })
            .fail(function () {
                appendAlertBox('#lostpw-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
            });
        return false;
    });

    $('#register-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#register-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#register-form', json_obj.status, json_obj.text);
                } catch (e) {
                    appendAlertBox('#register-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
                reloadCaptcha();
            })
            .fail(function () {
                appendAlertBox('#register-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
                reloadCaptcha();
            });
        return false;
    });

    $('#maxicard-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#maxicard-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#maxicard-form', json_obj.status, json_obj.text);
                } catch (e) {
                    appendAlertBox('#maxicard-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
                reloadCaptcha();
            })
            .fail(function () {
                appendAlertBox('#maxicard-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
                reloadCaptcha();
            });
        return false;
    });

    $('#changepw-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#changepw-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#changepw-form', json_obj.status, json_obj.text);
                } catch (e) {
                    appendAlertBox('#changepw-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
                reloadCaptcha();
            })
            .fail(function () {
                appendAlertBox('#changepw-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
                reloadCaptcha();
            });
        return false;
    });

    $('#changesecret-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#changesecret-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#changesecret-form', json_obj.status, json_obj.text);
                } catch (e) {
                    appendAlertBox('#changesecret-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
                reloadCaptcha();
            })
            .fail(function () {
                appendAlertBox('#changesecret-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
                reloadCaptcha();
            });
        return false;
    });

    $('#savechar-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#savechar-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#savechar-form', json_obj.status, json_obj.text);
                } catch (e) {
                    appendAlertBox('#savechar-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
                reloadCaptcha();
            })
            .fail(function () {
                appendAlertBox('#savechar-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
                reloadCaptcha();
            });
        return false;
    });

    $('#useepin-form').submit(function () {
        var form = $(this);
        form.find('.alert').empty();
        removeAlertBox('#useepin-form');
        $.post("remo.html", form.serialize())
            .done(function (data) {
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#useepin-form', json_obj.status, json_obj.text);
                } catch (e) {
                    appendAlertBox('#useepin-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
                reloadCaptcha();
            })
            .fail(function () {
                appendAlertBox('#useepin-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
                reloadCaptcha();
            });
        return false;
    });

    $('#buyitinfo').find('#buyit').click(function () {
        var btn = $(this);

        removeAlertBox('#buyit-form');
        btn.prop('disabled', true).css('cursor', 'progress');
        $.post('remo.html', $('#buyit-form').serialize())
            .done(function (data) {
                btn.prop('disabled', false).css('cursor', 'pointer');
                try {
                    var json_obj = $.parseJSON(data);
                    appendAlertBox('#buyit-form', json_obj.status, json_obj.text);

                    if (json_obj.status == 'success') {
                        setTimeout("window.location = 'market.html';", 1500);
                        return true;
                    }
                } catch (e) {
                    appendAlertBox('#buyit-form', 'error', 'Lütfen, özel karakter kullanmayın.');
                }
            })
            .fail(function () {
                btn.prop('disabled', false).css('cursor', 'pointer');
                appendAlertBox('#buyit-form', 'error', 'Üzgünüz, işleminiz gerçekleştirilemedi.');
            });

        return false;
    });

    $('#buyit-form').submit(function () {
        $('#buyitinfo').find('#buyit').trigger('click');
        return false;
    });

    /*---------------------------------------------------*/
    /* Progress Bar
     /*---------------------------------------------------*/
    $('.widget-server-status').appear(function () {
        $('.progress').each(function () {
            $('.progress-bar').css('width', function () {
                return ($(this).attr('data-percentage') + '%')
            });
        });
    }, {accY: -100});


    /*----------------------------------------------------*/
    /*	Nice-Scroll
     /*----------------------------------------------------*/

    /*$("html").niceScroll({
        scrollspeed: 100,
        mousescrollstep: 38,
        cursorwidth: 5,
        cursorborder: 0,
        cursorcolor: '#333',
        autohidemode: true,
        zindex: 999999999,
        horizrailenabled: false,
        cursorborderradius: 0
    });*/

    /*----------------------------------------------------*/
    /*	Nav Menu & Search
     /*----------------------------------------------------*/

    $(".nav > li:has(ul)").addClass("drop");
    $(".nav > li.drop > ul").addClass("dropdown");
    $(".nav > li.drop > ul.dropdown ul").addClass("sup-dropdown");

    /*----------------------------------------------------*/
    /*	Back Top Link
     /*----------------------------------------------------*/

    var offset = 200;
    var duration = 500;
    $(window).scroll(function () {
        if ($(this).scrollTop() > offset) {
            $('.back-to-top').fadeIn(400);
        } else {
            $('.back-to-top').fadeOut(400);
        }
    });
    $('.back-to-top').click(function (event) {
        event.preventDefault();
        $('html, body').animate({scrollTop: 0}, 600);
        return false;
    });

    /*----------------------------------------------------*/
    /*	Sliders & Carousel
     /*----------------------------------------------------*/

    ////------- Projects Carousel
    $(".projects-carousel").owlCarousel({
        navigation: true,
        pagination: false,
        slideSpeed: 400,
        stopOnHover: true,
        autoPlay: 3000,
        items: 4,
        itemsDesktopSmall: [900, 3],
        itemsTablet: [600, 2],
        itemsMobile: [479, 1]
    });


    /*----------------------------------------------------*/
    /*	Css3 Transition
     /*----------------------------------------------------*/

    $('*').each(function () {
        if ($(this).attr('data-animation')) {
            var $animationName = $(this).attr('data-animation'),
                $animationDelay = "delay-" + $(this).attr('data-animation-delay');
            $(this).appear(function () {
                $(this).addClass('animated').addClass($animationName);
                $(this).addClass('animated').addClass($animationDelay);
            });
        }
    });


    /*----------------------------------------------------*/
    /*	Sticky Header
     /*----------------------------------------------------*/

    (function () {

        var docElem = document.documentElement,
            didScroll = false,
            changeHeaderOn = 100;
        document.querySelector('header');

        function init() {
            window.addEventListener('scroll', function () {
                if (!didScroll) {
                    didScroll = true;
                    setTimeout(scrollPage, 250);
                }
            }, false);
        }

        function scrollPage() {
            var sy = scrollY();
            if (sy >= changeHeaderOn) {
                $('.top-bar').slideUp(300);
                $("header").addClass("fixed-header");
                $('.navbar-brand').css({'padding-top': 19 + "px", 'padding-bottom': 19 + "px"});

                if (/iPhone|iPod|BlackBerry/i.test(navigator.userAgent) || $(window).width() < 479) {
                    $('.navbar-default .navbar-nav > li > a').css({'padding-top': 0 + "px", 'padding-bottom': 0 + "px"})
                } else {
                    $('.navbar-default .navbar-nav > li > a').css({
                        'padding-top': 20 + "px",
                        'padding-bottom': 20 + "px"
                    })
                    $('.search-side').css({'margin-top': -7 + "px"});
                }
                ;

            }
            else {
                $('.top-bar').slideDown(300);
                $("header").removeClass("fixed-header");
                $('.navbar-brand').css({'padding-top': 27 + "px", 'padding-bottom': 27 + "px"});

                if (/iPhone|iPod|BlackBerry/i.test(navigator.userAgent) || $(window).width() < 479) {
                    $('.navbar-default .navbar-nav > li > a').css({'padding-top': 0 + "px", 'padding-bottom': 0 + "px"})
                } else {
                    $('.navbar-default .navbar-nav > li > a').css({
                        'padding-top': 28 + "px",
                        'padding-bottom': 28 + "px"
                    })
                    $('.search-side').css({'margin-top': 0 + "px"});
                }
                ;

            }
            didScroll = false;
        }

        function scrollY() {
            return window.pageYOffset || docElem.scrollTop;
        }

        init();


    })();
});


$(document).ready(function () {
    /**
     * Slick Nav
     */
    $('.wpb-mobile-menu').slicknav({
        prependTo: '.navbar-header',
        parentTag: 'margo',
        allowParentLinks: true,
        duplicate: false,
        label: '',
        closedSymbol: '<i class="fa fa-angle-right"></i>',
        openedSymbol: '<i class="fa fa-angle-down"></i>'
    });
});

function setNavActive(selector) {
    $(selector).parent().find('.active').removeClass('active');
    $('.nav').find(selector + ' a').addClass('active');
}

function appendAlertBox(selector, type, message) {
    $(selector).prepend('<div id="alertBox" class="alert alert-' + type + '"><span>' + message + '</span></div>')
}

function removeAlertBox(selector) {
    $(selector).find('#alertBox').remove();
}

function reloadCaptcha() {
    $("#CaptchaImg").attr("src", "captcha57b3.jpg?width=110&amp;height=33&amp;characters=6");
}

function serverTime() {
    if (!document.all && !document.getElementById) {
        return;
    }
    var Stunden = ServerTime.getHours();
    var Minuten = ServerTime.getMinutes();
    var Sekunden = ServerTime.getSeconds();
    ServerTime.setSeconds(Sekunden + 1);
    if (Stunden <= 9) {
        Stunden = "0" + Stunden;
    }

    if (Minuten <= 9) {
        Minuten = "0" + Minuten;
    }
    if (Sekunden <= 9) {
        Sekunden = "0" + Sekunden;
    }
    jQuery('#cur_time').text(Stunden.toString() + ':' + Minuten.toString() + ':' + Sekunden.toString());
}

function tTimer(iEndTimeStamp, iTimeStamp, sElement) {
    iTimeStamp = iTimeStamp - Math.round(+new Date() / 1000) - iEndTimeStamp;
    if (iTimeStamp < 0) {
        jQuery('#' + sElement).html('00:00:00');
        return false;
    }
    diffDay = iTimeStamp / (3600 * 24 );
    diffDay = diffDay.toString();
    diffDay = diffDay.split(".");
    diffHour = iTimeStamp / 3600 % 24;
    diffHour = diffHour.toString();
    diffHour = diffHour.split(".");
    diffMin = iTimeStamp / 60 % 60;
    diffMin = diffMin.toString();
    diffMin = diffMin.split(".");
    diffSek = iTimeStamp % 60;
    diffSek = diffSek.toString();
    diffSek = diffSek.split(".");
    if (diffDay[0] != 0) {
        jQuery('#' + sElement).html(diffDay[0] + ':' + checkLength(diffHour[0]) + ':' + checkLength(diffMin[0]) + ':' + checkLength(diffSek[0]));
        return true;
    } else {
        jQuery('#' + sElement).html(checkLength(diffHour[0]) + ':' + checkLength(diffMin[0]) + ':' + checkLength(diffSek[0]));
        return true;
    }
}

function checkLength(sString) {
    sString = sString.toString();
    if (sString.length == 1) {
        sString = '0' + sString;
    }
    return sString;
}
