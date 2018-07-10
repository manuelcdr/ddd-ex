using System;
using System.Collections.Generic;

namespace PGLaw.Application.Sistema.Interfaces.Services
{
    public interface IAppServiceCrudRead<TModel>
    {
        TModel ObterPorId(Guid id);
        IEnumerable<TModel> ObterTodos();
    }

    public interface IAppServiceCrudWrite<TModel>
    {
        void Adicionar(TModel model);
        void Atualizar(TModel model);
        void Excluir(Guid id);
    }

    public interface IAppServiceCrud<TModel> : IAppServiceCrudRead<TModel>, IAppServiceCrudWrite<TModel>
    {
    }
}
