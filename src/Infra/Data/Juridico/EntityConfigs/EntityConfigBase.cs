using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Core.Entities;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class EntityConfigBase<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigurarAutoValidador(builder);
        }

        protected void ConfigurarAutoValidador<TAutoValidador>(EntityTypeBuilder<TAutoValidador> builder) 
            where TAutoValidador : class
        {
            builder.Ignore("ValidationResult");
            builder.Ignore("CascadeMode");
        }

        protected void ConfigurarAutoValidador<TRelatedEntity>(ReferenceOwnershipBuilder<T, TRelatedEntity> referenceOwnershipBuilder)
            where TRelatedEntity : AutoValidator<TRelatedEntity>
        {
            referenceOwnershipBuilder.Ignore("ValidationResult");
            referenceOwnershipBuilder.Ignore("CascadeMode");
        }

        /// <summary>
        /// Configura as chaves primarias (caso seja somente 2) e os relacionamentos
        /// </summary>
        protected void ConfigureManyToMany<TPrincipal, TSecundary>(EntityTypeBuilder<T> builder)
        {
            ConfigureManyToManyKeys<TPrincipal, TSecundary>(builder);
            ConfigureManyToManyRelashipnship<TPrincipal, TSecundary>(builder);
        }

        /// <summary>
        /// Configura os relacionamentos
        /// </summary>
        protected void ConfigureManyToManyRelashipnship<TPrincipal, TSecundary>(EntityTypeBuilder<T> builder)
        {
            var nomePrincipal = typeof(TPrincipal).Name;
            var nomeSecundario = typeof(TSecundary).Name;
            var chavePrincipal = $"{nomePrincipal}Id";
            var chaveSecundaria = $"{nomeSecundario}Id";
            var classeRelacionadora = typeof(T).Name;

            builder.HasOne(typeof(TPrincipal), nomePrincipal)
                .WithMany(classeRelacionadora)
                .HasForeignKey(chavePrincipal)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(typeof(TSecundary), nomeSecundario)
                .WithMany(classeRelacionadora)
                .HasForeignKey(chaveSecundaria)
                .OnDelete(DeleteBehavior.Restrict);
        }

        /// <summary>
        /// Configura as chaves primarias (caso seja somente 2)
        /// </summary>
        protected void ConfigureManyToManyKeys<TPrincipal, TSecundary>(EntityTypeBuilder<T> builder)
        {
            var nomePrincipal = typeof(TPrincipal).Name;
            var nomeSecundario = typeof(TSecundary).Name;
            var chavePrincipal = $"{nomePrincipal}Id";
            var chaveSecundaria = $"{nomeSecundario}Id";
            var classeRelacionadora = typeof(T).Name;

            builder.HasKey(chavePrincipal, chaveSecundaria);
        }
    }
}
