using System;

namespace PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships
{
    public class EquipeCliente
    {
        public Guid EquipeId { get; set; }
        public Guid ClienteId { get; set; }

        public Cliente Cliente { get; set; }
        public Equipe Equipe { get; set; }
    }
}
