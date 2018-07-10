using System;

namespace PGLaw.Domain.Sistema.Entitties.Relashionships
{
    public class UsuarioNivelDeAcesso
    {
        protected UsuarioNivelDeAcesso() { }

        public UsuarioNivelDeAcesso(Guid usuarioId, Guid nivelDeAcessoId)
        {
            UsuarioId = usuarioId;
            NivelDeAcessoId = nivelDeAcessoId;
        }

        public Guid UsuarioId { get; set; }
        public Guid NivelDeAcessoId { get; set; }
        public NivelDeAcesso NivelDeAcesso { get; set; }
        public Usuario Usuario { get; set; }
    }
}
