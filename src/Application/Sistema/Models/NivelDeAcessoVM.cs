using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Sistema.Models
{
    public class NivelDeAcessoVM
    {
        public NivelDeAcessoVM()
        {
            Id = SequentialGuidGenerator.Generate();
            UsuariosIds = new List<Guid>();
            MenusIds = new List<Guid>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }

        public List<Guid> UsuariosIds { get; set; }
        public List<Guid> MenusIds { get; set; }
    }
}
