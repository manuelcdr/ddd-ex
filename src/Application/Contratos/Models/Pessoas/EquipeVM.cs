using System;

namespace PGLaw.Application.Contratos.Models.Pessoas
{
    public class EquipeVM
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        //public virtual ICollection<ProcessoVM> Processos { get; set; }
        //public virtual ICollection<PessoaVM> EquipesPessoas { get; set; }
        //public virtual ICollection<ClienteVM> EquipesClientes { get; set; }
    }
}
