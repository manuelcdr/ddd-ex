using AutoMapper;
using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PGLaw.Application.Juridico.Services
{
    public class AppServiceBase
    {
        private readonly IJuridicoUnitOfWork UoW;
        protected readonly IJuridicoCQRS RepositoryCQRS;

        public AppServiceBase(IJuridicoUnitOfWork uow, IJuridicoCQRS repositoryCQRS)
        {
            this.UoW = uow;
            this.RepositoryCQRS = repositoryCQRS;
        }

        protected int SaveChanges()
        {
            return UoW.SaveChanges();
        }

        protected IEnumerable<TModel> ObterTodos<TEntity, TModel>() where TEntity : class
        {
            var entidades = RepositoryCQRS.ObterTodos<TEntity>();
            var models = Mapper.Map<IEnumerable<TModel>>(entidades);
            return models;
        }

        public IEnumerable<TModel> ObterTodos<TModel>()
        {
            var tipoDominio = ObterTipoDominio(typeof(TModel));
            var entidades = RepositoryCQRS.ObterTodos(tipoDominio);
            var models = Mapper.Map<IEnumerable<TModel>>(entidades);
            return models;
        }

        public TModel ObterModel<TModel>(object id)
        {
            var tipoDominio = ObterTipoDominio(typeof(TModel));
            var entity = RepositoryCQRS.ObterPorId(tipoDominio, id);
            var model = Map<TModel>(entity);
            return model;
        }

        protected TModel ObterModel<TEntity, TModel>(object id) where TEntity : class
        {
            var entity = RepositoryCQRS.ObterPorId<TEntity>(id);
            var model = Map<TModel>(entity);
            return model;
        }

        protected IEnumerable<TModel> ObterTodosAtivos<TEntity, TModel>() where TEntity : class, IDesativavel
        {
            var entidades = RepositoryCQRS.ObterTodosAtivos<TEntity>();
            var models = Mapper.Map<IEnumerable<TModel>>(entidades);
            return models;
        }

        protected TDestino Map<TDestino>(object origem)
        {
            return Mapper.Map<TDestino>(origem);
        }

        protected IEnumerable<TDestino> MapLista<TDestino>(object origem)
        {
            return Mapper.Map<IEnumerable<TDestino>>(origem);
        }

        protected Type ObterTipoDominio(Type type)
        {
            if (!type.Name.EndsWith("VM"))
                return null;

            var nomeDestino = type.Name.Replace("VM", "");
            var types = Assembly.Load(new AssemblyName("PGLaw.Domain.Juridico")).GetTypes();
            var tDestino = types.SingleOrDefault(t => t.Name == nomeDestino);
            return tDestino;
        }
    }
}
