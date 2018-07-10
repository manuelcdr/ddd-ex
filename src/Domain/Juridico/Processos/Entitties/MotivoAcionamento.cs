using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class MotivoAcionamento : TipoDesativavelEntity<MotivoAcionamento>
    {
        // relacionamentos
        public ICollection<ClienteMotivoAcionamento> ClienteMotivoAcionamento { get; set; }
    }
}
