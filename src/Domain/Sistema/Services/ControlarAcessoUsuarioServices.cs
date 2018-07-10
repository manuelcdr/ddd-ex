using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using System;

namespace PGLaw.Domain.Sistema.Services
{
    public class ControlarAcessoUsuarioServices : IControlarAcessoUsuarioServices
    {
        private readonly ISistemaGlobalRepository sistemaRepository;
        private readonly IUsuariosRepository usuariosRepository;

        public ControlarAcessoUsuarioServices(
            ISistemaGlobalRepository sistemaRepository, 
            IUsuariosRepository usuariosRepository)
        {
            this.sistemaRepository = sistemaRepository;
            this.usuariosRepository = usuariosRepository;
        }

        public void AtualizarNivelDeAcessoUsuario(Guid id, params Guid[] niveisDeAcesso)
        {
            usuariosRepository.AtualizarRelacionametoUsuarioNivelDeAcessoPorUsuario(id, niveisDeAcesso);
        }
    }
}
