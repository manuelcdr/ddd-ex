using System;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class PedidoVM
    {
        public Guid TipoId { get; set; }
        public Guid? RiscoId { get; set; }
        public Guid? CausaRealId { get; set; }
        public Guid ProcessoId { get; set; }
        public int? ResultadoId { get; set; }

        public decimal ValorPedido { get; set; }
        public decimal ValorProvisao { get; set; }
        public decimal ValorResultado { get; set; }

        public string Risco { get; set; }
        public string CausaReal { get; set; }
        public string Tipo { get; set; }
    }
}
