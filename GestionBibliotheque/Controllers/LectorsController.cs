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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionBibliotheque.Controllers
{
    public class LectorsController : Controller
    {
        private readonly LibraryContext _context;

        public LectorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Lectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lectors.Include(l => l.Address).ToListAsync());
        }

        // GET: Lectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lector = await _context.Lectors
                .Include(l => l.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lector == null)
            {
                return NotFound();
            }

            return View(lector);
        }

        // GET: Lectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LectorViewModel lvm)
        
        {
            if (ModelState.IsValid)
            {
                var address = new Address() {
                    Apt = lvm.Apt ?? "",
                    Number = lvm.Number,
                    City = lvm.City,    
                    Country= lvm.Country,
                    Street = lvm.Street,
                    ZipCode = lvm.ZipCode
                };
                _context.Add(address);

                var lector = new Lector() {
                    Firstname = lvm.Firstname,
                    Lastname = lvm.Lastname,
                    Email = lvm.Email,
                    Password = lvm.Password,
                    Phone = lvm.Phone,
                    Address = address
                };

                _context.Add(lector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lvm);
        }

        // GET: Lectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lector = await _context.Lectors
                .Where(l => l.Id == id)
                .Include(a => a.Address)
                .FirstOrDefaultAsync();

            if (lector == null)
            {
                return NotFound();
            }

            var lvm = new LectorViewModel() {
                Id = lector.Id,
                Firstname = lector.Firstname,
                Lastname = lector.Lastname,
                Email = lector.Email,
                Password = lector.Password,
                Phone = lector.Phone,
                AdressId = lector.Address.Id,
                Apt = lector.Address.Apt,
                City = lector.Address.City,
                Country = lector.Address.Country,
                Number = lector.Address.Number,
                Street = lector.Address.Street,
                ZipCode = lector.Address.ZipCode,
            };

            return View(lvm);
        }

        // POST: Lectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LectorViewModel lvm)
        {
            if (id != lvm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var address = new Address() {
                        Id = (int)lvm.AdressId,
                        Apt = lvm.Apt,
                        Number = lvm.Number,
                        City = lvm.City,
                        Country = lvm.Country,
                        Street = lvm.Street,
                        ZipCode = lvm.ZipCode
                    };

                    var lector = new Lector() {
                        Id = lvm.Id,
                        Firstname = lvm.Firstname,
                        Lastname = lvm.Lastname,
                        Email = lvm.Email,
                        Password = lvm.Password,
                        Phone = lvm.Phone,
                    };

                    _context.Update(address);
                    _context.Update(lector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectorExists(lvm.Id))
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
            return View(lvm);
        }

        // GET: Lectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lector = await _context.Lectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lector == null)
            {
                return NotFound();
            }

            return View(lector);
        }

        // POST: Lectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lector = await _context.Lectors.FindAsync(id);
            if (lector != null)
            {
                _context.Lectors.Remove(lector);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectorExists(int id)
        {
            return _context.Lectors.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult GetLectorsBySearch(string search)
        {
            var lectors = _context.Lectors
                .Where(l => l.Firstname.Contains(search) || l.Lastname.Contains(search))
                .Select(l => new { l.Firstname, l.Lastname, l.Id})
                .ToList();

            return Json(lectors);
        }
    }
}
