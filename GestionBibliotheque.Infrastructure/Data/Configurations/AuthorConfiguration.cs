using GestionBibliotheque.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.Infrastructure.Data.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> cfg)
        {
            cfg.Property(a => a.Grade)
                .IsRequired();
        }
    }
}