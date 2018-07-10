using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Contratos.Contratos.Entitties
{
    public class Contrato : DefaultEntity<Contrato>
    {

        protected Contrato()
        {
            DocumentoContratos = new List<DocumentoContrato>();
            ServicoContratos = new List<ServicoContrato>();
        }

        public Contrato(Guid clienteId, string razaoSocial, bool ativo, DateTime dataAssinatura, DateTime dataVencimento, string objeto, Guid tipoId, Guid gerenciaId, Guid vigenciaId, Guid indiceReajusteId, bool clausulaJuros, string juros, bool clausulaMulta, string multa, int statusId)
        {
            ClienteId = clienteId;
            RazaoSocial = razaoSocial;
            Ativo = ativo;
            DataAssinatura = dataAssinatura;
            DataVencimento = dataVencimento;
            Objeto = objeto;
            TipoId = tipoId;
            GerenciaId = gerenciaId;
            VigenciaId = vigenciaId;
            IndiceReajusteId = indiceReajusteId;
            ClausulaJuros = clausulaJuros;
            Juros = juros;
            ClausulaMulta = clausulaMulta;
            Multa = multa;
            StatusId = statusId;
        }


        public Guid ClienteId { get; set; }
        public string RazaoSocial { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAssinatura { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string Objeto { get; set; }
                
        public Guid TipoId { get; set; }
        public Guid GerenciaId { get; set; }
        public Guid VigenciaId { get; set; }
        public Guid IndiceReajusteId { get; set; }
        public bool ClausulaJuros { get; set; }
        public string Juros { get; set; }
        public bool ClausulaMulta { get; set; }
        public string Multa { get; set; }
        public int StatusId { get; set; }

        public Tipo Tipo { get; set; }
        public Gerencia Gerencia { get; set; }
        public Vigencia Vigencia { get; set; }
        public IndiceReajuste IndiceReajuste { get; set; }

        public List<DocumentoContrato> DocumentoContratos { get; set; }
        public List<ServicoContrato> ServicoContratos { get; set; }
        // relacionamentos
        //public ICollection<DocumentoContrato> DocumentosContrato { get; set; }

        public void AdicionarServicooNoContrato(ServicoContrato servicoContrato)
        {
            ServicoContratos.Add(servicoContrato);
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}
