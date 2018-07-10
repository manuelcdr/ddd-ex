using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class AreaOfensora : TipoDesativavelEntity<AreaOfensora>
    {
        protected AreaOfensora() { }

        public AreaOfensora(Guid id, Guid familiaOfensoraId, string descricao)
            :base(id, descricao)
        {
            FamiliaOfensoraId = familiaOfensoraId;
        }

        public Guid FamiliaOfensoraId { get; set; }

        // relacionamentos
        public FamiliaOfensora FamiliaOfensora { get; set; }
        public ICollection<ClienteAreaOfensora> ClienteAreaOfensora { get; set; }
    }
}
