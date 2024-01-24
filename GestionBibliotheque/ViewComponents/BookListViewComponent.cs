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
                    .Include(b => b.Rentails.OrderByDescending(r => r.Id).Take(1))
                    .Where(r => r.Domain.Id == DomainId)
                    .ToListAsync();

                //books = (from book in Context.Books
                //             join rentail in Context.Rentails.OrderByDescending(r => r.Id).Take(1) on book.Id equals rentail.Book.Id into r
                //             join author in Context.Authors on book.Author.Id equals author.Id
                //             join domain in Context.Domains on book.Domain.Id equals domain.Id
                //             from rent in r.DefaultIfEmpty()
                //             where ((rent == null) || (rent != null && rent.ReturnDate != null && rent.ReturnDate <= DateTime.Now))
                //             select book)
                //       .ToList();
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
