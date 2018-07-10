using AutoMapper;
using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Pessoas
{
    public class ClienteVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Required]
        [Display(Name = "Segmento Jurídico")]
        public string Segmento { get; set; }

        [Required]
        [Display(Name = "Área de Atuação")]
        public string Atuacao { get; set; }

        [Required]
        [Display(Name = "UF")]
        public string UF { get; set; }

        public PessoaVM Pessoa { get; set; }


        #region operadores

        public static implicit operator ClientePessoaFisicaVM(ClienteVM d)
        {
            return Mapper.Map<ClientePessoaFisicaVM>(d);
        }

        public static implicit operator ClienteVM(ClientePessoaFisicaVM d)
        {
            return Mapper.Map<ClienteVM>(d);
        }

        public static implicit operator ClientePessoaJuridicaVM(ClienteVM d)
        {
            return Mapper.Map<ClientePessoaJuridicaVM>(d);
        }

        public static implicit operator ClienteVM(ClientePessoaJuridicaVM d)
        {
            return Mapper.Map<ClienteVM>(d);
        }

        #endregion
    }
}
