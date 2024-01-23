using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class LectorConfiguration : IEntityTypeConfiguration<Lector>
    {
        public void Configure(EntityTypeBuilder<Lector> cfg)
        {
            cfg.Property(l => l.Password)
                .IsRequired();
        }
    }
}
