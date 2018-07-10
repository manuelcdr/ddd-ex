using AutoMapper;
using PGLaw.Application.Sistema.AutoMapper.Profiles;

namespace PGLaw.Application.Sistema.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegistrarMapeamentos()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperProfile>();
                x.AddProfile<ViewModelToDomainProfile>();
            });
        }
    }
}
