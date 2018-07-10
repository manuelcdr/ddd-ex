using System;

namespace PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships
{
    public class EquipePessoa
    {
        public Guid EquipeId { get; set; }
        public Guid PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }
        public Equipe Equipe { get; set; }
    }
}
