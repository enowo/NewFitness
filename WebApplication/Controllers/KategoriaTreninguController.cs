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
    public class KategoriaTreninguController : Controller
    {
        private readonly MyContext _context;

        public KategoriaTreninguController(MyContext context)
        {
            _context = context;
        }

        // GET: KategoriaTreningu
        public async Task<IActionResult> Index()
        {
            return View(await _context.kategoriaTreningu.ToListAsync());
        }

        // GET: KategoriaTreningu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaTreningu = await _context.kategoriaTreningu
                .FirstOrDefaultAsync(m => m.id_kategorii == id);
            if (kategoriaTreningu == null)
            {
                return NotFound();
            }

            return View(kategoriaTreningu);
        }

        // GET: KategoriaTreningu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategoriaTreningu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_kategorii,nazwa")] KategoriaTreningu kategoriaTreningu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriaTreningu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriaTreningu);
        }

        // GET: KategoriaTreningu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaTreningu = await _context.kategoriaTreningu.FindAsync(id);
            if (kategoriaTreningu == null)
            {
                return NotFound();
            }
            return View(kategoriaTreningu);
        }

        // POST: KategoriaTreningu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_kategorii,nazwa")] KategoriaTreningu kategoriaTreningu)
        {
            if (id != kategoriaTreningu.id_kategorii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriaTreningu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriaTreninguExists(kategoriaTreningu.id_kategorii))
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
            return View(kategoriaTreningu);
        }

        // GET: KategoriaTreningu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaTreningu = await _context.kategoriaTreningu
                .FirstOrDefaultAsync(m => m.id_kategorii == id);
            if (kategoriaTreningu == null)
            {
                return NotFound();
            }

            return View(kategoriaTreningu);
        }

        // POST: KategoriaTreningu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategoriaTreningu = await _context.kategoriaTreningu.FindAsync(id);
            _context.kategoriaTreningu.Remove(kategoriaTreningu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriaTreninguExists(int id)
        {
            return _context.kategoriaTreningu.Any(e => e.id_kategorii == id);
        }
    }
}
