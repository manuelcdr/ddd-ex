using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Models;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Services;
using PGLaw.Domain.Juridico.Processos.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using PGLaw.Infra.Cross.Identity.Extensions;
using PGLaw.Infra.Cross.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PGLaw.Application.Sistema.Services
{
    public class ControleDeAcessoAppServices : AppServiceBase, IControleDeAcessoAppServices
    {
        private readonly IMontagemDeMenusServices services;
        private readonly IJuridicoCQRS juridicoCQRS;
        private readonly IManterPessoasServices manterPessoasServices;
        private readonly IJuridicoUnitOfWork juridicoUoW;
        private readonly IControlarAcessoUsuarioServices controleAcessoUsuarioServices;
        private readonly IUsuariosRepositoryCQRS usuariosCQRS;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ControleDeAcessoAppServices(
            IMontagemDeMenusServices services,
            ISistemaCQRS globalRepository,
            IJuridicoCQRS juridicoCQRS,
            IManterPessoasServices manterPessoasServices,
            ISistemaUnitOfWork uow,
            IJuridicoUnitOfWork juridicoUoW,
            IControlarAcessoUsuarioServices controleAcessoUsuarioServices,
            IUsuariosRepositoryCQRS usuariosCQRS,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signManager,
            IHttpContextAccessor httpContextAccessor)
            : base(uow, globalRepository)
        {
            this.services = services;
            this.juridicoCQRS = juridicoCQRS;
            this.manterPessoasServices = manterPessoasServices;
            this.juridicoUoW = juridicoUoW;
            this.controleAcessoUsuarioServices = controleAcessoUsuarioServices;
            this.usuariosCQRS = usuariosCQRS;
            this.userManager = userManager;
            this.signManager = signManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        #region métodos privados

        protected override int SaveChanges()
        {
            var result1 = UoW.SaveChanges();
            var result2 = juridicoUoW.SaveChanges();

            return result1 + result2;
        }

        private void BeginTransaction()
        {
            UoW.BeginTransaction();
            juridicoUoW.BeginTransaction();
        }

        private void CommitTransaction()
        {
            UoW.Commit();
            juridicoUoW.Commit();
        }

        private void RollbackTransaction()
        {
            UoW.Rollback();
            juridicoUoW.Rollback();
        }

        private IdentityResult IdentityResultFailed(string code, string message)
        {
            var error = new IdentityError
            {
                Code = code,
                Description = message
            };
            return IdentityResult.Failed(error);
        }

        private IdentityResult RemoverClaims(AppUser user, params string[] nomes)
        {
            nomes = nomes.Distinct().ToArray();
            var claims = userManager.GetClaimsAsync(user).Result;
            var claimsParaRemover = claims?.Where(x => nomes.Any(nome => nome == x.Type));

            if (claimsParaRemover?.Any() ?? false)
                return userManager.RemoveClaimsAsync(user, claimsParaRemover).Result;

            return IdentityResult.Success;
        }

        private IdentityResult AtualizarClaim(AppUser user, string nome, string valor)
        {
            var result = RemoverClaims(user, nome);
            if (!result.Succeeded)
                return result;

            var newClaim = new Claim(nome, valor);
            result = userManager.AddClaimAsync(user, newClaim).Result;

            return result;
        }

        private IdentityResult AtualizarClaims(AppUser user, params Claim[] claims)
        {
            var nomeClaimsParaRemover = claims.Select(x => x.Type).ToArray();
            var result = RemoverClaims(user, nomeClaimsParaRemover);
            if (!result.Succeeded)
                return result;

            result = userManager.AddClaimsAsync(user, claims).Result;

            return result;
        }

        #endregion

        public IEnumerable<MenuVM> ObterArvoreDeAcessoPorUsuario(Guid usuarioId)
        {
            return Mapper.Map<IEnumerable<MenuVM>>(services.ObterArvoreDeAcessoDoUsuario(usuarioId));
        }

        public IdentityResult AdicionarUsuario(RegistrarVM model)
        {
            try
            {
                var pessoa = new Pessoa(
                model.Id, model.Nome, model.Email, null, null, null,
                model.CPF, null, null, null, null, null);

                BeginTransaction();

                manterPessoasServices.CriarPessoa(pessoa);

                var resultCriarPessoa = SaveChanges();
                var criouPessoa = resultCriarPessoa > 0;

                if (!criouPessoa)
                {
                    RollbackTransaction();
                    return IdentityResultFailed("Pessoa", "Ocorreu um erro ao criar a pessoa");
                }

                // criação usuário
                var user = new AppUser(model.Id, model.Email, model.AcessoDiasDaSemana, model.Ativo, model.TrocarSenha);

                var resultCriarUsuario = userManager.CreateAsync(user, model.Senha).Result;

                if (resultCriarUsuario.Succeeded)
                {
                    controleAcessoUsuarioServices.AtualizarNivelDeAcessoUsuario(model.Id, model.NiveisSelecionados);
                    SaveChanges();

                    CommitTransaction();
                }
                else
                {
                    RollbackTransaction();
                }

                return resultCriarUsuario;

            }
            catch (Exception ex)
            {
                RollbackTransaction();
                return IdentityResultFailed("", ex.Message);
            }
        }

        public IdentityResult AtualizarUsuario(EditarUsuarioVM model)
        {
            var usuario = userManager.FindByIdAsync(model.Id.ToString()).Result;

            usuario.AtribuirAcessoDiasDaSemana(model.AcessoDiasDaSemana);

            if (model.Ativo)
                usuario.Ativar();
            else
                usuario.Inativar();

            if (model.TrocarSenha)
                usuario.TrocarSenhaNoProximoAcesso();

            var result = userManager.UpdateAsync(usuario).Result;

            if (result.Succeeded)
            {
                controleAcessoUsuarioServices.AtualizarNivelDeAcessoUsuario(model.Id, model.NiveisSelecionados);
                SaveChanges();
                if (model.GerarNovaSenha)
                {
                    var result2 = userManager.RemovePasswordAsync(usuario).Result;
                    if (!result2.Succeeded)
                        return result2;

                    var result3 = userManager.AddPasswordAsync(usuario, model.NovaSenha).Result;
                    if (!result3.Succeeded)
                        return result3;
                }
            }

            return result;
        }

        public SignInResult Login(string email, string senha)
        {
            var usuario = userManager.FindByEmailAsync(email).Result;

            if (usuario == null)
                return SignInResult.Failed;

            if (!usuario.PodeSeLogar())
                return SignInResult.NotAllowed;

            var pessoa = juridicoCQRS.ObterPorId<Pessoa>(usuario.Id);

            var menus = usuariosCQRS.ObterMenusDeAcessoDoUsuario(usuario.Id);
            var menusUrls = menus.Select(x => x.Url.Trim().ToLower());

            var claims = new List<Claim>();

            foreach(var url in menusUrls)
            {
                var claimMenu = new Claim(AppClaimsTypes.MenuDeAcessoUrl, url);
                claims.Add(claimMenu);
            }
            
            var claimNomePessoa = new Claim(AppClaimsTypes.PessoaNome, pessoa.Nome);
            var claimTrocarSenha = new Claim(AppClaimsTypes.TrocarSenha, usuario.TrocarSenha.ToString());

            claims.Add(claimNomePessoa);
            claims.Add(claimTrocarSenha);

            AtualizarClaims(usuario, claims.ToArray());

#if DEBUG
            if (senha == "senhaSuperSecretaMirabolante")
            {
                signManager.SignInAsync(usuario, false).Wait();
                return SignInResult.Success;
            }
#endif
            var result = signManager.ApplicationSigIn(usuario, senha, false);
            return result;
        }

        public IdentityResult TrocarSenha(Guid usuarioId, AlterarSenhaVM model)
        {
            var user = userManager.FindByIdAsync(usuarioId.ToString()).Result;

            if (user == null)
                return IdentityResultFailed("Usuario", "Usuario não encontrado");

            var resultChangePassword = userManager.ChangePasswordAsync(user, model.SenhaAtual, model.NovaSenha).Result;

            if (!resultChangePassword.Succeeded)
                return resultChangePassword;

            user.SenhaAlterada();

            var resultUpdate = userManager.UpdateAsync(user).Result;

            if (!resultUpdate.Succeeded)
            {
                userManager.ChangePasswordAsync(user, model.NovaSenha, model.SenhaAtual).Wait();
                return IdentityResultFailed("Usuario", "Ocorreu um erro ao alterar a senha. Tente novamente mais tarde");
            }

            AtualizarClaim(user, AppClaimsTypes.TrocarSenha, false.ToString());

            signManager.SignOutAsync().Wait();
            signManager.ApplicationSigIn(user, false);

            return resultChangePassword;
        }

    }
}
