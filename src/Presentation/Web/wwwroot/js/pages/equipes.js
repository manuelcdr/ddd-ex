function atualizarContador(diferenciador) {
    setTimeout(() => $(`#contator-${diferenciador}s-selecionados`).html($(`#lista-${diferenciador}s-selecionados li`).length), 100);
}

function buscar(diferenciador, url) {
    $.ajax({
        url: url,
        data: $(`#form-pesquisa-${diferenciador}s :input`).serialize(),
        dataType: 'html',
        beforeSend: () => {
            materialadmin.AppCard.addCardLoader($(`#card-lista-${diferenciador}s`));
        },
        success: (data) => {
            $(`#partial-container-${diferenciador}s`).html(data);
        },
        complete: () => {
            materialadmin.AppCard.removeCardLoader($(`#card-lista-${diferenciador}s`));
        }
    });
}

function addOption(id, nome, diferenciador) {
    if ($(`#${diferenciador}sSelecionados option#opt-${diferenciador}-selecionado-${id}`).length == 0) {
        var $item = $(`<option id="opt-${diferenciador}-selecionado-${id}" selected value="${id}">${nome}</option>`);
        $(`#${diferenciador}sSelecionados`).append($item);
    }
}

function addLi(id, nome, diferenciador) {
    if ($(`#lista-${diferenciador}s-selecionados li#${diferenciador}-selecionado-${id}`).length == 0) {
        var $item = $(`
                    <li id="${diferenciador}-selecionado-${id}" class="tile item" style="display: none; ">
                        <a class="tile-content ink-reaction">
                            <div class="tile-icon"><img src="~/Content/pessoas/img/profile/${id}.jpg" onerror="imgFallBack(this);" alt=""></div>
                            <div class="tile-text nome detalhes"><p class="no-margin text-sm">${nome}</p></div>
                        </a>
                        <a class="btn btn-sm btn-flat ink-reaction btn-danger" onclick="remove${diferenciador}(${id})"><i class="md md-remove-circle-outline"></i></a>
                    </li>
                `);

        $(`#lista-${diferenciador}s-selecionados`).append($item);

        $item.show(333, function () {
            atualizarContador(diferenciador);
            materialadmin.AppFormListaPesquisavel.AtualizarListagem(`#card-lista-${diferenciador}s-selecionados`);
        });
    }
}

function removeOption(id, diferenciador) {
    $(`#${diferenciador}sSelecionados option#opt-${diferenciador}-selecionado-${id}`).remove();
}

function removeLi(id, diferenciador) {
    $(`#lista-${diferenciador}s-selecionados li#${diferenciador}-selecionado-${id}`).hide(333, function () {
        $(this).remove();
        atualizarContador(diferenciador);
        materialadmin.AppFormListaPesquisavel.AtualizarListagem(`#card-lista-${diferenciador}s-selecionados`);
    });
}

function addpessoa(id, nome) {
    addOption(id, nome, 'pessoa');
    addLi(id, nome, 'pessoa');

}

function removepessoa(id) {
    removeLi(id, 'pessoa');
    removeOption(id, 'pessoa');
}

function addcliente(id, nome) {
    addOption(id, nome, 'cliente');
    addLi(id, nome, 'cliente');

}

function removecliente(id) {
    removeLi(id, 'cliente');
    removeOption(id, 'cliente');
}

function eventBuscarPessoas(event) {
    if (event.key == 'Enter') {
        event.preventDefault();
        buscarPessoas();
    }
}

function eventBuscarClientes(event) {
    if (event.key == 'Enter') {
        event.preventDefault();
        buscarClientes();
    }
}

function verificarTarget(event) {
    if (event.target.classList.contains('prevent-default-onEnter')) {
        if (event.key == 'Enter') {
            event.preventDefault();
        }
    }
}