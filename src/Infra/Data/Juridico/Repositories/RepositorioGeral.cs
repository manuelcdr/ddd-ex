using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Juridico.Context;

namespace PGLaw.Infra.Data.Juridico.Repositories
{
    public class JuridicoRepositorioGeral : RepositoryBase, IJuridicoGlobalRepository
    {
        public JuridicoRepositorioGeral(JuridicoContext context)
            : base(context) { }
    }
}
