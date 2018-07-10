using Microsoft.AspNetCore.Mvc;
using PGLaw.Infra.Cross.Identity.Interfaces;
using System;


namespace PGLaw.Presentation.WebContratos.ViewComponents
{
    public class ViewComponentBase : ViewComponent
    {
        protected readonly IUser Usuario;

        public ViewComponentBase(IUser usuario)
        {
            this.Usuario = usuario;
        }

        protected Guid UsuarioId => Usuario.Id;
    }
}
