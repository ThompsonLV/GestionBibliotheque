using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> cfg)
        {
            cfg.Property(b => b.Title)
                .IsRequired();            
            
            cfg.Property(b => b.Description)
                .HasMaxLength(255)
                .IsRequired();

            cfg.Property(b => b.Nbpages)
                .IsRequired();
        }
    }
}
