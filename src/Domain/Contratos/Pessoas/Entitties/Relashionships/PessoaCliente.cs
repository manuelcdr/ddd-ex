using PGLaw.Domain.Core.Entities;
using System;


namespace PGLaw.Domain.Contratos.Pessoas.Entitties.Relashionships
{
    public class PessoaCliente : RelashionshipEntity<PessoaCliente>
    {
        public Guid PessoaId { get; set; }
        public Guid ClienteId { get; set; }

        public Pessoa Pessoa { get; set; }
        public Cliente Cliente { get; set; }
    }
}
