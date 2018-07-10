using PGLaw.Domain.Juridico.Enderecos.Entitties;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Enderecos.Interfaces
{
    public interface IEnderecosRepository : IEnderecosRepositoryCQRS
    {

    }

    public interface IEnderecosRepositoryCQRS
    {
        IEnumerable<Cidade> ObterCidadesPorEstado(int estadoId);
    }
}
