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
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorsList"] = new SelectList(_context.Authors.ToList(),"Id", "Firstname");
            ViewData["DomainsList"] = new SelectList(_context.Domains.ToList(), "Id", "Name");

            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel bvm)
        {
            
            if (ModelState.IsValid)
            {
                var author = await _context.Authors.FindAsync(bvm.AuthorId);
                var domain = await _context.Domains.FindAsync(bvm.DomainId);

                var book = new Book()
                { 
                    Title = bvm.Title,
                    Nbpages = bvm.Nbpages,
                    Description = bvm.Description,
                    Author = author,
                    Domain = domain
                };
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bvm);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Where(b => b.Id == id)
                .Include(a => a.Author)
                .Include(d => d.Domain)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            var bvm = new BookViewModel() {
                Id = book.Id,
                Title = book.Title,
                Nbpages = book.Nbpages,
                Description = book.Description,
                DomainId = book.Domain.Id,
                AuthorId = book.Author.Id
            };

            ViewData["AuthorsList"] = new SelectList(_context.Authors.ToList(), "Id", "Firstname");
            ViewData["DomainsList"] = new SelectList(_context.Domains.ToList(), "Id", "Name");

            return View(bvm);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewModel bvm)
        {
            if (id != bvm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var author = await _context.Authors.FindAsync(bvm.AuthorId);
                    var domain = await _context.Domains.FindAsync(bvm.DomainId);

                    var book = new Book() {
                        Title = bvm.Title,
                        Nbpages = bvm.Nbpages,
                        Description = bvm.Description,
                        Author = author,
                        Domain = domain
                    };

                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(bvm.Id))
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
            return View(bvm);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult GetBooksBySearch(string search)
        {
            var books = _context.Books
                .Include(b => b.Author)
                .Where(b => b.Title.Contains(search) || b.Author.Firstname.Contains(search) || b.Author.Lastname.Contains(search))
                .Select(b => new { b.Title, b.Author.Firstname, b.Author.Lastname, b.Id })
                .ToList();

            return Json(books);
        }
    }
}
