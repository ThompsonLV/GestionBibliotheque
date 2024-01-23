using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> cfg)
        {
            cfg.Property(p => p.Lastname)
                .IsRequired()
                .HasMaxLength(30);            
            
            cfg.Property(p => p.Firstname)
                .IsRequired()
                .HasMaxLength(30);

            cfg.Property(p => p.Email)
                .IsRequired();

            cfg.HasIndex(p => p.Email)
                .IsUnique();

            cfg.Property(p => p.Phone)
                .HasMaxLength(10);
        }
    }
}
