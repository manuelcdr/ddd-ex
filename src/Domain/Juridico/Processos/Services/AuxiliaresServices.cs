using System;
using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Services;
using PGLaw.Domain.Juridico.Processos.Interfaces.Services;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Cross.Common.Utils;

namespace PGLaw.Domain.Juridico.Processos.Services
{
    public class AuxiliaresServices : DomainServicesBase, IAuxiliaresServices
    {
        public AuxiliaresServices(IJuridicoGlobalRepository repository) 
            : base(repository)
        {
        }

        //public void AdicionarAtualizarOrgao(int id, string descricao, string descricaoReduzida)
        //{
        //    var entidade = Repository.ObterPorId<Orgao>(id);

        //    if (entidade != null)
        //    {
        //        entidade.Descricao = descricao;
        //        entidade.DescricaoReduzida = descricaoReduzida;

        //        if (entidade.EhValido())
        //            Repository.Atualizar(entidade);
        //    } else
        //    {
        //        if (entidade.EhValido())
        //            Repository.Adicionar(entidade);
        //    }
        //}

        //public void AdicionarJustica(int id, string descricao, string descricaoReduzida)
        //{
        //    var justica = new Justica(id, descricao, descricaoReduzida);

        //    if (justica.EhValido())
        //        Repository.Adicionar(justica);
        //}

        //public void AdicionarOrgao(int id, string descricao, string descricaoReduzida)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void AtualizarJustica(int id, string descricao, string descricaoReduzida)
        //{
        //    var justica = Repository.ObterPorId<Justica>(id);
        //    justica.Descricao = descricao;
        //    justica.DescricaoReduzida = descricaoReduzida;

        //    if (justica.EhValido())
        //        Repository.Atualizar(justica);
        //}

        //public void AtualizarOrgao(int id, string descricao, string descricaoReduzida)
        //{
        //    var justica = Repository.ObterPorId<Orgao>(id);
        //    justica.Descricao = descricao;
        //    justica.DescricaoReduzida = descricaoReduzida;

        //    if (justica.EhValido())
        //        Repository.Atualizar(justica);
        //}

        //public void Adicionar<T>(T entidade) where T : TipoEntity<T>
        //{
        //    if (Repository.ObterPorId<T>(entidade.Id) != null)
        //        return;

        //    if (entidade.EhValido())
        //        Repository.Adicionar(entidade as T);
        //}

        //public void Atualizar<T>(T entidade) where T : TipoEntity<T>
        //{
        //    if (Repository.ObterPorId<T>(entidade.Id) == null)
        //        return;

        //    if (entidade.EhValido())
        //        Repository.Atualizar(entidade as T);
        //}

        //public void Adicionar<T, TKey>(T entidade) where T : TipoEntity<T, TKey>
        //{
        //    if (Repository.ObterPorId<T>(entidade.Id) != null)
        //        return;

        //    if (entidade.EhValido())
        //        Repository.Adicionar(entidade as T);
        //}

        //public void Atualizar<T, TKey>(T entidade) where T : TipoEntity<T, TKey>
        //{
        //    if (Repository.ObterPorId<T>(entidade.Id) == null)
        //        return;

        //    if (entidade.EhValido())
        //        Repository.Atualizar(entidade as T);
        //}

        public void Adicionar(object entidade)
        {
            var type = entidade.GetType();
            var id = type.GetProperty("Id").GetValue(entidade);
            if (Repository.ObterPorId(type, id) != null)
                return;

            var ehValido = Convert.ToBoolean(ChamadorMetodo.ChamarMetodo(entidade, "EhValido"));

            if (ehValido)
                Repository.Adicionar(entidade);
        }

        public void Atualizar(object entidade)
        {
            var type = entidade.GetType();
            var id = type.GetProperty("Id").GetValue(entidade);
            if (Repository.ObterPorId(type, id) == null)
                return;

            var ehValido = Convert.ToBoolean(ChamadorMetodo.ChamarMetodo(entidade, "EhValido"));

            if (ehValido)
                Repository.Atualizar(entidade);
        }
    }
}
