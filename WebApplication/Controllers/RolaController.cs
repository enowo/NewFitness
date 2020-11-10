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
    public class RolaController : Controller
    {
        private readonly MyContext _context;

        public RolaController(MyContext context)
        {
            _context = context;
        }

        // GET: Rolas
        public async Task<IActionResult> Index()
        {
            return View(await _context.role.ToListAsync());
        }

        // GET: Rolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rola = await _context.role
                .FirstOrDefaultAsync(m => m.id_roli == id);
            if (rola == null)
            {
                return NotFound();
            }

            return View(rola);
        }

        // GET: Rolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_roli,nazwa")] Rola rola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rola);
        }

        // GET: Rolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rola = await _context.role.FindAsync(id);
            if (rola == null)
            {
                return NotFound();
            }
            return View(rola);
        }

        // POST: Rolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_roli,nazwa")] Rola rola)
        {
            if (id != rola.id_roli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolaExists(rola.id_roli))
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
            return View(rola);
        }

        // GET: Rolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rola = await _context.role
                .FirstOrDefaultAsync(m => m.id_roli == id);
            if (rola == null)
            {
                return NotFound();
            }

            return View(rola);
        }

        // POST: Rolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rola = await _context.role.FindAsync(id);
            _context.role.Remove(rola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolaExists(int id)
        {
            return _context.role.Any(e => e.id_roli == id);
        }
    }
}
