using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using PGLaw.Infra.Cross.AspNetMvc.Extensions;
using System.Linq;

namespace PGLaw.Infra.Cross.AspNetMvc.Middlewares
{
    public class AutorizacaoDeUrl : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var podeAcessar = true;

            if (!context.Request.Path.HasValue)
                podeAcessar = false;

            var path = context.Request.Path.Value;

            if (path.Trim() != "/")
            {
                if (!ContemAcesso(context, path))
                    podeAcessar = false;
            }

            if (podeAcessar)
            {
                await next(context);
            }

            return;
        }

        private string UrlDeAcesso(string url)
        {
            return $"/{url.Split('/')[1]}";
        }

        private bool ContemAcesso(HttpContext context, string url)
        {
            var menusAcessiveis = context.Session.Get<string[]>("MenusAcessiveis");
            return menusAcessiveis.Any(menu => menu.ToLower() == UrlDeAcesso(url).ToLower());
        }
    }
}
