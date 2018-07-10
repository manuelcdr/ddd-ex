using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class Pedido : DefaultEntity<Pedido>
    {
        protected Pedido() { }

        public Pedido(Guid processoId, Guid tipoId, Guid riscoId, decimal valorPedido, decimal valorProvisao)
        {
            ProcessoId = processoId;
            TipoId = tipoId;
            RiscoId = riscoId;
            ValorPedido = valorPedido;
            ValorProvisao = valorProvisao;
        }

        public Pedido(
            Guid processoId, 
            Guid tipoId, 
            Guid? riscoId = null,
            int? resultadoId = null,
            Guid? causaRealId = null, 
            decimal? valorPedido = null, 
            decimal? valorProvisao = null, 
            decimal? valorResultado = null)
        {
            TipoId = tipoId;
            ResultadoId = resultadoId;
            RiscoId = riscoId;
            CausaRealId = causaRealId;
            ProcessoId = processoId;
            ValorPedido = valorPedido;
            ValorProvisao = valorProvisao;
            ValorResultado = valorResultado;
        }

        public Guid ProcessoId { get; set; }
        public Guid TipoId { get; set; }
        public Guid? RiscoId { get; set; }
        public Guid? CausaRealId { get; set; }
        public int? ResultadoId { get; set; }

        public decimal? ValorPedido { get; set; }
        public decimal? ValorProvisao { get; set; }
        public decimal? ValorResultado { get; set; }

        // relacionamentos
        public TipoPedido Tipo { get; set; }
        public Risco Risco { get; set; }
        public ResultadoPedido Resultado { get; set; }
        public CausaRealPedido CausaReal { get; set; }
        public Processo Processo { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
