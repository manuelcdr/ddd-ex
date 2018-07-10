using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using PGLaw.Infra.Cross.AspNetMvc.Extensions;
using System.Threading.Tasks;

namespace PGLaw.Infra.Cross.AspNetMvc.Authorizations
{
    public class RequisicaoAjaxHandler : AuthorizationHandler<AutorizacaoPorUrl>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AutorizacaoPorUrl requirement)
        {
            var authFilterCtx = context.Resource as AuthorizationFilterContext;
            var httpContext = authFilterCtx.HttpContext;

            if (httpContext.Request.IsAjaxRequest())
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
