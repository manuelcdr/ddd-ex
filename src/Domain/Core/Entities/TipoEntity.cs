using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Core.Entities
{
    public abstract class TipoEntity<T, TKey> : DefaultEntity<T, TKey>, ITipo<TKey> where T : class
    {
        protected TipoEntity() { }

        public TipoEntity(TKey id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public string Descricao { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }

    public abstract class TipoDesativavelEntity<T, TKey> : TipoEntity<T, TKey>, ITipoDesativavel<TKey> where T : class
    {
        protected TipoDesativavelEntity() { }

        public TipoDesativavelEntity(TKey id, string descricao, bool ativo = true)
            :base(id, descricao)
        {
            Id = id;
            Descricao = descricao;
            Ativo = ativo;
        }

        public bool Ativo { get; protected set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }

    public abstract class TipoEntity<T> : TipoEntity<T, Guid> where T : class
    {
        public TipoEntity(){ }

        public TipoEntity(Guid id, string descricao)
            :base(id, descricao) { }
    }

    public abstract class TipoDesativavelEntity<T> : TipoDesativavelEntity<T, Guid> where T : class
    {
        public TipoDesativavelEntity() { }

        public TipoDesativavelEntity(Guid id, string descricao, bool ativo = true)
            : base(id, descricao, ativo) { }
    }
}
