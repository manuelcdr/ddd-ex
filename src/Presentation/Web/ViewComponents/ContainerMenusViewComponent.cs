using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Infra.Cross.Identity.Interfaces;
using System.Threading.Tasks;

namespace PGLaw.Presentation.Web.ViewComponents
{
    public class ContainerMenusViewComponent : ViewComponentBase
    {
        private readonly IControleDeAcessoAppServices _controleDeAcessoServices;

        public ContainerMenusViewComponent(IUser usuario, IControleDeAcessoAppServices controleAcessoServices)
            : base(usuario)
        {
            _controleDeAcessoServices = controleAcessoServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _controleDeAcessoServices.ObterArvoreDeAcessoPorUsuario(Usuario.Id);
            return View(model);
        }

    }
}
