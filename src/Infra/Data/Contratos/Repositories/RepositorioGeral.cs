using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Contratos.Context;


namespace PGLaw.Infra.Data.Contratos.Repositories
{
    public class ContratoRepositorioGeral : RepositoryBase, IContratoGlobalRepository
    {
        public ContratoRepositorioGeral(ContratoContext context)
            : base(context) { }
    }
}
