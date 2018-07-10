using System;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using PGLaw.Infra.Cross.Common.Utils;
using static PGLaw.Domain.Sistema.Entitties.Menu;

namespace PGLaw.Domain.Sistema.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly ISistemaGlobalRepository _repository;

        public MenuServices(ISistemaGlobalRepository repository)
        {
            _repository = repository;
        }

        public void AdicionarMenuDeAcesso(Guid menuPaiId, string titulo, int ordem)
        {
            var menuPai = _repository.ObterPorId<Menu>(menuPaiId);
            var menu = menuPai.GerarFilho(titulo, null, ordem);

            AdicionarMenu(menu, TipoMenu.Acesso);
        }

        public void AdicionarMenuFerramenta(Guid menuPaiId, string titulo, string url, int ordem)
        {
            var menuPai = _repository.ObterPorId<Menu>(menuPaiId);
            var menu = menuPai.GerarFilho(titulo, url, ordem);

            AdicionarMenu(menu, TipoMenu.Ferramenta);
        }

        public void AdicionarMenuRaiz(string titulo, int ordem)
        {
            var id = SequentialGuidGenerator.Generate();
            var menu = new Menu(id, titulo, null, ordem, null);

            AdicionarMenu(menu, TipoMenu.Raiz);
        }

        public void AtualizarMenuDeAcesso(Menu menu)
        {
            AtualizarMenu(menu, TipoMenu.Acesso);
        }

        public void AtualizarMenuFerramenta(Menu menu)
        {
            AtualizarMenu(menu, TipoMenu.Ferramenta);
        }

        public void AtualizarMenuRaiz(Menu menu)
        {
            AtualizarMenu(menu, TipoMenu.Raiz);
        }

        private void AdicionarMenu(Menu menu, TipoMenu tipoMenu)
        {
            if (menu.EhValido(tipoMenu))
            {
                _repository.Adicionar(menu);
            }
        }

        private void AtualizarMenu(Menu menu, TipoMenu tipoMenu)
        {
            if (menu.EhValido(tipoMenu))
            {
                _repository.Atualizar(menu);
            }
        }
    }
}
