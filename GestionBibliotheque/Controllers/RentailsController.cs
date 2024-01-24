using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionBibliotheque.Entities;
using GestionBibliotheque.Infrastructure.Data;
using GestionBibliotheque.Models;

namespace GestionBibliotheque.Controllers
{
    public class RentailsController : Controller
    {
        private readonly LibraryContext _context;

        public RentailsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Rentails
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Rentails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentail = await _context.Rentails
                .Include(r => r.Book)
                .Include(r => r.Lector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentail == null)
            {
                return NotFound();
            }

            return View(rentail);
        }

        // GET: Rentails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentailsViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var lector = await _context.Lectors.FindAsync(rvm.LectorId);
                var book = await _context.Books.FindAsync(rvm.BookId);

                var rentail = new Rentail() {
                    Lector = lector,
                    Book = book,
                    RentailDate = DateTime.Now,
                };

                _context.Add(rentail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rvm);
        }

        // GET: Rentails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentail = await _context.Rentails
                .Where(r => r.Id == id)
                .Include(r => r.Book)
                .Include(r => r.Book)
                .FirstOrDefaultAsync();

            if (rentail == null)
            {
                return NotFound();
            }

            var rvm = new RentailsViewModel() {
                Id = rentail.Id,
                BookId = rentail.Book.Id,
                LectorId = rentail.Lector.Id,
            };

            return View(rvm);
        }

        // POST: Rentails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RentailsViewModel rvm)
        {
            if (id != rvm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lector = await _context.Lectors.FindAsync(rvm.LectorId);
                    var book = await _context.Books.FindAsync(rvm.BookId);

                    var rentail = new Rentail() {
                        Lector = lector,
                        Book = book,
                        RentailDate = DateTime.Now,
                    };

                    _context.Update(rentail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentailExists(rvm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rvm);
        }

        // GET: Rentails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentail = await _context.Rentails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentail == null)
            {
                return NotFound();
            }

            return View(rentail);
        }

        // POST: Rentails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentail = await _context.Rentails.FindAsync(id);
            if (rentail != null)
            {
                _context.Rentails.Remove(rentail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentailExists(int id)
        {
            return _context.Rentails.Any(e => e.Id == id);
        }

        [HttpPost]
        private async Task<IActionResult> ReturnBook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentail = await _context.Rentails
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (rentail == null)
            {
                return NotFound();
            }
            rentail.ReturnDate = (DateTime?)DateTime.Now;
            _context.Update(rentail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
