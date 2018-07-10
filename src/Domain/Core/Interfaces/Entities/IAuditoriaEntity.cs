using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Domain.Core.Interfaces.Entities
{
    public interface IAuditoriaEntity
    {
        Guid UsuarioInclusaoId { get; set; }
        string UsuarioInclusao { get; set; }
        DateTime DataInclusao { get; set; }
    }
}
