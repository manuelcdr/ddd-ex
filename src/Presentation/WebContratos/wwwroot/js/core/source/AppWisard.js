
let AppWizard = {

    _index: 0,

    _current: 0,

    _percent: 0,

    _percentWidth: '0%',

    _total: 0,

    _freeNavigation: true,

    _updateNavigation: function (navigation, wizard) {
        navigation.find('li').removeClass('done');
        navigation.find('li.active').prevAll().addClass('done');

        wizard.find('.progress-bar').css({ width: this._percent + '%' });
        $('.form-wizard-horizontal').find('.progress').css({ 'width': this._percentWidth });
    },

    _updateProps: function (navigation, index) {
        this._current = index;
        this._percent = (this._current / (this._total - 1)) * 100;
    },

    _updateButtons: function (wizard) {
        let btnPrevious = wizard.find('.previous').find('.btn');
        let liNext = wizard.find('.next');
        let liFinish = wizard.find('.finish');

        if (this._percent == 0) {
            btnPrevious.addClass('disabled');
        } else {
            btnPrevious.removeClass('disabled');
        }

        if (this._percent == 100) {
            liNext.addClass("hidden");
            liFinish.removeClass("hidden");
        }
        else {
            liNext.removeClass("hidden");
            liFinish.addClass("hidden");
        }
    },

    _initWizard: function () {
        
    },

    initialize: function (wizard) {
        let o = this;
        let navigation = wizard.find('.form-wizard-nav .nav');

        o._total = navigation.find('li').length;
        o._percentWidth = 100 - (100 / this._total) + '%';

        o._updateProps(navigation, 0);
        o._updateNavigation(navigation, wizard);
        o._updateButtons(wizard);

        if (wizard.data('free-navigation') != undefined) {
            o._freeNavigation = wizard.data('free-navidation');
        }

        wizard.bootstrapWizard({
            onInit: function () {
            },
            onTabShow: function (tab, navigation, index) {
                o._updateProps(navigation, index);
                o._updateNavigation(navigation, wizard);
                o._updateButtons(wizard);
            },
            onNext: function (tab, navigation, index) {
                //o._updateProps(navigation, index);

                var form = $('.form-wizard').find('form');

                var form = wizard.find('form');
                var valid = form.validate().form();
                if (!valid) {
                    form.data('validator').focusInvalid();
                    return false;
                }
            },
            onTabClick: function (tab, navigation, index) {
                if (!o._freeNavigation) {
                    return false;
                }
            }
        });
    }
};

$(function () {
    AppWizard.initialize($('.form-wizard'));
})