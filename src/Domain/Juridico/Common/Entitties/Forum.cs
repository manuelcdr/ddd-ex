using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Enderecos.ValueObjects;

namespace PGLaw.Domain.Juridico.Common.Entitties
{
    public class Forum : DefaultEntity<Forum, int>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }

        public Endereco Endereco { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }

}
