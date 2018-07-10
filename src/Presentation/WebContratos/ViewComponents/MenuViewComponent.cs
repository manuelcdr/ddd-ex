using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Sistema.Models;
using System.Threading.Tasks;

namespace PGLaw.Presentation.WebContratos.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(MenuVM menu)
        {
            return View(menu);
        }
    }
}