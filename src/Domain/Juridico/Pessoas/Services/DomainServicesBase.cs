using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Domain.Juridico.Pessoas.Services
{
    public class DomainServicesBase
    {
        protected readonly IJuridicoGlobalRepository Repository;

        public DomainServicesBase(IJuridicoGlobalRepository repository)
        {
            this.Repository = repository;
        }
    }
}