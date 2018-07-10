using Microsoft.AspNetCore.Mvc.Filters;

namespace PGLaw.Apresentacao.WebContratos.Attributes
{
    public class CustomAuthorizeAttribute : IAuthorizationFilter
    {
        public CustomAuthorizeAttribute() : base()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User.Claims;
        }

        //public override bool Match(object obj)
        //{
        //    return base.Match(obj);
        //}

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    if (filterContext.HttpContext.Request.IsAuthenticated)
        //    {
        //        filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
        //    }
        //    else
        //    {
        //        base.HandleUnauthorizedRequest(filterContext);
        //    }
        //}

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    if (!base.AuthorizeCore(httpContext))
        //        return false;

        //    var email = httpContext.User.Identity.Name;
        //    var url = httpContext.Request.RawUrl;

        //    if (url == "/")
        //        return true;

        //    var service = InstanceFactory.GetInstance<IUsuarioAppServices>();

        //    if (!service.MenuExiste(url))
        //        return true;

        //    return service.UsuarioPodeAcessarUrl(email, url);
        //}


    }
}