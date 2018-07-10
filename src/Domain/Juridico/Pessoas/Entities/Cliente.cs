using FluentValidation;
using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Pessoas.Entities
{
    public class Cliente : DefaultEntity<Cliente>
    {
        protected Cliente() { }

        public Cliente(Pessoa pessoa, string segmento, string atuacao, string uf)
        {
            Id = pessoa.Id;
            Pessoa = pessoa;
            Segmento = segmento;
            Atuacao = atuacao;
            UF = uf;
            Ativo = true;
        }

        public bool Ativo { get; set; }
        public string Segmento { get; set; }
        public string Atuacao { get; set; }
        public string UF { get; set; }

        // relacionamentos 
        public Pessoa Pessoa { get; private set; }

        public virtual ICollection<Processo> Processos { get; set; }
        public ICollection<ClienteCausaReal> ClienteCausaReal { get; set; }
        public ICollection<ClienteAreaOfensora> ClienteAreaOfensora { get; set; }
        public ICollection<ClienteMotivoAcionamento> ClienteMotivoAcionamento { get; set; }
        public ICollection<PessoaCliente> PessoaCliente { get; set; }


        public void AtribuirPessoaFisica(Pessoa pessoa)
        {
            Pessoa = pessoa;
        }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(c => c.Pessoa)
                .NotNull().WithMessage("É preciso informar os dados da pessoa");

            RuleFor(c => c.Segmento)
                .NotEmpty().WithMessage("É preciso informar um segmento");

            RuleFor(c => c.UF)
                .NotEmpty().WithMessage("É preciso informar o estado");

            ValidationResult = Validate(this);
        }
    }
}
