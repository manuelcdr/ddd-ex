using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Sistema.Context;

namespace PGLaw.Infra.Data.Juridico.Repositories
{
    public class SistemaRepositorioGeral : RepositoryBase, ISistemaGlobalRepository, ISistemaCQRS
    {
        public SistemaRepositorioGeral(SistemaContext context): base(context) { }
    }
}
