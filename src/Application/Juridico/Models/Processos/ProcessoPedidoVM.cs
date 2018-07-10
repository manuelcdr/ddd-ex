using System;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class ProcessoPedidoVM
    {
        public Guid TipoId { get; set; }
        public Guid RiscoId { get; set; }

        public decimal ValorPedido { get; set; }
        public decimal ValorProvisao { get; set; }
    }
}
