using PGLaw.Domain.Core.Entities;
using System;

namespace PGLaw.Domain.Contratos.Contratos.ValueObjects
{
    public class FormaPagamento : TipoDesativavelEntity<FormaPagamento, Guid>
    {
        protected FormaPagamento() { }

        public FormaPagamento(Guid id, string descricao)
            : base(id, descricao)
        {

        }
    }
}