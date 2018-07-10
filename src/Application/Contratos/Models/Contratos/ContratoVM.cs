using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Contratos.Models.Contratos
{
    public class ContratoVM
    {

        //public ContratoVM()
        //{
        //    Id = SequentialGuidGenerator.Generate();
        //}
        public Guid Id { get; set; }

        
        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }

        [Required]
        [Display(Name = "Razao Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo => DataAssinatura >= DateTime.Now;

        [Display(Name = "Clausula de Juros")]
        public bool ClausulaJuros { get; set; }

        [Display(Name = "Clausula de Multa")]
        public bool ClausulaMulta { get; set; }

        [Display(Name = "Juros")]
        public string Juros { get; set; }
        
        [Display(Name = "Multa")]
        public string Multa { get; set; }

        [Display(Name = "Data Assinatura")]
        public DateTime DataAssinatura { get; set; }

        [Display(Name = "Data Vencimento")]
        public DateTime? DataVencimento => CalculaDataVencimento();

        [Display(Name = "Gerência")]
        public Guid GerenciaId { get; set; }

        [Display(Name = "Indice de Reajuste")]
        public Guid IndiceReajusteId { get; set; }

        [Required]
        [Display(Name = "Objeto do Contrato")]
        public string Objeto { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public Guid TipoId { get; set; }

        [Display(Name = "Vigência")]
        public Guid VigenciaId { get; set; }        

        [Display(Name = "Status Contrato")]
        public string StatusContrato => VerificarStatus();

        [Display(Name = "Status Contrato")]
        public int StatusId { get; set; }

        public TipoVM Tipo { get; set; }
        public GerenciaVM Gerencia { get; set; }
        public IndiceReajusteVM IndiceReajuste { get; set; }
        public VigenciaVM Vigencia { get; set; }

        // relacionamentos
        public IList<ServicoContratoVM> ServicoContratos { get; set; }
        public IList<DocumentoContratoVM> DocumentoContratos { get; set; }

        private string VerificarStatus()
        {
            string status = string.Empty;

            if (StatusId == 1)
            {
                status = "Em Análise";
            }
            else
            {
                if (StatusId == 2)
                {
                    status = "Aprovado";
                }
            }


            //if (!DataVencimento.HasValue)
            //{
            //    status = "Indeterminado";
            //}
            //else
            //{
                if (DataVencimento < DateTime.Now.Date)
                {
                    status = "Vencido";
                }
                else
                {
                    if (DataVencimento < DateTime.Now.Date.AddDays(30))
                    {
                        status = "A Vencer";
                    }
                    else
                    {
                        if (DataVencimento == DateTime.Now.Date)
                        {
                            status = "Vence Hoje";
                        }
                    }
                }
            //}
            return status;
        }

        private DateTime? CalculaDataVencimento()
        {
            if(VigenciaId.ToString() == "00000001-0000-0000-0000-000000000000")
                return DataAssinatura.AddYears(1);
            if (VigenciaId.ToString() == "00000002-0000-0000-0000-000000000000")
                return DataAssinatura.AddYears(2);
            if (VigenciaId.ToString() == "00000003-0000-0000-0000-000000000000")
                return DataAssinatura.AddYears(3);
            if (VigenciaId.ToString() == "00000004-0000-0000-0000-000000000000")
                return DataAssinatura.AddYears(4);


            return null;
        }

    }
}