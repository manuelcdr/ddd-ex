using PGLaw.Domain.Core.Interfaces.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Common
{
    public class TipoVM<TKey> : ITipo<TKey>
    {
        [Required]
        public TKey Id { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public object GetId() => Id;
    }

    public class TipoDesativavelVM<TKey> : TipoVM<TKey>, ITipoDesativavel<TKey>
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

    public class TipoVM : TipoVM<Guid> { }
    public class TipoDesativavelVM : TipoDesativavelVM<Guid> { }
}
