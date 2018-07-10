using AutoMapper;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Models;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Sistema.Services
{
    public class MenuAppServices : AppServiceBase, IMenuAppServices
    {
        private readonly IMenuServices services;

        public MenuAppServices(IMenuServices services, ISistemaGlobalRepositoryRead globalRepository, ISistemaUnitOfWork uow)
            :base(uow, globalRepository)
        {
            this.services = services;
        }

        public void Adicionar(MenuVM model)
        {
            
        }

        public void Atualizar(MenuVM model)
        {
            
        }

        public void Excluir(Guid id)
        {
            
        }

        public MenuVM ObterPorId(Guid id)
        {
            
        }

        public IEnumerable<MenuVM> ObterTodos()
        {
            
        }
    }
}
