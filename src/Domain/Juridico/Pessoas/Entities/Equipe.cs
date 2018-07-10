using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;
using PGLaw.Domain.Juridico.Processos.Entitties;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Pessoas.Entities
{
    public class Equipe : DefaultEntity<Equipe>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Processo> Processos { get; set; }
        public virtual ICollection<EquipePessoa> EquipesPessoas { get; set; }
        public virtual ICollection<EquipeCliente> EquipesClientes { get; set; }

        public override bool EhValido()
        {
            return false;
        }
    }
}
