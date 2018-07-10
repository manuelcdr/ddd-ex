(function (namespace, $) {
    "use strict";

    var AppForm = function () {
        // Create reference to this instance
        var o = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            o.initialize();
        });

    };
    var p = AppForm.prototype;

    p.classSelect2Default = 'select2-default';

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function () {
        // Init events
        this._enableEvents();

        this._initRadioAndCheckbox();
        this._initFloatingLabels();
        this._MultSelect();
        this._initSpinners();
        this._ComboCascading();
        this._changeSelect();
    };

    // =========================================================================
    // EVENTS
    // =========================================================================

    // events
    p._enableEvents = function () {
        var o = this;

        // Link submit function
        $('[data-submit="form"]').on('click', function (e) {
            e.preventDefault();
            var formId = $(e.currentTarget).attr('href');
            $(formId).submit();
        });

        // Focus on first input
        $('.focus :input:first').focus();

        // masks
        $(":input").inputmask();

        // datepicker
        $(".datepicker").datepicker();

        // select2
        $('.select2').select2();


        $('textarea.autosize').autosize();

        // Init textarea autosize
        $('textarea.autosize').on('focus', function () {
            $(this).autosize({ append: '' });
        });
    };

    // =========================================================================
    // RADIO AND CHECKBOX LISTENERS
    // =========================================================================

    p._initRadioAndCheckbox = function () {
        // Add a span class the styled checkboxes and radio buttons for correct styling
        $('.checkbox-styled input, .radio-styled input').each(function () {
            if ($(this).next('span').length === 0) {
                $(this).after('<span></span>');
            }
        });
    };

    // =========================================================================
    // FLOATING LABELS
    // =========================================================================

    p._initFloatingLabels = function () {
        var o = this;

        $('.floating-label .form-control').on('keyup change', function (e) {
            var input = $(e.currentTarget);

            if ($.trim(input.val()) !== '') {
                input.addClass('dirty').removeClass('static');
            } else {
                input.removeClass('dirty').removeClass('static');
            }
        });

        $('.floating-label .form-control').each(function () {
            var input = $(this);

            if ($.trim(input.val()) !== '') {
                input.addClass('static').addClass('dirty');
            }
        });

        $('.form-horizontal .form-control').each(function () {
            $(this).after('<div class="form-control-line"></div>');
        });
    };


    // =========================================================================
    // Mult Select
    // =========================================================================

    p._MultSelect = function () {
        $('.mult-select').multiSelect({
            selectableHeader: "<input type='text' class='form-control search-input input-sm' autocomplete='off' placeholder='Pesquisar...'>",
            selectionHeader: "<input type='text' class='form-control search-input input-sm' autocomplete='off' placeholder='Pesquisar...'>",
            afterInit: function (ms) {
                var that = this,
                    $selectableSearch = that.$selectableUl.prev(),
                    $selectionSearch = that.$selectionUl.prev(),
                    selectableSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selectable:not(.ms-selected)',
                    selectionSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selection.ms-selected';

                that.qs1 = $selectableSearch.quicksearch(selectableSearchString)
                    .on('keydown', function (e) {
                        if (e.which === 40) {
                            that.$selectableUl.focus();
                            return false;
                        }
                    });

                that.qs2 = $selectionSearch.quicksearch(selectionSearchString)
                    .on('keydown', function (e) {
                        if (e.which == 40) {
                            that.$selectionUl.focus();
                            return false;
                        }
                    });
            },
            afterSelect: function () {
                this.qs1.cache();
                this.qs2.cache();
            },
            afterDeselect: function () {
                this.qs1.cache();
                this.qs2.cache();
            }
        });
    };


    // =========================================================================
    // SPINNERS
    // =========================================================================

    p._initSpinners = function () {
        if (!$.isFunction($.fn.spinner)) {
            return;
        }
        $(".spinner").each(function (index, element) {
            var campo = $(this);
            var min = campo.data('min');
            var max = campo.data('max');

            var obj = {};
            if (min != undefined) obj.min = min;
            if (max != undefined) obj.max = max;

            campo.spinner(obj);
        });



        //$(".spinner-decimal").spinner({ step: 0.01, numberFormat: "n", max: 1 });
    };


    // =========================================================================
    // Event Change Selects
    // =========================================================================

    p._changeSelect = function () {
        var o = this;

        $('select').change(function () {
            if ($(this).val() == '') {
                let $a = $(`#s2id_${$(this).attr('id')} a`);
                if ($a != undefined) {
                    $a.addClass(o.classSelect2Default);
                } else {
                    $(this).addClass(o.classSelect2Default);
                }
            } else {
                $(this).removeClass(o.classSelect2Default);
            }
        });
    };

    // =========================================================================
    // Combo Cascading
    // =========================================================================

    p._ComboCascading = function () {
        var o = this;

        $(".combo-cascade").change(function () {
            var combos = [];
            var parametrosAdicionais = [];
            var parametrosCampos = [];
            var urls = [];
            var seleciones = [];
            var valor = 0;

            valor = $(this).val();

            var combos = $(this).data("combo-update").split("|");
            var urls = $(this).data("url").split("|");
            
            if ($(this).data("parametros-adicionais"))
                parametrosAdicionais = $(this).data("parametros-adicionais").split("|");
            if ($(this).data("selecione"))
                seleciones = $(this).data("selecione").split("|");
            if ($(this).data("parametros-campos"))
                parametrosCampos = $(this).data("parametros-campos").split("|");

            combos.forEach(function (nomeCombo, index) {

                var $comboAtualizar = null;
                var selecione = true;
                var parametros = {};
                var url = "";

                url = urls[index];
                $comboAtualizar = $(combos[index]);

                if (seleciones.length > 0)
                    selecione = seleciones[index];

                if (parametrosAdicionais.length > 0) {
                    parametros = JSON.parse(JSON.stringify(parametrosAdicionais[index]));
                }

                if (parametrosCampos.length > 0) {
                    var campos = parametrosCampos[index].split(",");
                    campos.forEach(function (campo) {
                        var valor = $(`[name=${campo}]`).val();
                        parametros[campo] = valor;
                    });
                }

                parametros['id'] = valor;

                console.log(JSON.stringify(parametros));

                $.getJSON(
                    url,
                    parametros,
                    function (data) {
                        console.log(data);
                        $comboAtualizar.empty();

                        var isSelect2 = false;

                        let $select2a = $(`#s2id_${$comboAtualizar.attr('id')} a`);
                        let $select2span = $(`#s2id_${$comboAtualizar.attr('id')} .select2-chosen`);

                        if ($select2a != undefined) {
                            isSelect2 = true;
                            $select2span.text('');
                        }

                        if (selecione) {
                            var text = 'Selecione';
                            let itemSelecione = o.MontarOption(text);
                            $comboAtualizar.append(itemSelecione);

                            if (isSelect2) {
                                $comboAtualizar.select2('val', null, true);
                            }
                        }

                        $.each(data, function (i, option) {
                            let item = o.MontarOption(option.text, option.value);
                            $comboAtualizar.append(item);
                        });
                    }
                );
            });
        });
    };

    p.MontarOption = function (text, value = '', selected = false) {
        let $selectItem = $(`<option value='${value}'>${text}</option>`);
        if (selected) {
            $selectItem.attr('selected', 'selected');
        }
        return $selectItem;
    }


    // =========================================================================
    // DEFINE NAMESPACE
    // =========================================================================

    window.materialadmin.AppForm = new AppForm;
}(this.materialadmin, jQuery)); // pass in (namespace, jQuery):
