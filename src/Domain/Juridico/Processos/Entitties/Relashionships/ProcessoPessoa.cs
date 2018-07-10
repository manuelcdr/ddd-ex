using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties.Relashionships
{
    public class ProcessoPessoa : RelashionshipEntity<ProcessoPessoa>
    {
        protected ProcessoPessoa() { }

        public ProcessoPessoa(Guid processoId, Guid pessoaId, Guid tipoRelacaoId)
        {
            ProcessoId = processoId;
            PessoaId = pessoaId;
            TipoRelacaoId = tipoRelacaoId;
        }

        public Guid ProcessoId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid TipoRelacaoId { get; set; }

        public Pessoa Pessoa { get; set; }
        public Processo Processo { get; set; }
        public TipoRelacao TipoRelacao { get; set; }
    }
}
