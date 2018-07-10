using System;
using System.Collections.Generic;
using System.Text;

namespace PGLaw.Application.Contratos.Models.Common
{
    public class CidadeVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int EstadoId { get; set; }

        public EstadoVM Estado { get; set; }
    }
}
