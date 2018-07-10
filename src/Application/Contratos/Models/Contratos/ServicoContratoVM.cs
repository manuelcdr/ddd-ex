using System;

namespace PGLaw.Application.Contratos.Models.Contratos
{
    public class ServicoContratoVM
    {
        public Guid Id { get; set; }

        public Guid ContratoId { get; set; }
        public Guid TipoServicoId { get; set; }
        public Guid FormaPagamentoId { get; set; }

        public decimal? Valor { get; set; }
        public string Observacao { get; set; }

        public TipoServicoVM TipoServico { get; set; }
        public FormaPagamentoVM FormaPagamento { get; set; }
    }
}