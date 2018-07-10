using PGLaw.Domain.Core.ValueObjects;
using PGLaw.Infra.Cross.Common.Extensions;
using System;


namespace PGLaw.Domain.Juridico.Pessoas.Entities
{
    public class DadosPessoaJuridica : ValueObject<DadosPessoaJuridica>
    {
        protected DadosPessoaJuridica() { }

        public DadosPessoaJuridica(string cnpj)
        {
            AtribuirCNPJ(cnpj);
        }

        public DadosPessoaJuridica(string cnpj, string inscricaoEstadual, string inscricaoMunicipal, string razaoSocial, string emailFinanceiro)
        {
            AtribuirCNPJ(cnpj);

            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            RazaoSocial = razaoSocial;
            EmailFinanceiro = emailFinanceiro;
        }

        public string CNPJ { get; private set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string RazaoSocial { get; set; }
        public string EmailFinanceiro { get; set; }

        public void AtribuirCNPJ(string cnpj)
        {
            CNPJ = cnpj.ApenasNumeros();
        }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void Validar()
        {
            ValidarCNPJ();
            // TODO: implementar
        }

        public void ValidarCNPJ()
        {
            // TODO: implementar
        }
    }
}

