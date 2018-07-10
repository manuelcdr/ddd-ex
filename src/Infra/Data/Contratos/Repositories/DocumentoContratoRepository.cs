using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Core.Interfaces.Entities;
//using PGLaw.Domain.Contratos.Common.Entities;
using PGLaw.Domain.Contratos.Pessoas.Entitties.Relashionships;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Repositories;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Contratos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;

namespace PGLaw.Infra.Data.Contratos.Repositories
{
    class DocumentoContratoRepository : RepositoryBase, IDocumentosContratoRepository
    {
        public DocumentoContratoRepository(ContratoContext context) : base(context)
        {
        }

    }
}