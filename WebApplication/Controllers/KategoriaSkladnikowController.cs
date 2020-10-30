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
    public class KategoriaSkladnikowController : Controller
    {
        private readonly MyContext _context;

        public KategoriaSkladnikowController(MyContext context)
        {
            _context = context;
        }

        // GET: KategoriaSkladnikow
        public async Task<IActionResult> Index()
        {
            return View(await _context.kategoriaSkladnikow.ToListAsync());
        }

        // GET: KategoriaSkladnikow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaSkladnikow = await _context.kategoriaSkladnikow
                .FirstOrDefaultAsync(m => m.id_kategorii == id);
            if (kategoriaSkladnikow == null)
            {
                return NotFound();
            }

            return View(kategoriaSkladnikow);
        }

        // GET: KategoriaSkladnikow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategoriaSkladnikow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_kategorii,nazwa")] KategoriaSkladnikow kategoriaSkladnikow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriaSkladnikow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriaSkladnikow);
        }

        // GET: KategoriaSkladnikow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaSkladnikow = await _context.kategoriaSkladnikow.FindAsync(id);
            if (kategoriaSkladnikow == null)
            {
                return NotFound();
            }
            return View(kategoriaSkladnikow);
        }

        // POST: KategoriaSkladnikow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_kategorii,nazwa")] KategoriaSkladnikow kategoriaSkladnikow)
        {
            if (id != kategoriaSkladnikow.id_kategorii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriaSkladnikow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriaSkladnikowExists(kategoriaSkladnikow.id_kategorii))
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
            return View(kategoriaSkladnikow);
        }

        // GET: KategoriaSkladnikow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaSkladnikow = await _context.kategoriaSkladnikow
                .FirstOrDefaultAsync(m => m.id_kategorii == id);
            if (kategoriaSkladnikow == null)
            {
                return NotFound();
            }

            return View(kategoriaSkladnikow);
        }

        // POST: KategoriaSkladnikow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategoriaSkladnikow = await _context.kategoriaSkladnikow.FindAsync(id);
            _context.kategoriaSkladnikow.Remove(kategoriaSkladnikow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriaSkladnikowExists(int id)
        {
            return _context.kategoriaSkladnikow.Any(e => e.id_kategorii == id);
        }
    }
}
