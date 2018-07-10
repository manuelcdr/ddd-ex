using PGLaw.Domain.Core.Entities;
using System;

namespace PGLaw.Domain.Contratos.Contratos.Entitties
{
    public class DocumentoContrato : DefaultEntity<DocumentoContrato>
    {
        protected DocumentoContrato() { }

        public DocumentoContrato(Guid contratoId)
        {
            ContratoId = contratoId;

        }

        public DocumentoContrato(Guid id, Guid contratoId, string nomearquivo, string nomeoriginal)
        {
            Id = id;
            ContratoId = contratoId;
            NomeArquivo = nomearquivo;
            NomeOriginal = nomeoriginal;
        }


        public Guid ContratoId { get; set; }
        public string NomeArquivo { get; set; }
        public string NomeOriginal { get; set; }

        public Contrato Contrato { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}