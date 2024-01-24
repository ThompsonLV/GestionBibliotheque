using GestionBibliotheque.Entities;
using GestionBibliotheque.Infrastructure.Data;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace GestionBibliotheque.ViewComponents
{
    [ViewComponent(Name = "RentailList")]
    public class RentailListViewComponent: ViewComponent
    {
        private LibraryContext Context { get; set; }

        public RentailListViewComponent(LibraryContext context)
        {
            Context = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(int? BookId, int? LectorId)
        {
            List<Rentail> rentails = new List<Rentail>();

            if (BookId != null)
            {
                rentails = await Context.Rentails
                    .Include(r => r.Book)
                    .Include(r => r.Lector)
                    .Where(r => r.Book.Id == BookId)
                    .ToListAsync();
            }
            else if (LectorId != null)
            {
                rentails = await Context.Rentails
                    .Include(r => r.Book)
                    .Include(r => r.Lector)
                    .Where(r => r.Lector.Id == LectorId)
                    .ToListAsync();
            }
            else
            {
                rentails = await Context.Rentails
                    .Include(b => b.Book)
                    .Include(b => b.Lector)
                    .ToListAsync();
            }
            return View(rentails);
        }
    }
}

