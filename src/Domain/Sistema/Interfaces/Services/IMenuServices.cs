using PGLaw.Domain.Core.Interfaces.DomainServices;
using PGLaw.Domain.Sistema.Entitties;
using System;

namespace PGLaw.Domain.Sistema.Interfaces.Services
{
    public interface IMenuServices
    {


        void AdicionarMenuFerramenta(Guid menuPaiId, string titulo, string url, int ordem);
        void AdicionarMenuRaiz(string titulo, int ordem);
        void AdicionarMenuDeAcesso(Guid menuPaiId, string titulo, int ordem);

        void AtualizarMenuRaiz(Menu menu);
        void AtualizarMenuFerramenta(Menu menu);
        void AtualizarMenuDeAcesso(Menu menu);
    }
}
