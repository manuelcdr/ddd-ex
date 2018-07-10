using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties.Relashionships
{
    public class ClienteAreaOfensora : RelashionshipEntity<ClienteAreaOfensora>
    {
        public Guid ClienteId { get; set; }
        public Guid AreaOfensoraId { get; set; }

        // relacionamentos
        public AreaOfensora AreaOfensora { get; set; }
        public Cliente Cliente { get; set; }
    }
}
