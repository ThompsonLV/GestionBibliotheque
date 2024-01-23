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
    public class DomainsController : Controller
    {
        private readonly LibraryContext _context;

        public DomainsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Domains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Domains.ToListAsync());
        }

        // GET: Domains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domain = await _context.Domains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domain == null)
            {
                return NotFound();
            }

            return View(domain);
        }

        // GET: Domains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Domains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DomainViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var domain = new Domain()
                {
                    Name = dvm.Name,
                    Description = dvm.Description,
                };
                _context.Add(domain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dvm);
        }

        // GET: Domains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domain = await _context.Domains.FindAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            var dvm = new DomainViewModel()
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
            };
            return View(dvm);
        }

        // POST: Domains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DomainViewModel dvm)
        {
            if (id != dvm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var domain = new Domain()
                    {
                        Id = dvm.Id,
                        Name = dvm.Name,
                        Description = dvm.Description,
                    };
                    _context.Update(domain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomainExists(dvm.Id))
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
            return View(dvm);
        }

        // GET: Domains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domain = await _context.Domains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domain == null)
            {
                return NotFound();
            }

            return View(domain);
        }

        // POST: Domains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domain = await _context.Domains.FindAsync(id);
            if (domain != null)
            {
                _context.Domains.Remove(domain);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomainExists(int id)
        {
            return _context.Domains.Any(e => e.Id == id);
        }
    }
}
