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
    public class SkladnikController : Controller
    {
        private readonly MyContext _context;

        public SkladnikController(MyContext context)
        {
            _context = context;
        }

        // GET: Skladnik
        public async Task<IActionResult> Index()
        {
            var myContext = _context.skladnik.Include(s => s.kategoria);
            return View(await myContext.ToListAsync());
        }

        // GET: Skladnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladnik = await _context.skladnik
                .Include(s => s.kategoria)
                .FirstOrDefaultAsync(m => m.id_skladnika == id);
            if (skladnik == null)
            {
                return NotFound();
            }

            return View(skladnik);
        }

        // GET: Skladnik/Create
        public IActionResult Create()
        {
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaSkladnikow, "id_kategorii", "nazwa");
            return View();
        }

        // POST: Skladnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_skladnika,waga,kalorie,id_kategorii")] Skladnik skladnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skladnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaSkladnikow, "id_kategorii", "nazwa", skladnik.id_kategorii);
            return View(skladnik);
        }

        // GET: Skladnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladnik = await _context.skladnik.FindAsync(id);
            if (skladnik == null)
            {
                return NotFound();
            }
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaSkladnikow, "id_kategorii", "nazwa", skladnik.id_kategorii);
            return View(skladnik);
        }

        // POST: Skladnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_skladnika,waga,kalorie,id_kategorii")] Skladnik skladnik)
        {
            if (id != skladnik.id_skladnika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skladnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkladnikExists(skladnik.id_skladnika))
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
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaSkladnikow, "id_kategorii", "nazwa", skladnik.id_kategorii);
            return View(skladnik);
        }

        // GET: Skladnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladnik = await _context.skladnik
                .Include(s => s.kategoria)
                .FirstOrDefaultAsync(m => m.id_skladnika == id);
            if (skladnik == null)
            {
                return NotFound();
            }

            return View(skladnik);
        }

        // POST: Skladnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skladnik = await _context.skladnik.FindAsync(id);
            _context.skladnik.Remove(skladnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkladnikExists(int id)
        {
            return _context.skladnik.Any(e => e.id_skladnika == id);
        }
    }
}
