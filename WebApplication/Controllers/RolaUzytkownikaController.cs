using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RolaUzytkownikaController : Controller
    {
        private readonly MyContext _context;

        public RolaUzytkownikaController(MyContext context)
        {
            _context = context;
        }

        // GET: RolaUzytkownika
        public async Task<IActionResult> Index()
        {
            var myContext = _context.RolaUzytkownika.Include(r => r.rola).Include(r => r.uzytkownik);
            return View(await myContext.ToListAsync());
        }

        // GET: RolaUzytkownika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolaUzytkownika = await _context.RolaUzytkownika
                .Include(r => r.rola)
                .Include(r => r.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_roli == id);
            if (rolaUzytkownika == null)
            {
                return NotFound();
            }

            return View(rolaUzytkownika);
        }

        // GET: RolaUzytkownika/Create
        public IActionResult Create()
        {
            ViewData["id_roli"] = new SelectList(_context.role, "id_roli", "nazwa");
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id");
            return View();
        }

        // POST: RolaUzytkownika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_uzytkownika,id_roli")] RolaUzytkownika rolaUzytkownika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolaUzytkownika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_roli"] = new SelectList(_context.role, "id_roli", "nazwa", rolaUzytkownika.id_roli);
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", rolaUzytkownika.id_uzytkownika);
            return View(rolaUzytkownika);
        }

        // GET: RolaUzytkownika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolaUzytkownika = await _context.RolaUzytkownika.FindAsync(id);
            if (rolaUzytkownika == null)
            {
                return NotFound();
            }
            ViewData["id_roli"] = new SelectList(_context.role, "id_roli", "nazwa", rolaUzytkownika.id_roli);
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", rolaUzytkownika.id_uzytkownika);
            return View(rolaUzytkownika);
        }

        // POST: RolaUzytkownika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_uzytkownika,id_roli")] RolaUzytkownika rolaUzytkownika)
        {
            if (id != rolaUzytkownika.id_roli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolaUzytkownika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolaUzytkownikaExists(rolaUzytkownika.id_roli))
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
            ViewData["id_roli"] = new SelectList(_context.role, "id_roli", "nazwa", rolaUzytkownika.id_roli);
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", rolaUzytkownika.id_uzytkownika);
            return View(rolaUzytkownika);
        }

        // GET: RolaUzytkownika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolaUzytkownika = await _context.RolaUzytkownika
                .Include(r => r.rola)
                .Include(r => r.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_roli == id);
            if (rolaUzytkownika == null)
            {
                return NotFound();
            }

            return View(rolaUzytkownika);
        }

        // POST: RolaUzytkownika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolaUzytkownika = await _context.RolaUzytkownika.FindAsync(id);
            _context.RolaUzytkownika.Remove(rolaUzytkownika);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolaUzytkownikaExists(int id)
        {
            return _context.RolaUzytkownika.Any(e => e.id_roli == id);
        }
    }
}
