using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PGLaw.Infra.Cross.Identity.Models;
using System;

namespace PGLaw.Infra.Cross.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("Usuario");
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });

            builder.Entity<AppRole>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
