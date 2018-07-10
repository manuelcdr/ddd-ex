using System.ComponentModel.DataAnnotations;
using PGLaw.Infra.Cross.Common.Enums;
using System;
using PGLaw.Infra.Cross.Common.Utils;

namespace PGLaw.Application.Contratos.Models.Pessoas
{
    public class PessoaVM
    {
        public PessoaVM()
        {
            Id = SequentialGuidGenerator.Generate();
            DadosPessoaFisica = new DadosPessoaFisicaVM();
            DadosPessoaJuridica = new DadosPessoaJuridicaVM();
        }

        public Guid Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Tipo Pessoa")]
        public TipoPessoa TipoPessoa { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Site")]
        public string Url { get; set; }
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string Documento
        {
            get
            {
                if (TipoPessoa == TipoPessoa.Fisica)
                {
                    return DadosPessoaFisica.CPF;
                }
                else if (TipoPessoa == TipoPessoa.Juridica)
                {
                    return DadosPessoaJuridica.CNPJ;
                }
                return null;
            }
            set
            {
                if (TipoPessoa == TipoPessoa.Fisica)
                {
                    DadosPessoaFisica.CPF = value;
                } else if (TipoPessoa == TipoPessoa.Juridica)
                {
                    DadosPessoaJuridica.CNPJ = value;
                }
            }
        }

        public DadosPessoaFisicaVM DadosPessoaFisica { get; set; }
        public DadosPessoaJuridicaVM DadosPessoaJuridica { get; set; }
    }
}
