using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class RentailConfiguration : IEntityTypeConfiguration<Rentail>
    {
        public void Configure(EntityTypeBuilder<Rentail> cfg)
        {
            cfg.Property(r => r.RentailDate)
                .IsRequired();

            cfg.HasOne(r => r.Lector)
                .WithMany(l => l.Rentails)
                .HasForeignKey("LectorId")
                .OnDelete(DeleteBehavior.Restrict);

            cfg.HasOne(r => r.Book)
                .WithMany(l => l.Rentails)
                .HasForeignKey("BookId")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
