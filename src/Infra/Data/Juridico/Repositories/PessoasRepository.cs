using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories;
using PGLaw.Infra.Cross.Common.Extensions;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Juridico.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Infra.Data.Juridico.Repositories
{
    public class PessoasRepository : RepositoryBase, IPessoasRepository
    {
        public PessoasRepository(JuridicoContext context) : base(context)
        {
        }

        public Cliente ObterCliente(Guid id)
        {
            return Set<Cliente>()
                .Include(c => c.Pessoa)
                .ThenInclude( c => c.DadosPessoaFisica)
                .Include(c => c.Pessoa)
                .ThenInclude(c => c.DadosPessoaJuridica)
                .Where(c => c.Id == id).SingleOrDefault();
        }

        public Pessoa ObterPessoaPorCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return null;

            cnpj = cnpj.ApenasNumeros();

            return Set<Pessoa>()
                .Include(p => p.DadosPessoaJuridica)
                .Where(p => p.DadosPessoaJuridica.CNPJ == cnpj)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public Pessoa ObterPessoaPorCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return null;

            cpf = cpf.ApenasNumeros();

            return Set<Pessoa>()
                .Include(p => p.DadosPessoaFisica)
                .Where(p => p.DadosPessoaFisica.CPF == cpf)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public Pessoa ObterPessoaPorDocumento(string documento)
        {
            if (string.IsNullOrEmpty(documento))
                return null;

            documento = documento.ApenasNumeros();

            return Set<Pessoa>()
                .Include(p => p.DadosPessoaFisica)
                .Include(p => p.DadosPessoaJuridica)
                .Where(p => p.DadosPessoaFisica.CPF == documento || p.DadosPessoaJuridica.CNPJ == documento)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public IEnumerable<Pessoa> ObterPessoasPorId(Guid[] ids)
        {
            return Set<Pessoa>()
                .Where(p => ids.Any(id => id == p.Id));
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            return Set<Cliente>()
                .Include(c => c.Pessoa)
                .OrderBy(c => c.Pessoa.Nome);
        }

    }
}
