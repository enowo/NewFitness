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
    public class PosilekController : Controller
    {
        private readonly MyContext _context;

        public PosilekController(MyContext context)
        {
            _context = context;
        }

        // GET: Posilek
        public async Task<IActionResult> Index()
        {
            var myContext = _context.posilki.Include(p => p.uzytkownik);
            return View(await myContext.ToListAsync());
        }

        // GET: Posilek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posilek = await _context.posilki
                .Include(p => p.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_posilku == id);
            if (posilek == null)
            {
                return NotFound();
            }

            return View(posilek);
        }

        // GET: Posilek/Create
        public IActionResult Create()
        {
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id");
            return View();
        }

        // POST: Posilek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_posilku,nazwa,kalorie,opis,id_uzytkownika")] Posilek posilek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posilek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", posilek.id_uzytkownika);
            return View(posilek);
        }

        // GET: Posilek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posilek = await _context.posilki.FindAsync(id);
            if (posilek == null)
            {
                return NotFound();
            }
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", posilek.id_uzytkownika);
            return View(posilek);
        }

        // POST: Posilek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_posilku,nazwa,kalorie,opis,id_uzytkownika")] Posilek posilek)
        {
            if (id != posilek.id_posilku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posilek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosilekExists(posilek.id_posilku))
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
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "Id", "Id", posilek.id_uzytkownika);
            return View(posilek);
        }

        // GET: Posilek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posilek = await _context.posilki
                .Include(p => p.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_posilku == id);
            if (posilek == null)
            {
                return NotFound();
            }

            return View(posilek);
        }

        // POST: Posilek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posilek = await _context.posilki.FindAsync(id);
            _context.posilki.Remove(posilek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosilekExists(int id)
        {
            return _context.posilki.Any(e => e.id_posilku == id);
        }
    }
}
