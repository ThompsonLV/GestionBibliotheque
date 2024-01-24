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
            var q = Context.Rentails
                .Include(r => r.Lector)
                .Include(r => r.Book);

            if (BookId != null)
            {
                q.Where(r => r.Book.Id == BookId);
            } else if (LectorId != null)
            {
                q.Where(r => r.Lector.Id == LectorId);
            }
            rentails = await q.ToListAsync();
            return View(rentails);
        }
    }
}

