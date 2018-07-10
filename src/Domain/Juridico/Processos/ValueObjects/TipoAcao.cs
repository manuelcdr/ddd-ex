using PGLaw.Domain.Core.Entities;

namespace PGLaw.Domain.Juridico.Processos.ValueObjects
{
    public class TipoAcao : TipoDesativavelEntity<TipoAcao, int>
    {
        protected TipoAcao() { }

        public TipoAcao(int id, int orgaoId, string descricao)
            : base(id, descricao)
        {
            OrgaoId = orgaoId;
        }

        public int OrgaoId { get; set; }

        // relacionamentos
        public Orgao Orgao { get; set; }
    }
}
