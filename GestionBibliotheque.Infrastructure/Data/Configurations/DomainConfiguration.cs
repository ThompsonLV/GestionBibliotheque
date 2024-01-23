using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class DomainConfiguration : IEntityTypeConfiguration<Domain>
    {
        public void Configure(EntityTypeBuilder<Domain> cfg)
        {
            cfg.Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();           
            
            cfg.Property(d => d.Description)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}