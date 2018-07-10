using PGLaw.Domain.Core.Entities;
using System;


namespace PGLaw.Domain.Contratos.Contratos.ValueObjects
{
    public class Tipo : TipoDesativavelEntity<Tipo,Guid>
    {
        protected Tipo() { }

        public Tipo(Guid id, string descricao)
            : base(id, descricao)
        {
            
        }

    }
}
