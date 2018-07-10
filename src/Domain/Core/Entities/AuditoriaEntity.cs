using System;
using PGLaw.Domain.Core.Interfaces.Entities;


namespace PGLaw.Domain.Core.Entities
{
    public class AuditoriaEntity : IAuditoriaEntity
    {
        public Guid UsuarioInclusaoId { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
