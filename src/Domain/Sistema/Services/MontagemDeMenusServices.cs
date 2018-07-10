using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Domain.Sistema.Services
{
    public class MontagemDeMenusServices : IMontagemDeMenusServices
    {
        private readonly IUsuariosRepository aditionalRepository;
        private readonly ISistemaGlobalRepository repository;

        public MontagemDeMenusServices(ISistemaGlobalRepository repository, IUsuariosRepository aditionalRepository)
        {
            this.repository = repository;
            this.aditionalRepository = aditionalRepository;
        }

        public IEnumerable<Menu> ObterArvoreDeAcessoDoUsuario(Guid usuarioId)
        {
            var niveisDeAcessosIds = aditionalRepository.ObterNiveisDeAcessoIdsPorUsuario(usuarioId);

            var arvoreMenus = new List<Menu>();
            var ferramentas = aditionalRepository.ObterMenusPorNiveisDeAcessos(niveisDeAcessosIds);
            var menusPais = aditionalRepository.ObterMenusPais(ferramentas.Select(m => m.Id).ToArray());

            arvoreMenus.AddRange(ferramentas);
            arvoreMenus.AddRange(menusPais);

            var menusPaisNaoRaiz = menusPais.Where(mp => !mp.Raiz).ToArray();

            while (menusPaisNaoRaiz.Count() > 0)
            {
                var menusPaisDosPais = aditionalRepository.ObterMenusPais(menusPaisNaoRaiz.Select(m => m.Id).ToArray());
                arvoreMenus.AddRange(menusPaisDosPais);
                menusPaisNaoRaiz = menusPaisDosPais.Where(mp => !mp.Raiz).ToArray();
            }

            foreach (var menu in arvoreMenus)
            {
                var menusFilhos = arvoreMenus.Where(m => m.EhPai(menu)).ToArray();

                if (menusFilhos.Count() > 0)
                    menu.AdicionarFilhos(menusFilhos);

                foreach (var menuFilho in menusFilhos)
                {
                    menuFilho.AtribuirPai(menu);
                }
            }

            return arvoreMenus.Where(m => m.Raiz).ToArray();
        }
    }
}
