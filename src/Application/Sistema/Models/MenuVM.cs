using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Sistema.Models
{
    public class MenuVM
    {
        public MenuVM()
        {
            Id = SequentialGuidGenerator.Generate();
            MenusFilhos = new List<MenuVM>();
        }

        public Guid Id { get; set; }

        public Guid? MenuPaiId { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Url { get; set; }

        protected MenuTipo tipo;
        public MenuTipo Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value;
                switch (value)
                {
                    case MenuTipo.Acesso:
                        Ferramenta = false;
                        Raiz = false;
                        break;
                    case MenuTipo.Raiz:
                        Ferramenta = false;
                        Raiz = true;
                        break;
                    case MenuTipo.Ferramenta:
                        Ferramenta = true;
                        Raiz = false;
                        break;
                }
            }
        }
        public string MenuPaiTitulo { get; set; }
        public string CaminhoAcesso { get; set; }
        public bool Ferramenta { get; set; }
        public bool Raiz { get; set; }
        public int Ordem { get; set; }
        public IList<MenuVM> MenusFilhos { get; set; }

        public MenuVM MenuPai { get; set; }

        public void DefinirTipo(MenuTipo tipo)
        {
            Tipo = tipo;
        }
    }

    public class MenuFerramentaVM : MenuVM
    {
        [Required]
        public string Url { get; set; }
    }

    public enum MenuTipo
    {
        Raiz,
        Ferramenta,
        Acesso
    }
}
