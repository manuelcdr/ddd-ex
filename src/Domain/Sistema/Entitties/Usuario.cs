using FluentValidation;
using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Infra.Cross.Common.Enums;
using PGLaw.Infra.Cross.Common.Extensions;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Entitties
{
    public class Usuario : DefaultEntity<Usuario>
    {
        protected Usuario() { }

        public Usuario(Guid id, string email, DiasDaSemana acessoDiasDaSemana, bool trocarSenha, bool ativo)
        {
            Id = id;
            Email = email;
            AcessoDiasDaSemana = acessoDiasDaSemana;
            TrocarSenha = trocarSenha;
            Ativo = ativo;
        }

        public string Email { get; private set; }
        public DiasDaSemana AcessoDiasDaSemana { get; private set; }
        public bool TrocarSenha { get; private set; }
        public bool Ativo { get; private set; }

        public bool PodeAcessarHoje()
        {
            var hoje = DateTime.Today.DayOfWeek.ConverterParaDiasDaSemana();
            return AcessoDiasDaSemana.HasFlag(hoje);
        }

        public void AtribuirAcessoDiasDaSemana(DiasDaSemana diasDaSemana)
        {
            AcessoDiasDaSemana = diasDaSemana;
        }

        public void DesabilitarAcessoFinalDeSemana()
        {
            AcessoDiasDaSemana &= ~(DiasDaSemana.Sabado & ~DiasDaSemana.Domingo);
        }

        public void HabilitarAcessoDiasUteisSemana()
        {
            AcessoDiasDaSemana = DiasDaSemana.Segunda | DiasDaSemana.Terca | DiasDaSemana.Quarta | DiasDaSemana.Quinta | DiasDaSemana.Sexta;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        // relacionamentos
        public virtual ICollection<UsuarioNivelDeAcesso> UsuarioNivelDeAcesso { get; set; }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("informe um email")
                .NotNull().WithMessage("informe um email")
                .EmailAddress().WithMessage("informe um email valido");
        }
    }
}
