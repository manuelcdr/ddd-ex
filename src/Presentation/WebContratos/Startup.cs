using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PGLaw.Infra.Cross.Identity.Data;
using PGLaw.Presentation.WebContratos.Configurations;
using AutoMapper;
using PGLaw.Infra.Cross.AspNetMvc.Authorizations;

namespace PGLaw.Presentation.WebContratos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddRouting();

            services.AddSession();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AcessoUrl", policy =>
                {
                    policy.RequireAuthenticatedUser()
                    .AddRequirements(new AutorizacaoPorUrl());
                });
            });

            //// require HTTPS
            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});

            // Options para configurações customizadas
            services.AddOptions();

            // MVC com adições de filtros de ações.
            services.AddMvc(options =>
            {
                // exemplo
                //options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalActionLogger)));
            });

            // Segurança
            services.AddMvcSecurity();

            // AutoMapper
            services.AddAutoMapper(
                typeof(Application.Sistema.AutoMapper.AutoMapperProfile),
                typeof(Application.Contratos.AutoMapper.AutoMapperProfile));

            // Registrar todas as Inversões de Dependência
            services.AddDIConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            //var options = new RewriteOptions().AddRedirectToHttps();

            //app.UseRewriter(options);

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}