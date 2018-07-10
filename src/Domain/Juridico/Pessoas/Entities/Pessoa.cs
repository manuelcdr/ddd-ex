using FluentValidation;
using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Infra.Cross.Common.Configuration;
using PGLaw.Infra.Cross.Common.Enums;
using PGLaw.Infra.Cross.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Domain.Juridico.Pessoas.Entities
{
    public class Pessoa : DefaultEntity<Pessoa>    //, ISincronizacaoEntity
    {
        #region construtores

        protected Pessoa() { }

        public Pessoa(string nome, TipoPessoa tipoPessoa, string documento)
            : base()
        {
            Nome = nome;
            TipoPessoa = tipoPessoa;
            if (tipoPessoa == TipoPessoa.Fisica)
            {
                DadosPessoaFisica = new DadosPessoaFisica(documento);
            }
            else if (tipoPessoa == TipoPessoa.Juridica)
            {
                DadosPessoaJuridica = new DadosPessoaJuridica(documento);
            }
        }

        public Pessoa(
            Guid id,
            string nome,
            TipoPessoa tipoPessoa,
            string email,
            string telefone,
            string url,
            string observacoes,
            DadosPessoaFisica dadosPessoaFisica,
            DadosPessoaJuridica dadosPessoaJuridica)
        {
            Id = id;
            Nome = nome;
            TipoPessoa = tipoPessoa;
            Email = email;
            Url = url;
            Observacoes = observacoes;

            DadosPessoaFisica = dadosPessoaFisica;
            DadosPessoaJuridica = dadosPessoaJuridica;

            AtribuirTelefone(telefone);
        }

        public Pessoa(
            Guid id,
            string nome,
            string email,
            string telefone,
            string url,
            string observacoes,
            string cpf,
            string rg,
            string orgaoEmissorRG,
            string celular,
            string telefoneComercial,
            DateTime? dataNascimento)
            : this(
                  id,
                  nome,
                  TipoPessoa.Fisica,
                  email,
                  telefone,
                  url,
                  observacoes,
                  new DadosPessoaFisica(cpf, rg, orgaoEmissorRG, celular, telefoneComercial, dataNascimento), null)
        { }

        public Pessoa(
            Guid id,
            string nome,
            string email,
            string telefone,
            string url,
            string observacoes,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal,
            string razaoSocial,
            string emailFinanceiro)
            : this(
                  id,
                  nome,
                  TipoPessoa.Juridica,
                  email,
                  telefone,
                  url,
                  observacoes,
                  null,
                  new DadosPessoaJuridica(cnpj, inscricaoEstadual, inscricaoMunicipal, razaoSocial, emailFinanceiro))
        { }

        #endregion

        public string Nome { get; set; } // usado como NomeFantasia de Pessoa Juridica
        public TipoPessoa TipoPessoa { get; set; }
        public string Email { get; set; }
        public string Telefone { get; private set; }
        public string Url { get; set; }
        public string Observacoes { get; set; }
        public string DocumentoPrincipal =>
            TipoPessoa == TipoPessoa.Fisica ?
            DadosPessoaFisica?.CPF :
            DadosPessoaJuridica?.CNPJ;


        #region metodos

        public void AtribuirTelefone(string telefone)
        {
            if (!string.IsNullOrEmpty(telefone))
                Telefone = telefone.ApenasNumeros();
        }

        #endregion


        // relacionamentos
        public DadosPessoaFisica DadosPessoaFisica { get; private set; }
        public DadosPessoaJuridica DadosPessoaJuridica { get; private set; }
        public ICollection<ProcessoPessoa> ProcessoPessoa { get; set; }
        public ICollection<PessoaCliente> PessoaCliente { get; set; }

        #region validações

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public void Validar()
        {
            ValidarPessoa();
            ValidationResult = Validate(this);

            // Validações de classes agregadas
            ValidarPessoaFisica();
            ValidarPessoaJuridica();
        }

        public void ValidarPessoa()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da pessoa precisa ser preenchido")
                .Length(3, ParametrosDeConfiguracao.MaxLenght).WithMessage($"O Logradouro precisa ter entre 2 e {ParametrosDeConfiguracao.MaxLenght} caracteres");
        }

        public void ValidarPessoaFisica()
        {
            if (TipoPessoa == TipoPessoa.Fisica)
            {
                DadosPessoaFisica.EhValido();
                if (!DadosPessoaFisica.ValidationResult.IsValid)
                    AdicionarErros(DadosPessoaFisica.ValidationResult.Errors.ToArray());
            }
        }

        public void ValidarPessoaJuridica()
        {
            if (TipoPessoa == TipoPessoa.Juridica)
            {
                DadosPessoaJuridica.EhValido();
                if (!DadosPessoaJuridica.ValidationResult.IsValid)
                    AdicionarErros(DadosPessoaJuridica.ValidationResult.Errors.ToArray());
            }
        }

        #endregion
    }
}
