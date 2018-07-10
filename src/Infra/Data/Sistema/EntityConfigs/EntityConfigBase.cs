using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Core.Entities;

namespace PGLaw.Infra.Data.Sistema.EntityConfigs
{
    public abstract class EntityConfigBase<T> : IEntityTypeConfiguration<T> where T : DefaultEntity<T>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Ignore("ValidationResult");
            builder.Ignore("CascadeMode");
        }
    }
}
