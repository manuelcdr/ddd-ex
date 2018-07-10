using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PGLaw.Application.Contratos.Models.Contratos
{
    public class DocumentoContratoVM
    {
        public Guid Id { get; set; }

        public Guid ContratoId { get; set; }
        public string NomeArquivo { get; set; }
        public string NomeOriginal { get; set; }

        public string Link => PreencheLink();

        public IFormFile Arquivo { get; set; }

        private string PreencheLink()
        {
            var filePath = "";
            if (NomeArquivo != null)
            {
                filePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "Contratos",
                        ContratoId.ToString(), NomeArquivo);
            }
            return filePath;
        }

    }
}