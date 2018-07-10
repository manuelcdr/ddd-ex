(function(namespace, $) {
	"use strict";

    var AppFormListaPesquisavel = function() {
		// Create reference to this instance
		var o = this;
		// Initialize app when document is ready
		$(document).ready(function() {
			o.initialize();
		});

	};
    var p = AppFormListaPesquisavel.prototype;

	// =========================================================================
	// INIT
	// =========================================================================

	p.initialize = function() {
		// Init events
        this._enableEvents();
        this.ListasPesquisaveis();
	};
	
	// =========================================================================
	// EVENTS
	// =========================================================================

	// events
	p._enableEvents = function () {
		var o = this;
	};

    // =========================================================================
    // Listas Pesquisáveis
    // =========================================================================

    p.ListasPesquisaveis = function () {
        var o = this;
        $('.container-lista-pesquisavel').each(function (index) {
            $(this).data('container-lista-pesquisavel', index);
            o.ListaPesquisavel(this)
        });
    }


    // =========================================================================
    // Lista Pesquisável
    // =========================================================================

    p.ListaPesquisavel = function(container) {
        this._GerarListaPesquisavel(container, '.lista', '.item', '.nome', '.detalhe');
        this._HabilitarEventoParaCampoPesquisavel(container, '.pesquisa', '.contador-busca');
    }

    // =========================================================================
    // Atualizar listagens
    // =========================================================================

    p.AtualizarListagens = function () {
        var o = this;
        $('.container-lista-pesquisavel').each(function (index) {
            $(this).data('container-lista-pesquisavel', index);
            o.AtualizarListagem(this)
        });
    }

    // =========================================================================
    // Atualizar listagem
    // =========================================================================

    p.AtualizarListagem = function (container) {
        this._GerarListaPesquisavel(container, '.lista', '.item', '.nome', '.detalhe');
    }


    //// =========================================================================
    //// Habilitar evento para atualização das listagens
    //// =========================================================================
    //p._HabilitarEventoParaAtualizacao = function (containerSelector, listaSelector) {
    //    var o = this;
    //    var container = $(containerSelector);
    //    var lista = container.find(listaSelector);

    //    lista.on('change', function () {
    //        o.AtualizarListagem(container);
    //    });
    //}


    // =========================================================================
    // Habilitar evento para campo pesquisável
    // =========================================================================

    p._HabilitarEventoParaCampoPesquisavel = function (containerSelector, pesquisaSelector, contadorSelector) {
        var container = $(containerSelector);
        var campoPesquisa = container.find(pesquisaSelector);

        campoPesquisa.on('change keyup', function () {
            var itens = $.itensListaPesquisavel[container.data('container-lista-pesquisavel')];
            var search = $.trim($(this).val());
            var regex = new RegExp(search, 'gi');

            var contador = 0;

            $.each(itens, function (i) {
                if (itens[i].nome.match(regex) === null && itens[i].detalhe.match(regex) === null) {
                    $(itens[i].elemento).hide();
                } else {
                    $(itens[i].elemento).show();
                    contador += 1;
                }
            });

            var campoContador = container.find(contadorSelector);
            campoContador.html(contador);
        });
    }

    // =========================================================================
    // Gerar lista pesquisavel
    // =========================================================================

    p._GerarListaPesquisavel =  function (containerSelector, listaSelector, itemSelector, nameSelector, detailSelector) {
        console.log(containerSelector);
        var container = $(containerSelector);
        console.log(container);
        var select = $(containerSelector).find(listaSelector);
        var itens = [];

        select.find(itemSelector).each(function (i, item) {
            var nome = $(item).find(nameSelector);
            var detalhe = $(item).find(detailSelector);
            itens.push({ elemento: item, nome: nome.text(), detalhe: detalhe.text() });
        });

        if ($.itensListaPesquisavel == undefined) {
            $.itensListaPesquisavel = {};
        }

        $.itensListaPesquisavel[container.data('container-lista-pesquisavel')] = itens;
        return itens;
    }
    
	
	// =========================================================================
	// DEFINE NAMESPACE
	// =========================================================================

    window.materialadmin.AppFormListaPesquisavel = new AppFormListaPesquisavel;
}(this.materialadmin, jQuery)); // pass in (namespace, jQuery):
