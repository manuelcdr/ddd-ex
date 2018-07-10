using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class ProcessoPessoaVM
    {
        public Guid Id { get; set; }
        public Guid ProcessoId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid TipoRelacaoId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Tipo Pessoa")]
        public TipoPessoa TipoPessoa { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string Documento{ get; set; }

        [Display(Name = "Tipo Relação")]
        public string TipoRelacao { get; set; }
    }
}
