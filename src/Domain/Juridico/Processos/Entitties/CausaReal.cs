using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class CausaReal : TipoDesativavelEntity<CausaReal>
    {
        // relacionamentos
        public ICollection<ClienteCausaReal> ClienteCausaReal { get; set; }
    }
}
