using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PGLaw.Domain.Core.Interfaces.Entities
{
    public interface IUsuaa
    {
        Guid Id { get; }
        bool TrocarSenha { get; }
        bool Ativo { get; }
        DiasDaSemana AcessoDiasDaSemana { get; }
        string Name { get; }
        Guid GetUserId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
