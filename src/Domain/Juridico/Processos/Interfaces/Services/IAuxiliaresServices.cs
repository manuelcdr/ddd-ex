using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Domain.Juridico.Processos.Interfaces.Services
{
    public interface IAuxiliaresServices
    {
        //void AdicionarJustica(int id, string descricao, string descricaoReduzida);
        //void AtualizarJustica(int id, string descricao, string descricaoReduzida);

        //void AdicionarOrgao(int id, string descricao, string descricaoReduzida);
        //void AtualizarOrgao(int id, string descricao, string descricaoReduzida);

        void Adicionar(object entidade);
        void Atualizar(object entidade);
    }
}
