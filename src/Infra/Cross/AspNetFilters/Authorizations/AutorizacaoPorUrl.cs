using Microsoft.AspNetCore.Authorization;

namespace PGLaw.Infra.Cross.AspNetMvc.Authorizations
{
    public class AutorizacaoPorUrl : IAuthorizationRequirement
    {
        public bool TrocarSenha { get; set; }
    }
}
