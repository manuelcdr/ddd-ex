using PGLaw.Domain.Core.Entities;
using System;

namespace PGLaw.Domain.Contratos.Contratos.ValueObjects
{
    public class Gerencia : TipoDesativavelEntity<Gerencia, Guid>
    {
        protected Gerencia() { }

        public Gerencia(Guid id, string descricao)
            : base(id, descricao)
        {

        }

    }
}
