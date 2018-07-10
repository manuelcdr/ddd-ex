using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties.Relashionships
{
    public class ClienteMotivoAcionamento : RelashionshipEntity<ClienteMotivoAcionamento>
    {
        public Guid ClienteId { get; set; }
        public Guid MotivoAcionamentoId { get; set; }

        // relacionamentos
        public MotivoAcionamento MotivoAcionamento { get; set; }
        public Cliente Cliente { get; set; }
    }
}
