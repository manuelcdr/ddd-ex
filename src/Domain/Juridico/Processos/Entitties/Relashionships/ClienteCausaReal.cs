using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties.Relashionships
{
    public class ClienteCausaReal : RelashionshipEntity<ClienteCausaReal>
    {
        public Guid ClienteId { get; set; }
        public Guid CausaRealId { get; set; }

        // relacionamentos
        public CausaReal CausaReal { get; set; }
        public Cliente Cliente { get; set; }
    }
}
