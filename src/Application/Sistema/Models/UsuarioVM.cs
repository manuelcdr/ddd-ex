using AutoMapper;
using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PGLaw.Application.Sistema.Models
{
    public class UsuarioVM
    {
        public UsuarioVM()
        {
            NiveisSelecionados = new Guid[] { };
            DiasDaSemanaSelecionados = new string[] { };
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Trocar Senha")]
        public bool TrocarSenha { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        [Display(Name = "Dias da Semana")]
        public DiasDaSemana AcessoDiasDaSemana { get; set; }

        [Required]
        public Guid[] NiveisSelecionados { get; set; }

        // privates
        private string[] _diasDaSemanaSelecionados { get; set; }

        // getters e setters
        public string[] DiasDaSemanaSelecionados
        {
            get { return _diasDaSemanaSelecionados; }
            set
            {
                _diasDaSemanaSelecionados = value;

                if (!_diasDaSemanaSelecionados.Any())
                    return;

                AcessoDiasDaSemana = (DiasDaSemana)Enum.Parse(typeof(DiasDaSemana), string.Join(",", _diasDaSemanaSelecionados));
            }
        }

        public EditarUsuarioVM ObterEditModel()
        {
            return Mapper.Map<EditarUsuarioVM>(this);
        }
    }
}
