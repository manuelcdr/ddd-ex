using PGLaw.Domain.Core.Entities;
using System;

namespace PGLaw.Domain.Sistema.Entitties.Relashionships
{
    public class MenuNivelDeAcesso : RelashionshipEntity<MenuNivelDeAcesso>
    {
        protected MenuNivelDeAcesso() { }

        public MenuNivelDeAcesso(Guid menuId, Guid nivelDeAcessoId)
        {
            MenuId = menuId;
            NivelDeAcessoId = nivelDeAcessoId;
        }

        public Guid MenuId { get; set; }
        public Guid NivelDeAcessoId { get; set; }


        // relacionamentos
        public Menu Menu { get; set; }
        public NivelDeAcesso NivelDeAcesso { get; set; }
    }
}
