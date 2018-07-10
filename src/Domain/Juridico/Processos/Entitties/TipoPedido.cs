using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Processos.ValueObjects;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoPedido : TipoDesativavelEntity<TipoPedido>
    {
        public int JusticaId { get; set; }

        //relacionamentos
        public Justica Justica { get; set; }
    }
}
