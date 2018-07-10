using AutoMapper;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Models;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PGLaw.Application.Sistema.Services
{
    public class NivelDeAcessoAppServices : AppServiceBase, INivelDeAcessoAppServices
    {
        private readonly INivelDeAcessoServices services;
        private readonly ISistemaGlobalRepositoryRead globalRepository;

        public NivelDeAcessoAppServices(INivelDeAcessoServices services, ISistemaGlobalRepositoryRead globalRepository, ISistemaUnitOfWork uow)
            : base(uow, globalRepository)
        {
            this.services = services;
        }

        public void Adicionar(NivelDeAcessoVM model)
        {
            
        }

        public void Atualizar(NivelDeAcessoVM model)
        {
            
        }

        public void Excluir(Guid id)
        {
            
        }

        public NivelDeAcessoVM ObterPorId(Guid id)
        {
            
        }

        public IEnumerable<NivelDeAcessoVM> ObterTodos()
        {
            
        }


    }
}
