using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Services;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Services;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Enderecos.Interfaces;
using PGLaw.Domain.Juridico.Processos.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Processos.Interfaces.Services;
using PGLaw.Domain.Juridico.Processos.Services;
using PGLaw.Domain.Juridico.Processos.Validations;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using PGLaw.Domain.Sistema.Services;
using PGLaw.Infra.Cross.AspNetMvc.Authorizations;
using PGLaw.Infra.Cross.Identity.Interfaces;
using PGLaw.Infra.Cross.Identity.Models;
using PGLaw.Infra.Cross.Identity.Services;
using PGLaw.Infra.Data.Juridico.Context;
using PGLaw.Infra.Data.Juridico.Repositories;
using PGLaw.Infra.Data.Sistema.Context;
using PGLaw.Infra.Data.Sistema.Repositories;
using PGLaw.Application.Contratos.Interfaces.Services;
using PGLaw.Application.Contratos.Services;
using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Repositories;
using PGLaw.Infra.Data.Contratos.Context;
using PGLaw.Infra.Data.Contratos.Repositories;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Services;
using PGLaw.Domain.Contratos.Contratos.Services;
using PGLaw.Domain.Contratos.Contratos.Validations;

namespace PGLaw.Infra.Cross.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationHandler, RequisicaoAjaxHandler>();
            services.AddSingleton<IAuthorizationHandler, TrocarSenhaHandler>();
            services.AddSingleton<IAuthorizationHandler, TemAcessoUrlHandler>();
            services.AddSingleton<IAuthorizationHandler, NaoTemAcessoHandler>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // AppServices
            services.AddScoped<IControleDeAcessoAppServices, ControleDeAcessoAppServices>();
            services.AddScoped<ISistemaAppServices, SistemaAppServices>();
            services.AddScoped<IProcessosAppServices, ProcessosAppServices>();
            services.AddScoped<IContratosAppServices, ContratosAppServices>();
            services.AddScoped<IAuxiliaresAppServices, AuxiliaresAppServices>();
            services.AddScoped<Application.Juridico.Interfaces.Services.IPessoasAppServices, Application.Juridico.Services.PessoasAppServices>();
            services.AddScoped<Application.Contratos.Interfaces.Services.IPessoasAppServices, Application.Contratos.Services.PessoasAppServices>();


            // DomainServices
            services.AddScoped<IMenuServices, MenuServices>();
            services.AddScoped<INivelDeAcessoServices, NivelDeAcessoServices>();
            services.AddScoped<IMontagemDeMenusServices, MontagemDeMenusServices>();
            services.AddScoped<IDadosIniciaisServices, DadosIniciaisServices>();
            services.AddScoped<IControlarAcessoUsuarioServices, ControlarAcessoUsuarioServices>();
            services.AddScoped<ICadastroProcessoServices, CadastroProcessoServices>();
            services.AddScoped<ICadastroContratoServices, CadastroContratoServices>();
            services.AddScoped<IAuxiliaresServices, AuxiliaresServices>();
            services.AddScoped<Domain.Juridico.Pessoas.Interfaces.Services.IManterPessoasServices, Domain.Juridico.Pessoas.Services.ManterPessoasServices>();
            services.AddScoped<Domain.Contratos.Pessoas.Interfaces.Services.IManterPessoasServices, Domain.Contratos.Pessoas.Services.ManterPessoasServices>();

            // Contexts
            services.AddScoped<SistemaContext>();
            services.AddScoped<JuridicoContext>();
            services.AddScoped<ContratoContext>();

            // Repositorios de Sistema
            services.AddScoped<ISistemaUnitOfWork, SistemaUnitOfWork>();
            services.AddScoped<ISistemaGlobalRepository, SistemaRepositorioGeral>();
            services.AddScoped<ISistemaCQRS, SistemaRepositorioGeral>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IUsuariosRepositoryCQRS, UsuariosRepository>();


            // Repositorios de Juridico
            services.AddScoped<IJuridicoUnitOfWork, JuridicoUnitOfWork>();
            services.AddScoped<IJuridicoCQRS, JuridicoRepositorioGeral>();
            services.AddScoped<IJuridicoGlobalRepository, JuridicoRepositorioGeral>();
            services.AddScoped<IProcessosRepository, ProcessosRepository>();
            services.AddScoped<IProcessosRepositoryCQRS, ProcessosRepository>();
            services.AddScoped<Domain.Juridico.Pessoas.Interfaces.Repositories.IPessoasRepository, Infra.Data.Juridico.Repositories.PessoasRepository>();
            services.AddScoped<Domain.Juridico.Pessoas.Interfaces.Repositories.IPessoasRepositoryCQRS, Infra.Data.Juridico.Repositories.PessoasRepository>();
            services.AddScoped<IEnderecosRepository, EnderecosRepository>();
            services.AddScoped<IEnderecosRepositoryCQRS, EnderecosRepository>();

            // Repositorios de Contratos
            services.AddScoped<IContratoUnitOfWork, ContratoUnitOfWork>();
            services.AddScoped<IContratoCQRS, ContratoRepositorioGeral>();
            services.AddScoped<IContratoGlobalRepository, ContratoRepositorioGeral>();
            services.AddScoped<IContratosRepository, ContratosRepository>();
            services.AddScoped<IContratosRepositoryCQRS, ContratosRepository>();
            services.AddScoped<Domain.Contratos.Pessoas.Interfaces.Repositories.IPessoasRepository, Infra.Data.Contratos.Repositories.PessoasRepository>();
            services.AddScoped<Domain.Contratos.Pessoas.Interfaces.Repositories.IPessoasRepositoryCQRS, Infra.Data.Contratos.Repositories.PessoasRepository>();


            // validadores
            services.AddTransient<Domain.Juridico.Pessoas.Validations.PessoaValidator>();
            services.AddTransient<Domain.Contratos.Pessoas.Validations.PessoaValidator>();
            services.AddTransient<ProcessoValidator>();
            services.AddTransient<ContratoValidator>();

            // Infra - Identity
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
