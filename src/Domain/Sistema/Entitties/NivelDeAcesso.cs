using FluentValidation;
using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Entitties
{
    public class NivelDeAcesso : DefaultEntity<NivelDeAcesso>
    {
        protected NivelDeAcesso()
        {
            UsuarioNivelDeAcesso = new List<UsuarioNivelDeAcesso>();
            MenuNivelDeAcesso = new List<MenuNivelDeAcesso>();
        }

        public NivelDeAcesso(Guid id, string nome, string detalhes)
            : this()
        {
            Id = id;
            Nome = nome;
            Detalhes = detalhes;
        }

        public string Nome { get; set; }
        public string Detalhes { get; set; }

        public virtual ICollection<UsuarioNivelDeAcesso> UsuarioNivelDeAcesso { get; set; }
        public virtual ICollection<MenuNivelDeAcesso> MenuNivelDeAcesso { get; set; }

        
        public void AdicionarMenu(params Menu[] menus)
        {
            foreach(var menu in menus)
            {
                var menuNivel = new MenuNivelDeAcesso(menu.Id, this.Id);
                MenuNivelDeAcesso.Add(menuNivel);
            }
        }

        public void AdicionarMenu(params Guid[] menusIds)
        {
            foreach (var menuId in menusIds)
            {
                MenuNivelDeAcesso.Add(new MenuNivelDeAcesso(menuId, this.Id));
            }
        }

        public void AdicionarUsuario(params Guid[] usuariosIds)
        {
            foreach (var usuarioId in usuariosIds)
            {
                UsuarioNivelDeAcesso.Add(new UsuarioNivelDeAcesso(usuarioId, this.Id));
            }
        }

        public override bool EhValido()
        {
            Validar();
            Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nivel de Acesso deve possuir um nome");

            RuleFor(x => x.Detalhes)
                .NotEmpty().WithMessage("Informe os Detalhes do Nivel de Acesso");
        }
    }
}

