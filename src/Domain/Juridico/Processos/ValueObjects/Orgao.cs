using PGLaw.Domain.Core.Entities;

namespace PGLaw.Domain.Juridico.Processos.ValueObjects
{
    public class Orgao : TipoDesativavelEntity<Orgao, int>
    {
        protected Orgao() { }

        public Orgao(int id, int justicaId, string descricao, string descricaoReduzida)
            : base(id, descricao)
        {
            JusticaId = justicaId;
            DescricaoReduzida = descricaoReduzida;
        }

        public int JusticaId { get; set; }
        public string DescricaoReduzida { get; set; }

        // relacionamentos
        public Justica Justica { get; set; }

    }
}
