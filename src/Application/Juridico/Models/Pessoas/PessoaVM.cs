using System.ComponentModel.DataAnnotations;
using PGLaw.Infra.Cross.Common.Enums;
using System;
using PGLaw.Infra.Cross.Common.Utils;
using AutoMapper;

namespace PGLaw.Application.Juridico.Models.Pessoas
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

        #region operadores

        public static implicit operator PessoaVM(PessoaFisicaVM d)
        {
            return Mapper.Map<PessoaVM>(d);
        }

        public static implicit operator PessoaFisicaVM(PessoaVM d)
        {
            return Mapper.Map<PessoaFisicaVM>(d);
        }

        public static implicit operator PessoaVM(PessoaJuridicaVM d)
        {
            return Mapper.Map<PessoaVM>(d);
        }

        public static implicit operator PessoaJuridicaVM(PessoaVM d)
        {
            return Mapper.Map<PessoaJuridicaVM>(d);
        }

        #endregion
    }
}
