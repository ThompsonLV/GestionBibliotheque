using GestionBibliotheque.Entities;
using GestionBibliotheque.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.Infrastructure.Data
{
    public class LibraryContext: DbContext
    {
        public DbSet<Address> Adresses => Set<Address>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Domain> Domains => Set<Domain>();
        public DbSet<Lector> Lectors => Set<Lector>();
        public DbSet<Rentail> Rentails => Set<Rentail>();

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { } // à voir pourquoi ?

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdminConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LectorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentailConfiguration).Assembly);
        }


    }
}
