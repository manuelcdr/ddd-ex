using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Sistema.Models
{
    public class EditarMenuVM
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Ordem { get; set; }
        public bool Ferramenta { get; set; }
        public bool Raiz { get; set; }
        public string CaminhoAcesso { get; set; }

        public Guid? MenuPaiId { get; set; }
        public string MenuPaiTitulo { get; set; }
    }
}