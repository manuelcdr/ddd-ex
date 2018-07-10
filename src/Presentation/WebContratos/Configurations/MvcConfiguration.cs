using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PGLaw.Infra.Cross.Identity.Data;
using PGLaw.Infra.Cross.Identity.Models;
using System;

namespace PGLaw.Presentation.WebContratos.Configurations
{
    public static class MvcConfiguration
    {
        public static void AddMvcSecurity(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            // Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Autorizações
            services.AddAuthorization(options =>
            {
                // exemplo 
                //options.AddPolicy("PodeLerEventos", policy => policy.RequireClaim("Eventos", "Ler"));
                //options.AddPolicy("PodeGravar", policy => policy.RequireClaim("Eventos", "Gravar"));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "PGLawPresentationWebContratos";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Usuario/Login";
            });

        }
    }
}
