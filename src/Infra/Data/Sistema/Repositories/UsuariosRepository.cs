using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PGLaw.Infra.Data.Sistema.Context;
using PGLaw.Infra.Data.Juridico.Repositories;

namespace PGLaw.Infra.Data.Sistema.Repositories
{
    public class UsuariosRepository : SistemaRepositorioGeral, IUsuariosRepository
    {
        public UsuariosRepository(SistemaContext context)
            : base(context) { }

        public void AtualizarRelacionametoMenuNivelDeAcesso(Guid nivelDeAcessoId, params Guid[] menusIds)
        {
            var menus = ObterMenusDoNivelDeAcesso(nivelDeAcessoId);
            var remover = menus?.Where(m => !menusIds.Any(id => id == m.Id))?.Select(m => m.Id)?.ToArray();
            var adicionar = menusIds?.Where(id => !menus.Any(m => m.Id == id))?.ToArray();

            //remove retirados
            var usuariosNiveisRemover = Set<MenuNivelDeAcesso>().Where(x => x.NivelDeAcessoId == nivelDeAcessoId && remover.Any(id => id == x.MenuId));
            Context.RemoveRange(usuariosNiveisRemover);

            //adiciona faltantes
            var usuariosNiveisAdicionar = new List<MenuNivelDeAcesso>();
            foreach (var usuarioId in adicionar)
            {
                var usuarioNivel = new MenuNivelDeAcesso(usuarioId, nivelDeAcessoId);
                usuariosNiveisAdicionar.Add(usuarioNivel);
            }
            Context.AddRange(usuariosNiveisAdicionar);
        }

        public void AtualizarRelacionametoUsuarioNivelDeAcessoPorNivelDeAcesso(Guid nivelDeAcessoId, params Guid[] usuariosIds)
        {
            var usuarios = ObterUsuariosDoNivelDeAcesso(nivelDeAcessoId);
            var remover = usuarios?.Where(u => !usuariosIds.Any(u2 => u2 == u.Id))?.Select(u => u.Id)?.ToArray();
            var adicionar = usuariosIds?.Where(u2 => !usuarios.Any(u => u.Id == u2))?.ToArray();

            //remove retirados
            var usuariosNiveisRemover = Set<UsuarioNivelDeAcesso>().Where(x => x.NivelDeAcessoId == nivelDeAcessoId && remover.Any(id => id == x.UsuarioId));
            Context.RemoveRange(usuariosNiveisRemover);

            //adiciona faltantes
            var usuariosNiveisAdicionar = new List<UsuarioNivelDeAcesso>();
            foreach (var usuarioId in adicionar)
            {
                var usuarioNivel = new UsuarioNivelDeAcesso(usuarioId, nivelDeAcessoId);
                usuariosNiveisAdicionar.Add(usuarioNivel);
            }
            Context.AddRange(usuariosNiveisAdicionar);
        }

        public void AtualizarRelacionametoUsuarioNivelDeAcessoPorUsuario(Guid usuarioId, params Guid[] niveisDeAcessosIds)
        {
            var niveisIds = ObterNiveisDeAcessoIdsPorUsuario(usuarioId);
            var remover = niveisIds?.Where(nId => !niveisDeAcessosIds.Any(n2 => n2 == nId)).ToArray();
            var adicionar = niveisDeAcessosIds?.Where(nId => !niveisIds.Any(n2Id => n2Id == nId))?.ToArray();

            //remove retirados
            var niveisParaRemover = Set<UsuarioNivelDeAcesso>().Where(x => x.UsuarioId == usuarioId && remover.Any(id => id == x.NivelDeAcessoId));
            Context.RemoveRange(niveisParaRemover);

            //adiciona faltantes
            var niveisParaAdicionar = new List<UsuarioNivelDeAcesso>();
            foreach (var nivelId in adicionar)
            {
                var usuarioNivel = new UsuarioNivelDeAcesso(usuarioId, nivelId);
                niveisParaAdicionar.Add(usuarioNivel);
            }
            Context.AddRange(niveisParaAdicionar);
        }

        public IEnumerable<Menu> ObterMenusDeAcessoDoUsuario(Guid usuarioId)
        {
            var usuario = Set<Usuario>()
                .Include(u => u.UsuarioNivelDeAcesso)
                    .ThenInclude(un => un.NivelDeAcesso)
                        .ThenInclude(n => n.MenuNivelDeAcesso)
                            .ThenInclude(nm => nm.Menu)
                .Where(u => u.Id == usuarioId)
                .AsNoTracking()
                .SingleOrDefault();

            var niveis = usuario.UsuarioNivelDeAcesso.Select(n => n.NivelDeAcesso);
            var menusNiveis = niveis.SelectMany(n => n.MenuNivelDeAcesso);
            var menus = menusNiveis.Select(mn => mn.Menu);

            return menus.Distinct();
        }

        public IEnumerable<Menu> ObterMenusDoNivelDeAcesso(Guid nivelDeAcessoId)
        {
            return Set<Menu>()
                .Where(m => m.MenuNivelDeAcesso.Any(mn => mn.NivelDeAcessoId == nivelDeAcessoId))
                .AsNoTracking();
        }

        public IEnumerable<Menu> ObterMenusFerramentaAtivos()
        {
            return Set<Menu>()
                .Where(m => m.Ferramenta)
                .AsNoTracking();
        }

        public IEnumerable<Menu> ObterMenusFilhos(Guid menuPaiId)
        {
            return Set<Menu>()
                .Where(m => m.MenuPaiId.HasValue && m.MenuPaiId.Value == menuPaiId)
                .AsNoTracking();
        }

        public IEnumerable<Menu> ObterMenusPais(params Guid[] menusFilhosIds)
        {
            return Set<Menu>()
                .Where(m => m.MenusFilhos.Any(mf => menusFilhosIds.Any(mfId => mf.Id == mfId)))
                .Distinct()
                .AsNoTracking();
        }

        public IEnumerable<Menu> ObterMenusPorNiveisDeAcessos(params Guid[] niveisDeAcessosIds)
        {
            return Set<MenuNivelDeAcesso>()
                .Where(mn => niveisDeAcessosIds.Any(nId => nId == mn.NivelDeAcessoId))
                .Select(mn => mn.Menu)
                .Distinct()
                .AsNoTracking();
        }

        public IEnumerable<NivelDeAcesso> ObterNiveisDeAcessoDoUsuario(Guid usuarioId)
        {
            return Set<NivelDeAcesso>()
                .Where(n => n.UsuarioNivelDeAcesso.Any(u => u.UsuarioId == usuarioId))
                .AsNoTracking();
        }

        public Guid[] ObterNiveisDeAcessoIdsPorUsuario(Guid usuarioId)
        {
            return Set<UsuarioNivelDeAcesso>()
                .Where(x => x.UsuarioId == usuarioId)
                .Select(x => x.NivelDeAcessoId).ToArray();

        }

        public NivelDeAcesso ObterNivelDeAcessoCompleto(Guid id)
        {
            return Set<NivelDeAcesso>()
                .Include(n => n.UsuarioNivelDeAcesso)
                .Include(n => n.MenuNivelDeAcesso)
                .Where(n => n.Id == id)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public Usuario ObterUsuarioCompleto(Guid id)
        {
            return Set<Usuario>()
                .Include(u => u.UsuarioNivelDeAcesso)
                .Where(n => n.Id == id)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public IEnumerable<Usuario> ObterUsuariosAtivos()
        {
            return Set<Usuario>()
                .Where(u => u.Ativo)
                .AsNoTracking();
        }

        public IEnumerable<Usuario> ObterUsuariosDoNivelDeAcesso(Guid nivelDeAcessoId)
        {
            return Set<Usuario>()
                .Where(u => u.UsuarioNivelDeAcesso.Any(un => un.NivelDeAcessoId == nivelDeAcessoId))
                .AsNoTracking();
        }
    }
}
