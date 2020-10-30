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
    public class KategoriaCwiczeniaController : Controller
    {
        private readonly MyContext _context;

        public KategoriaCwiczeniaController(MyContext context)
        {
            _context = context;
        }

        // GET: KategoriaCwiczenia
        public async Task<IActionResult> Index()
        {
            return View(await _context.kategoriaCwiczenia.ToListAsync());
        }

        // GET: KategoriaCwiczenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaCwiczenia = await _context.kategoriaCwiczenia
                .FirstOrDefaultAsync(m => m.id_kategorii == id);
            if (kategoriaCwiczenia == null)
            {
                return NotFound();
            }

            return View(kategoriaCwiczenia);
        }

        // GET: KategoriaCwiczenia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategoriaCwiczenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_kategorii,nazwa")] KategoriaCwiczenia kategoriaCwiczenia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriaCwiczenia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriaCwiczenia);
        }

        // GET: KategoriaCwiczenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaCwiczenia = await _context.kategoriaCwiczenia.FindAsync(id);
            if (kategoriaCwiczenia == null)
            {
                return NotFound();
            }
            return View(kategoriaCwiczenia);
        }

        // POST: KategoriaCwiczenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_kategorii,nazwa")] KategoriaCwiczenia kategoriaCwiczenia)
        {
            if (id != kategoriaCwiczenia.id_kategorii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriaCwiczenia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriaCwiczeniaExists(kategoriaCwiczenia.id_kategorii))
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
            return View(kategoriaCwiczenia);
        }

        // GET: KategoriaCwiczenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaCwiczenia = await _context.kategoriaCwiczenia
                .FirstOrDefaultAsync(m => m.id_kategorii == id);
            if (kategoriaCwiczenia == null)
            {
                return NotFound();
            }

            return View(kategoriaCwiczenia);
        }

        // POST: KategoriaCwiczenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategoriaCwiczenia = await _context.kategoriaCwiczenia.FindAsync(id);
            _context.kategoriaCwiczenia.Remove(kategoriaCwiczenia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriaCwiczeniaExists(int id)
        {
            return _context.kategoriaCwiczenia.Any(e => e.id_kategorii == id);
        }
    }
}
