using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PGLaw.Infra.Data.Base
{
    public class RelashionshipEntityConfig<T, TMany1, TMany2> : EntityConfigBase<T> where T : class
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            ManyToManyAndKeys<TMany1, TMany2>();
        }
    }
}
