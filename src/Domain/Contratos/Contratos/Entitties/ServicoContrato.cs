using PGLaw.Domain.Contratos.Contratos.ValueObjects;
using PGLaw.Domain.Core.Entities;
using System;

namespace PGLaw.Domain.Contratos.Contratos.Entitties
{
    public class ServicoContrato : DefaultEntity<ServicoContrato>
    {
        protected ServicoContrato() { }

        public ServicoContrato(Guid contratoId)
        {
            ContratoId = contratoId;

        }

        public ServicoContrato(Guid id, Guid contratoId, Guid tiposervicoId, Guid formapagamentoId, decimal? valor = null, string observacao = null)
        {
            Id = id;
            ContratoId = contratoId;
            TipoServicoId = tiposervicoId;
            FormaPagamentoId = formapagamentoId;
            Valor = valor;
            Observacao = observacao;
        }

        public Guid ContratoId { get; set; }
        public Guid TipoServicoId { get; set; }
        public Guid FormaPagamentoId { get; set; }
        public decimal? Valor { get; set; }
        public string Observacao { get; set; }

        //public Contrato Contrato { get; set; }
        public TipoServico TipoServico { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public Contrato Contrato { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}