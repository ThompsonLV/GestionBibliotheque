using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> cfg)
        {
            cfg.Property(a => a.Password)
                .IsRequired();
        }
    }
}
