using FluentValidation;
using PGLaw.Domain.Core.ValueObjects;
using PGLaw.Infra.Cross.Common.Extensions;
using PGLaw.Infra.Cross.Common.Validators;
using System;

namespace PGLaw.Domain.Juridico.Pessoas.Entities
{
    public class DadosPessoaFisica : ValueObject<DadosPessoaFisica>
    {
        protected DadosPessoaFisica() { }

        public DadosPessoaFisica(string cpf)
        {
            AtribuirCPF(cpf);
        }

        public DadosPessoaFisica(string cpf, string rg, string orgaoEmissorRG, string celular, string telefoneComercial, DateTime? dataNascimento)
        {
            AtribuirCPF(cpf);
            AtribuirRG(rg);
            AtribuirCelular(celular);
            AtribuirTelefoneComercial(telefoneComercial);

            OrgaoEmissorRG = orgaoEmissorRG;
            DataNascimento = dataNascimento;
        }

        public string CPF { get; private set; }
        public string RG { get; private set; }
        public string OrgaoEmissorRG { get; set; }
        public string Celular { get; private set; }
        public string TelefoneComercial { get; private set; }
        public DateTime? DataNascimento { get; set; }

        public void AtribuirCPF(string cpf)
        {
            CPF = cpf.ApenasNumeros();
        }

        public void AtribuirRG(string rg)
        {
            RG = rg.ApenasNumeros();
        }

        public void AtribuirCelular(string celular)
        {
            Celular = celular.ApenasNumeros();
        }

        public void AtribuirTelefoneComercial(string telefoneComercial)
        {
            TelefoneComercial = telefoneComercial.ApenasNumeros();
        }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void Validar()
        {
            ValidarCPF();
        }

        public void ValidarCPF()
        {
            if (!string.IsNullOrEmpty(CPF))
            {
                RuleFor(p => p.CPF)
                .Must(numero => ValidadorDeCPF.Validar(numero)).WithMessage("Cpf inválido");
            }
        }
    }
}
