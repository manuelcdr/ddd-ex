using PGLaw.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Domain.Contratos.Contratos.ValueObjects
{
    public class Vigencia : TipoDesativavelEntity<Vigencia, Guid>
    {
        protected Vigencia() { }

        public Vigencia(Guid id, string descricao)
            : base(id, descricao)
        {

        }

    }
}
