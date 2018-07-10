using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Application.Contratos.Models.Common
{
    public class PadraoVM<TKey> : ITipo<TKey>
    {
        public TKey Id { get; set; }
        public string Descricao { get; set; }

        public object GetId() => Id;
    }

    public class PadraoDesativavelVM<TKey> : PadraoVM<TKey>, ITipoDesativavel<TKey>
    {
        public bool Ativo { get; set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }

    public class PadraoVM : PadraoVM<Guid> { }
    public class PadraoDesativavelVM : PadraoDesativavelVM<Guid> { }
}
