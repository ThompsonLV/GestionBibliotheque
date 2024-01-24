using GestionBibliotheque.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionBibliotheque.ViewComponents
{
    public class BookListViewComponent : ViewComponent
    {
        private LibraryContext Context { get; set; }

        public BookListViewComponent(LibraryContext context)
        {
            Context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? DomainId, int? AuthorId)
        {
            List<Book> books = new List<Book>();

            if (DomainId != null)
            {
                books = await Context.Books
                    .Include(b => b.Domain)
                    .Include(b => b.Author)
                    .Where(r => r.Domain.Id == DomainId)
                    .ToListAsync();
            }
            else if (AuthorId != null)
            {
                books = await Context.Books
                    .Include(b => b.Domain)
                    .Include(b => b.Author)
                    .Where(r => r.Author.Id == AuthorId)
                    .ToListAsync();
            } else
            {
                books = await Context.Books
                    .Include(b => b.Domain)
                    .Include(b => b.Author)
                    .ToListAsync();
            }
            return View(books);
        }
    }
}
