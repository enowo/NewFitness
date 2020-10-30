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
    public class TreningController : Controller
    {
        private readonly MyContext _context;

        public TreningController(MyContext context)
        {
            _context = context;
        }

        // GET: Trening
        public async Task<IActionResult> Index()
        {
            var myContext = _context.treningi.Include(t => t.kategoria).Include(t => t.uzytkownik);
            return View(await myContext.ToListAsync());
        }

        // GET: Trening/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.treningi
                .Include(t => t.kategoria)
                .Include(t => t.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_treningu == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // GET: Trening/Create
        public IActionResult Create()
        {
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaTreningu, "id_kategorii", "nazwa");
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id");
            return View();
        }

        // POST: Trening/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_treningu,nazwa,id_kategorii,id_uzytkownika")] Trening trening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaTreningu, "id_kategorii", "nazwa", trening.id_kategorii);
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", trening.id_uzytkownika);
            return View(trening);
        }

        // GET: Trening/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.treningi.FindAsync(id);
            if (trening == null)
            {
                return NotFound();
            }
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaTreningu, "id_kategorii", "nazwa", trening.id_kategorii);
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", trening.id_uzytkownika);
            return View(trening);
        }

        // POST: Trening/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_treningu,nazwa,id_kategorii,id_uzytkownika")] Trening trening)
        {
            if (id != trening.id_treningu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreningExists(trening.id_treningu))
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
            ViewData["id_kategorii"] = new SelectList(_context.kategoriaTreningu, "id_kategorii", "nazwa", trening.id_kategorii);
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", trening.id_uzytkownika);
            return View(trening);
        }

        // GET: Trening/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.treningi
                .Include(t => t.kategoria)
                .Include(t => t.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_treningu == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // POST: Trening/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trening = await _context.treningi.FindAsync(id);
            _context.treningi.Remove(trening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreningExists(int id)
        {
            return _context.treningi.Any(e => e.id_treningu == id);
        }
    }
}
