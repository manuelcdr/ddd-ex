
// configurações padão do Toastr
toastr.options.closeButton = false;
toastr.options.progressBar = true;
toastr.options.debug = false;
toastr.options.positionClass = 'toast-top-left';
toastr.options.showDuration = 333;
toastr.options.hideDuration = 333;
toastr.options.timeOut = 4000;
toastr.options.extendedTimeOut = 4000;
toastr.options.showEasing = 'swing';
toastr.options.hideEasing = 'swing';
toastr.options.showMethod = 'slideDown';
toastr.options.hideMethod = 'slideUp';

// configurações padrão do DatePicker
$.fn.datepicker.defaults.language = 'pt-BR';
$.fn.datepicker.defaults.todayHighlight = true;
$.fn.datepicker.defaults.format = 'dd/mm/yyyy';

$(function () {

    // verifica versao da imagem do profile
    var imgProfileVersion = sessionStorage.getItem("imgProfileVersion");
    $('img.verify-profile-version').attr('src', $('img.verify-profile-version').attr('src') + '?' + imgProfileVersion);

});