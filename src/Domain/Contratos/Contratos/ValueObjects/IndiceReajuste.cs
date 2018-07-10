using PGLaw.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Domain.Contratos.Contratos.ValueObjects
{
    public class IndiceReajuste : TipoDesativavelEntity<IndiceReajuste, Guid>
    {
        protected IndiceReajuste() { }

        public IndiceReajuste(Guid id, string descricao)
            : base(id, descricao)
        {

        }

    }
}
