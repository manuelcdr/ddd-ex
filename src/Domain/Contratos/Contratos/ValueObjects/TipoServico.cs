using PGLaw.Domain.Core.Entities;
using System;


namespace PGLaw.Domain.Contratos.Contratos.ValueObjects
{
    public class TipoServico : TipoDesativavelEntity<TipoServico>
    {
        protected TipoServico() { }

        public TipoServico(Guid id, string descricao)
            : base(id, descricao)
        {

        }
    }
}