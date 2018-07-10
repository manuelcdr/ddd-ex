using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using System;
using System.Linq;

namespace PGLaw.Domain.Sistema.Services
{
    public class DadosIniciaisServices : IDadosIniciaisServices
    {
        private readonly ISistemaGlobalRepository repository;

        public DadosIniciaisServices(ISistemaGlobalRepository repository)
        {
            this.repository = repository;
        }

        

        public void Gerar(Guid usuarioId)
        {
            //var menuSistema = MenuFactory.CriarMenuRaiz("Sistema");
            //var menuMenus = MenuFactory.CriarMenuFilhoFerramenta(menuSistema, "Menus", "Menus");
            //var menuNivel = MenuFactory.CriarMenuFilhoFerramenta(menuSistema, "Niveis de Acessos", "NiveisDeAcessos");
            //var menuUsuario = MenuFactory.CriarMenuFilhoFerramenta(menuSistema, "Usuarios", "Usuarios");

            //var nivelDeAcesso = repository.Buscar<NivelDeAcesso>(x => x.Nome.Equals("Administrador do Sistema")).Single();
            //nivelDeAcesso.AdicionarMenu(menuMenus, menuNivel, menuUsuario);
            //nivelDeAcesso.AdicionarUsuario(usuarioId);

            //repository.Adicionar(menuSistema);
            //repository.Adicionar(menuMenus);
            //repository.Adicionar(menuNivel);
            //repository.Adicionar(menuUsuario);
            ////repository.Atualizar(nivelDeAcesso);

            //foreach(var rel  in nivelDeAcesso.MenuNivelDeAcesso)
            //{
            //    var entidade = repository.Buscar<MenuNivelDeAcesso>(x => x.NivelDeAcessoId == rel.NivelDeAcessoId && x.MenuId == rel.MenuId)
            //        .SingleOrDefault();

            //    if (entidade == null)
            //        repository.Adicionar(rel);
            //}
        }

    }
}
