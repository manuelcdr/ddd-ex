using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
namespace PGLaw.Domain.Contratos.Pessoas.Services
{
    public class DomainServicesBase
    {
        protected readonly IContratoGlobalRepository Repository;

        public DomainServicesBase(IContratoGlobalRepository repository)
        {
            this.Repository = repository;
        }
    }
}