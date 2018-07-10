using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Juridico.Enderecos.Entitties;
using PGLaw.Domain.Juridico.Enderecos.Interfaces;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Juridico.Context;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Infra.Data.Juridico.Repositories
{
    public class EnderecosRepository : RepositoryBase, IEnderecosRepository
    {
        public EnderecosRepository(JuridicoContext context) : base(context)
        {
        }

        public IEnumerable<Cidade> ObterCidadesPorEstado(int estadoId)
        {
            return Set<Cidade>()
                .Where(x => x.EstadoId == estadoId)
                .AsNoTracking();
        }
    }
}
