using AutoMapper;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Models.Pessoas;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Services;
using PGLaw.Domain.Juridico.Processos.Interfaces.Repositories;
using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Juridico.Services
{
    public class PessoasAppServices : AppServiceBase, IPessoasAppServices
    {
        private readonly IPessoasRepositoryCQRS pessoasCQRS;
        private readonly IManterPessoasServices criacaoPessoaServices;

        public PessoasAppServices(
            IJuridicoUnitOfWork uow, 
            IJuridicoCQRS repositoryRead,
            IPessoasRepositoryCQRS pessoasCQRS,
            IManterPessoasServices criacaoPessoaServices) 
            : base(uow, repositoryRead)
        {
            this.pessoasCQRS = pessoasCQRS;
            this.criacaoPessoaServices = criacaoPessoaServices;
        }

        public void AtualizarCliente(ClienteVM model)
        {
            var cliente = Mapper.Map<Cliente>(model);
            criacaoPessoaServices.AtualizarCliente(cliente);
            SaveChanges();
        }

        public void AtualizarClientePessoaFisica(ClientePessoaFisicaVM model)
        {
            throw new NotImplementedException();
        }

        public void AtualizarClientePessoaJuridica(ClientePessoaJuridicaVM model)
        {
            throw new NotImplementedException();
        }

        public void CriarCliente(ClienteVM model)
        {
            var cliente = Mapper.Map<Cliente>(model);
            criacaoPessoaServices.CriarCliente(cliente);
            SaveChanges();
        }

        public void CriarClientePessoaFisica(ClientePessoaFisicaVM model)
        {
            var cliente = Mapper.Map<Cliente>(model);
            criacaoPessoaServices.CriarCliente(cliente);
            SaveChanges();
        }

        public void CriarClientePessoaJuridica(ClientePessoaJuridicaVM model)
        {
            var cliente = Mapper.Map<Cliente>(model);
            criacaoPessoaServices.CriarCliente(cliente);
            SaveChanges();
        }

        public void CriarPessoa(PessoaVM model)
        {
            var pessoa = Mapper.Map<Pessoa>(model);
        }

        public ClienteVM ObterCliente(Guid id)
        {
            var entidade = pessoasCQRS.ObterCliente(id);

            if (entidade.Pessoa.TipoPessoa == TipoPessoa.Fisica)
                return Mapper.Map<ClientePessoaFisicaVM>(entidade);
            else if(entidade.Pessoa.TipoPessoa == TipoPessoa.Juridica)
                return Mapper.Map<ClientePessoaJuridicaVM>(entidade);

            return Mapper.Map<ClienteVM>(entidade);
        }

        public ClientePessoaFisicaVM ObterClientePessoaFisica(Guid id)
        {
            var entidade = pessoasCQRS.ObterCliente(id);

            if (entidade.Pessoa.TipoPessoa == TipoPessoa.Fisica)
                return Mapper.Map<ClientePessoaFisicaVM>(entidade);

            return null;
        }

        public ClientePessoaJuridicaVM ObterClientePessoaJuridica(Guid id)
        {
            var entidade = pessoasCQRS.ObterCliente(id);

            if (entidade.Pessoa.TipoPessoa == TipoPessoa.Juridica)
                return Mapper.Map<ClientePessoaJuridicaVM>(entidade);

            return null;
        }

        public IEnumerable<ClienteVM> ObterTodosClientes()
        {
            var entidades = pessoasCQRS.ObterTodosClientes();
            var models = Mapper.Map<IEnumerable<ClienteVM>>(entidades);
            return models;
        }
    }
}
