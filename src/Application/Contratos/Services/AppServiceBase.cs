using AutoMapper;
using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using System.Collections.Generic;

namespace PGLaw.Application.Contratos.Services
{
    public class AppServiceBase
    {
        private readonly IContratoUnitOfWork UoW;
        protected readonly IContratoCQRS RepositoryCQRS;

        public AppServiceBase(IContratoUnitOfWork uow, IContratoCQRS repositoryCQRS)
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
    }
}
