using FluentValidation;
using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Domain.Sistema.Entitties
{
    public class Menu : DefaultEntity<Menu>
    {
        protected Menu()
        {
            MenuNivelDeAcesso = new List<MenuNivelDeAcesso>();
            MenusFilhos = new List<Menu>();
        }

        public Menu(Guid id, string titulo, string url, int ordem, Guid? menuPaiId) 
            : this()
        {
            Id = id;
            Titulo = titulo;
            Url = url;
            Ordem = ordem;
            MenuPaiId = menuPaiId;
        }

        public Guid? MenuPaiId { get; private set; }
        public virtual Menu MenuPai { get; private set; }
        public string Titulo { get; set; }
        public string CaminhoAcesso { get; private set; }
        public string CaminhoAcessoIds { get; private set; }
        public int Ordem { get; set; }
        public string Url { get; set; }

        public bool Raiz => !MenuPaiId.HasValue;
        public bool Ferramenta => !string.IsNullOrEmpty(Url);

        // relacionamentos
        public virtual ICollection<MenuNivelDeAcesso> MenuNivelDeAcesso { get; set; }
        public virtual ICollection<Menu> MenusFilhos { get; private set; }


        // metodos
        public bool EhFilho(Menu menu)
        {
            return menu.MenuPaiId == this.Id;
        }

        public bool EhPai(Menu menu)
        {
            return this.MenuPaiId == menu.Id;
        }

        private static void MontarCaminhoDeAcesso(Menu menu, Menu menuPai)
        {
            if (menu.MenuPaiId.HasValue)
            {
                menu.CaminhoAcesso = 
                    menuPai.Raiz ? 
                    menuPai.Titulo : 
                    $"{menuPai.CaminhoAcesso} > {menuPai.Titulo}";

                menu.CaminhoAcessoIds =
                    menuPai.Raiz ?
                    menuPai.Id.ToString() : 
                    $"{menuPai.CaminhoAcessoIds} > {menuPai.Id}";
            }
        }

        public Menu GerarFilho(string titulo, string url, int ordem)
        {
            var id = SequentialGuidGenerator.Generate();
            var menuFilho = new Menu(id, titulo, url, ordem, Id);
            menuFilho.AtribuirPai(this);
            MontarCaminhoDeAcesso(menuFilho, this);
            return menuFilho;
        }

        public void AtribuirPai(Menu menuPai)
        {
            if (menuPai != null)
            {
                MenuPaiId = menuPai.Id;
                MenuPai = menuPai;
            }
        }

        public void AdicionarFilhos(params Menu[] menusFilhos)
        {
            foreach(var menu in menusFilhos)
            {
                MenusFilhos.Add(menu);
            }
        }

        #region validações

        public bool EhValido(TipoMenu tipoMenu)
        {
            Validar();

            switch (tipoMenu)
            {
                case TipoMenu.Acesso:
                    ValidarMenuDeAcesso();
                    break;
                case TipoMenu.Ferramenta:
                    ValidarMenuFerramenta();
                    break;
                case TipoMenu.Raiz:
                    ValidarMenuRaiz();
                    break;
            }

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public override bool EhValido()
        {
            // deve usar o validador com tipoDeMenu
            return false;
        }

        protected void Validar()
        {
            RuleFor(m => m.Titulo)
                .NotEmpty().WithMessage("O menu deve possuir um Titulo");
        }

        private void ValidarMenuFerramenta()
        {
            RuleFor(m => m.Url)
                .NotEmpty().WithMessage("Menu ferramenta deve possuir uma url de acesso");
        }

        private void ValidarMenuDeAcesso()
        {
            RuleFor(m => m.MenuPaiId)
                .NotNull().WithMessage("Menu de acesso deve ter um menu pai");
        }

        private void ValidarMenuRaiz()
        {
            RuleFor(m => m.MenuPaiId)
                .Null().WithMessage("Menu raiz não deve possuir um menu pai");
        }

        public enum TipoMenu
        {
            Raiz,
            Acesso,
            Ferramenta
        }

        #endregion
    }

    
}

