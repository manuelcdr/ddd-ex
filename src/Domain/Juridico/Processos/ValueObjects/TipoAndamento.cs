using PGLaw.Domain.Core.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.ValueObjects
{
    public class TipoAndamento : TipoDesativavelEntity<TipoAndamento>
    {
        public Guid GrupoId { get; set; }

        //relacionamentos 
        public GrupoAndamento Grupo { get; set; }
    }
}
