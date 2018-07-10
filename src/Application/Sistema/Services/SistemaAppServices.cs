using AutoMapper;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Models;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Application.Sistema.Services
{
    public class SistemaAppServices : AppServiceBase, ISistemaAppServices
    {
        // services
        private readonly INivelDeAcessoServices nivelDeAcessoServices;
        private readonly IJuridicoCQRS juridicoCQRS;
        private readonly IPessoasRepository pessoasCQRS;
        private readonly IMontagemDeMenusServices montagemMenusServices;
        private readonly IDadosIniciaisServices dadosIniciaisServices;
        private readonly IMenuServices menuServices;

        // cqrs
        private readonly IUsuariosRepositoryCQRS usuariosRepositoryCQRS;

        public SistemaAppServices(
            IUsuariosRepositoryCQRS usuariosCQRS, 
            IMontagemDeMenusServices montagemMenusServices, 
            IDadosIniciaisServices dadosIniciaisServices, 
            IMenuServices menuServices, 
            INivelDeAcessoServices nivelDeAcessoServices, 
            ISistemaCQRS sistemaCQRS, 
            IJuridicoCQRS juridicoCQRS,
            IPessoasRepository pessoasCQRS,
            ISistemaUnitOfWork uow)
            : base(uow, sistemaCQRS)
        {
            this.nivelDeAcessoServices = nivelDeAcessoServices;
            this.juridicoCQRS = juridicoCQRS;
            this.pessoasCQRS = pessoasCQRS;
            this.usuariosRepositoryCQRS = usuariosCQRS;
            this.montagemMenusServices = montagemMenusServices;
            this.dadosIniciaisServices = dadosIniciaisServices;
            this.menuServices = menuServices;
        }

        #region Menu

        public void AdicionarMenu(MenuVM model)
        {
            AdicionarMenuRaiz(model);
            AdicionarMenuFerramenta(model);
            AdicionarMenuDeAcesso(model);
        }

        public void AtualizarMenu(MenuVM model)
        {
            var menu = SistemaCQRS.ObterPorId<Menu>(model.Id);
            menu.Titulo = model.Titulo;
            menu.Url = model.Url;
            menu.Ordem = model.Ordem;

            AtualizarMenuRaiz(menu);
            AtualizarMenuFerramenta(menu);
            AtualizarMenuDeAcesso(menu);
        }

        public MenuVM ObterMenuPorId(Guid id)
        {
            var menu = SistemaCQRS.ObterPorId<Menu>(id);
            menu.AdicionarFilhos(usuariosRepositoryCQRS.ObterMenusFilhos(id).ToArray());
            menu.AtribuirPai(SistemaCQRS.ObterPorId<Menu>(menu.MenuPaiId.GetValueOrDefault()));
            var model = Mapper.Map<MenuVM>(menu);
            return model;
        }

        public IEnumerable<MenuVM> ObterTodosMenus()
        {
            var menus = SistemaCQRS.ObterTodos<Menu>();
            var models = Mapper.Map<IEnumerable<MenuVM>>(menus);
            return models;
        }

        public IEnumerable<MenuVM> ObterTodosMenusFerramentas()
        {
            var menus = usuariosRepositoryCQRS.ObterMenusFerramentaAtivos();
            var models = Mapper.Map<IEnumerable<MenuVM>>(menus);
            return models;
        }

        #endregion

        #region Nivel de Acesso

        public void AdicionarNivelDeAcesso(NivelDeAcessoVM model)
        {
            nivelDeAcessoServices.Adicionar(model.Id, model.Nome, model.Detalhes, model.UsuariosIds, model.MenusIds);
            SaveChanges();
        }

        public void AtualizarNivelDeAcesso(NivelDeAcessoVM model)
        {
            nivelDeAcessoServices.Atualizar(model.Id, model.Nome, model.Detalhes, model.UsuariosIds, model.MenusIds);
            SaveChanges();
        }

        public NivelDeAcessoVM ObterNivelDeAcesso(Guid id)
        {
            var nivelDeAcesso = usuariosRepositoryCQRS.ObterNivelDeAcessoCompleto(id);
            var model = Mapper.Map<NivelDeAcessoVM>(nivelDeAcesso);
            return model;
        }

        public IEnumerable<NivelDeAcessoVM> ObterTodosNiveisDeAcesso()
        {
            return Mapper.Map<IEnumerable<NivelDeAcessoVM>>(SistemaCQRS.ObterTodos<NivelDeAcesso>());
        }

        #endregion

        #region Usuario

        public IEnumerable<UsuarioVM> ObterTodosUsuariosAtivos()
        {
            var usuarios = usuariosRepositoryCQRS.ObterUsuariosAtivos();
            var userIds = usuarios.Select(x => x.Id);
            var pessoas = pessoasCQRS.ObterPessoasPorId(userIds.ToArray());

            var models = new List<UsuarioVM>();
            foreach (var user in usuarios)
            {
                var model = Mapper.Map<UsuarioVM>(user);

                model.Nome = pessoas
                    .Where(p => p.Id == user.Id)
                    .SingleOrDefault()?.Nome;

                models.Add(model);
            }

            return models;
        }

        public IEnumerable<UsuarioVM> ObterTodosUsuarios()
        {
            var usuarios = SistemaCQRS.ObterTodos<Usuario>();
            var userIds = usuarios.Select(x => x.Id);
            var pessoas = pessoasCQRS.ObterPessoasPorId(userIds.ToArray());

            var models = new List<UsuarioVM>();
            foreach (var user in usuarios)
            {
                var model = Mapper.Map<UsuarioVM>(user);

                model.Nome = pessoas
                    .Where(p => p.Id == user.Id)
                    .SingleOrDefault()?.Nome;

                models.Add(model);
            }

            return models;
        }

        public UsuarioVM ObterUsuario(Guid id)
        {
            var usuario = usuariosRepositoryCQRS.ObterUsuarioCompleto(id);
            var pessoa = juridicoCQRS.ObterPorId<Pessoa>(id);
            var model = Mapper.Map<UsuarioVM>(usuario);
            model.Nome = pessoa.Nome;

            return model;
        }

        #endregion


        public void GerarDadosIniciaisDoSistema(Guid usuarioId)
        {
            return;
        }

        #region metodos privados

        private void AdicionarMenuDeAcesso(MenuVM model)
        {
            if (!model.Ferramenta && !model.Raiz)
            {
                menuServices.AdicionarMenuDeAcesso(model.MenuPaiId.Value, model.Titulo, model.Ordem);
                SaveChanges();
            }
        }

        private void AdicionarMenuFerramenta(MenuVM model)
        {
            if (model.Ferramenta)
            {
                menuServices.AdicionarMenuFerramenta(model.MenuPaiId.Value, model.Titulo, model.Url, model.Ordem);
                SaveChanges();
            }
        }

        private void AdicionarMenuRaiz(MenuVM model)
        {
            if (model.Raiz)
            {
                menuServices.AdicionarMenuRaiz(model.Titulo, model.Ordem);
                SaveChanges();
            }
        }

        private void AtualizarMenuDeAcesso(Menu menu)
        {
            if (!menu.Ferramenta && !menu.Raiz)
            {
                menuServices.AtualizarMenuDeAcesso(menu);
                SaveChanges();
            }
        }

        private void AtualizarMenuFerramenta(Menu menu)
        {
            if (menu.Ferramenta)
            {
                menuServices.AtualizarMenuFerramenta(menu);
                SaveChanges();
            }
        }

        private void AtualizarMenuRaiz(Menu menu)
        {
            if (menu.Raiz)
            {
                menuServices.AtualizarMenuRaiz(menu);
                SaveChanges();
            }
        }

        #endregion
    }
}
