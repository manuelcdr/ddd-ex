using PGLaw.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class FamiliaOfensora : TipoDesativavelEntity<FamiliaOfensora, Guid>
    {

        // relacionamentos
        public ICollection<AreaOfensora> AreasOfensoras { get; set; }
    }
}
