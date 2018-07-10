using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Application.Juridico.Interfaces.Services
{
    public interface IAppServices
    {
        IEnumerable<TModel> ObterTodos<TModel>();
        TModel ObterModel<TModel>(object id);
    }
}
