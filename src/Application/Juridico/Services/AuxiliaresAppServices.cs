using AutoMapper;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Models.Common;
using PGLaw.Application.Juridico.Models.Processos;
using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Processos.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Juridico.Services
{
    public class AuxiliaresAppServices : AppServiceBase, IAuxiliaresAppServices
    {
        private readonly IAuxiliaresServices auxiliaresServices;

        public AuxiliaresAppServices(IJuridicoUnitOfWork uow, IJuridicoCQRS repositoryCQRS, IAuxiliaresServices auxiliaresServices) 
            : base(uow, repositoryCQRS)
        {
            this.auxiliaresServices = auxiliaresServices;
        }

        public void Adicionar<T>(T model)
        {
            var tipoDominio = ObterTipoDominio(model.GetType());
            var entidade = Mapper.Map(model, typeof(T), tipoDominio);
            auxiliaresServices.Adicionar(entidade);
            SaveChanges();
        }

        public void Atualizar<T>(T model)
        {
            var tipoDominio = ObterTipoDominio(model.GetType());
            var entidade = RepositoryCQRS.ObterPorId(tipoDominio, (model as IDefaultEntity).GetId());
            Mapper.Map(model, entidade);
            auxiliaresServices.Atualizar(entidade);
            SaveChanges();
        }

        //public T ObterPorId<T>(object id) where T : class
        //{
        //    var tipoDominio = ObterTipoDominio(typeof(T));
        //    var entidade = RepositoryCQRS.ObterPorId(tipoDominio, id);
        //    var model = Mapper.Map(entidade, tipoDominio, typeof(T));
        //    return model as T;
        //}

        //public IEnumerable<T> ObterTodos<T>()
        //{
        //    var tipoDominio = ObterTipoDominio(typeof(T));
        //    var entidades = RepositoryCQRS.ObterTodos(tipoDominio);
        //    var models = Mapper.Map<IEnumerable<T>>(entidades);
        //    return models;
        //}

        //public void AdicionarJustica(JusticaVM model)
        //{
        //    auxiliaresServices.AdicionarJustica(model.Id, model.Descricao, model.DescricaoReduzida);
        //    SaveChanges();
        //}

        //public void AdicionarOrgao(OrgaoVM model)
        //{
        //    var orgao = new Orgao(model.Id, model.JusticaId, model.Descricao, model.DescricaoReduzida);
        //    auxiliaresServices.Adicionar<Orgao, int>(orgao);
        //}

        //public void AtualizarJustica(JusticaVM model)
        //{
        //    auxiliaresServices.AtualizarJustica(model.Id, model.Descricao, model.DescricaoReduzida);
        //    SaveChanges();
        //}

        //public void AtualizarOrgao(OrgaoVM model)
        //{
        //    var tipoDominio = ObterTipoDominio(model.GetType());
        //    var entidade = RepositoryCQRS.ObterPorId(tipoDominio, model.Id);
        //    Mapper.Map(model, entidade);
        //    auxiliaresServices.Atualizar<, int>(orgao);
        //}

        //public JusticaVM ObterJustica(int id)
        //{
        //    return ObterModel<Justica, JusticaVM>(id);
        //}

        //public IEnumerable<JusticaVM> ObterTodasJusticas()
        //{
        //    return ObterTodos<Justica, JusticaVM>();
        //}
    }
}
