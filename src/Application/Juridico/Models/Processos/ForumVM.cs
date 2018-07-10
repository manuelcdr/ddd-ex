using PGLaw.Application.Juridico.Models.Common;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class ForumVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }

        public EnderecoVM Endereco { get; set; }
    }
}
