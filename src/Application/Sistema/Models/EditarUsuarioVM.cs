using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Sistema.Models
{
    public class EditarUsuarioVM : UsuarioVM
    {
        [Required]
        public new Guid Id { get; set; }

        [Display(Name = "Nova senha")]
        public string NovaSenha { get; set; }

        [Required]
        public bool GerarNovaSenha { get; set; }
    }
}
