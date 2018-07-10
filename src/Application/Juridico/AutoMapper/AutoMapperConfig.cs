using AutoMapper;

namespace PGLaw.Application.Juridico.AutoMapper
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
