using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GestionBibliotheque.Infrastructure.Data
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GestionBibliotheque;Trusted_Connection=True;MultipleActiveResultSets=true;");
            return new LibraryContext(optionsBuilder.Options);

        }
    }
}
