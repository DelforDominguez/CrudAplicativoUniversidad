using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAplicativoUniversidad.Models;

namespace CrudAplicativoUniversidad.Controllers
{
    public class Mdcarreras05Controller : Controller
    {
        private readonly PruebaUniversidadContext _context;

        public Mdcarreras05Controller(PruebaUniversidadContext context)
        {
            _context = context;
        }

        // GET: Mdcarreras05
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mdcarreras05s.ToListAsync());
        }

        // GET: Mdcarreras05/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mdcarreras05s == null)
            {
                return NotFound();
            }

            var mdcarreras05 = await _context.Mdcarreras05s
                .FirstOrDefaultAsync(m => m.Id05 == id);
            if (mdcarreras05 == null)
            {
                return NotFound();
            }

            return View(mdcarreras05);
        }

        // GET: Mdcarreras05/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mdcarreras05/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id05,Descripcion05")] Mdcarreras05 mdcarreras05)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdcarreras05);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdcarreras05);
        }

        // GET: Mdcarreras05/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mdcarreras05s == null)
            {
                return NotFound();
            }

            var mdcarreras05 = await _context.Mdcarreras05s.FindAsync(id);
            if (mdcarreras05 == null)
            {
                return NotFound();
            }
            return View(mdcarreras05);
        }

        // POST: Mdcarreras05/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id05,Descripcion05")] Mdcarreras05 mdcarreras05)
        {
            if (id != mdcarreras05.Id05)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdcarreras05);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mdcarreras05Exists(mdcarreras05.Id05))
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
            return View(mdcarreras05);
        }

        // GET: Mdcarreras05/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mdcarreras05s == null)
            {
                return NotFound();
            }

            var mdcarreras05 = await _context.Mdcarreras05s
                .FirstOrDefaultAsync(m => m.Id05 == id);
            if (mdcarreras05 == null)
            {
                return NotFound();
            }

            return View(mdcarreras05);
        }

        // POST: Mdcarreras05/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mdcarreras05s == null)
            {
                return Problem("Entity set 'PruebaUniversidadContext.Mdcarreras05s'  is null.");
            }
            var mdcarreras05 = await _context.Mdcarreras05s.FindAsync(id);
            if (mdcarreras05 != null)
            {
                _context.Mdcarreras05s.Remove(mdcarreras05);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mdcarreras05Exists(int id)
        {
          return _context.Mdcarreras05s.Any(e => e.Id05 == id);
        }
    }
}
