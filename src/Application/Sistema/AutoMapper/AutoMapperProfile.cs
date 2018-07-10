using AutoMapper;
using PGLaw.Application.Sistema.Models;
using PGLaw.Domain.Sistema.Entitties;
using System.Linq;

namespace PGLaw.Application.Sistema.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            DomainToVM();
            VMToDomain();

            CreateMap<UsuarioVM, EditarUsuarioVM>();
        }

        private void DomainToVM()
        {
            CreateMap<Menu, MenuVM>();

            CreateMap<Usuario, UsuarioVM>()
                .ForMember(
                    x => x.NiveisSelecionados,
                    opt => opt.MapFrom(
                        x => x.UsuarioNivelDeAcesso.Select(n => n.NivelDeAcessoId)));

            CreateMap<NivelDeAcesso, NivelDeAcessoVM>()
                .ForMember(
                    x => x.UsuariosIds, 
                    opt => opt.MapFrom(
                        x => x.UsuarioNivelDeAcesso.Select(u => u.UsuarioId)))
                .ForMember(
                    x => x.MenusIds,
                    opt => opt.MapFrom(
                        x => x.MenuNivelDeAcesso.Select(m => m.MenuId)));
        }

        private void VMToDomain()
        {
            CreateMap<MenuVM, Menu>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(m =>
                {
                    if (m.MenuPai == null)
                        return new Menu(m.Id, m.Titulo, m.Url, m.Ordem, null);
                    else
                        return new Menu(m.Id, m.Titulo, m.Url, m.Ordem, m.MenuPaiId);
                });

            CreateMap<NivelDeAcessoVM, NivelDeAcesso>();
            CreateMap<UsuarioVM, Usuario>();
        }
    }
}
