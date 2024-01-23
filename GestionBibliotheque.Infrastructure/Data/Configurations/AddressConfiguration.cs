using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> cfg)
        {
            cfg.Property(a => a.Apt)
                .HasMaxLength(8);

            cfg.Property(a => a.Number)
                .HasMaxLength(10);

            cfg.Property(a => a.Street)
                .IsRequired();            
            
            cfg.Property(a => a.City)
                .IsRequired(); 
            
            cfg.Property(a => a.ZipCode)
                .HasMaxLength(15)
                .IsRequired(); 
            
            cfg.Property(a => a.Country)
                .IsRequired();

        }
    }
}
