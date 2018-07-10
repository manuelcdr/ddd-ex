using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class Andamento : DefaultEntity<Andamento>
    {
        //protected Andamento() { }

        //public Andamento(Guid processoId, Guid tipoId, string descricao, OrigemAndamento origem, DateTime data)
        //{
        //    ProcessoId = processoId;
        //    Descricao = descricao;
        //    Origem = origem;
        //    Data = data;
        //}

        public Guid ProcessoId { get; set; }
        public Guid TipoId { get; set; }

        public string Descricao { get; set; }
        public TipoAndamento Tipo { get; set; }
        public OrigemAndamento Origem { get; set; }
        public DateTime Data { get; set; }

        // relacionamentos
        public Processo Processo { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
