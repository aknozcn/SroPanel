function appendAlertBox(selector, type, message) {
    $(selector).prepend('<div id="alertBox" class="alert alert-' + type + '">' + message + '</div>')
}

function removeAlertBox(selector) {
    $(selector).find('#alertBox').remove();
}

function appendFormErrors(selector, data) {
    $.each(data, function (index, value) {
        var group = $(selector).find('#group-' + index);

        group.addClass('has-error');
        group.find('input, select, textarea:not(:parent.sceditor-container textarea)').after('<span class="help-block"><strong>' + value[0] + '</strong></span>');
    });
}

function removeFormErrors(selector) {
    $(selector).find('.has-error').removeClass('has-error');
    $(selector).find('.help-block').remove();
}

function overOverLayer() {
    overOverLayerClose();
    $('body').append('<div id="ovd-overlay" class="ovd-overlay ovd-overlay-fixed"></div>')
        .append('<div id="ovd-loading"><div></div></div>');
}

function overOverLayerClose() {
    $('#ovd-loading, #ovd-overlay').remove();
}

function reloadCaptcha() {
    document.getElementById('CaptchaImg').src = '/user/captcha/default?' + Math.random().toString(36).replace(/[^a-z]+/g, '').substr(0, 8);
}
