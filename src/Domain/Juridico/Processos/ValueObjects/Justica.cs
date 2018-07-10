using PGLaw.Domain.Core.Entities;

namespace PGLaw.Domain.Juridico.Processos.ValueObjects
{
    public class Justica : TipoDesativavelEntity<Justica, int>
    {
        protected Justica() { }

        public Justica(int id, string descricao, string descricaoReduzida)
            : base(id, descricao)
        {
            DescricaoReduzida = descricaoReduzida;
        }

        public string DescricaoReduzida { get; set; }
    }
}
