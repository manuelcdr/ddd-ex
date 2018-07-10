using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PGLaw.Infra.Cross.Identity.Interfaces
{
    public interface IUser
    {
        Guid Id { get; }
        string Name { get; }
        bool TrocarSenha { get; }
        bool Ativo { get; }
        DiasDaSemana AcessoDiasDaSemana { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
