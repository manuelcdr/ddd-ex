using PGLaw.Domain.Core.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Processos.Entitties;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Processos.Interfaces.Repositories
{
    public interface IProcessosRepository : IRepositoryFull<Processo>
    {
        IEnumerable<ProcessoPrazo> ObterPrazosDoProcesso(Guid processoId);
    }
}
