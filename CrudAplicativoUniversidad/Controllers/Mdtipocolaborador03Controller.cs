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
    public class Mdtipocolaborador03Controller : Controller
    {
        private readonly PruebaUniversidadContext _context;

        public Mdtipocolaborador03Controller(PruebaUniversidadContext context)
        {
            _context = context;
        }

        // GET: Mdtipocolaborador03
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mdtipocolaborador03s.ToListAsync());
        }

        // GET: Mdtipocolaborador03/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mdtipocolaborador03s == null)
            {
                return NotFound();
            }

            var mdtipocolaborador03 = await _context.Mdtipocolaborador03s
                .FirstOrDefaultAsync(m => m.Id03 == id);
            if (mdtipocolaborador03 == null)
            {
                return NotFound();
            }

            return View(mdtipocolaborador03);
        }

        // GET: Mdtipocolaborador03/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mdtipocolaborador03/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id03,Tipo03")] Mdtipocolaborador03 mdtipocolaborador03)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdtipocolaborador03);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdtipocolaborador03);
        }

        // GET: Mdtipocolaborador03/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mdtipocolaborador03s == null)
            {
                return NotFound();
            }

            var mdtipocolaborador03 = await _context.Mdtipocolaborador03s.FindAsync(id);
            if (mdtipocolaborador03 == null)
            {
                return NotFound();
            }
            return View(mdtipocolaborador03);
        }

        // POST: Mdtipocolaborador03/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id03,Tipo03")] Mdtipocolaborador03 mdtipocolaborador03)
        {
            if (id != mdtipocolaborador03.Id03)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdtipocolaborador03);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mdtipocolaborador03Exists(mdtipocolaborador03.Id03))
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
            return View(mdtipocolaborador03);
        }

        // GET: Mdtipocolaborador03/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mdtipocolaborador03s == null)
            {
                return NotFound();
            }

            var mdtipocolaborador03 = await _context.Mdtipocolaborador03s
                .FirstOrDefaultAsync(m => m.Id03 == id);
            if (mdtipocolaborador03 == null)
            {
                return NotFound();
            }

            return View(mdtipocolaborador03);
        }

        // POST: Mdtipocolaborador03/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mdtipocolaborador03s == null)
            {
                return Problem("Entity set 'PruebaUniversidadContext.Mdtipocolaborador03s'  is null.");
            }
            var mdtipocolaborador03 = await _context.Mdtipocolaborador03s.FindAsync(id);
            if (mdtipocolaborador03 != null)
            {
                _context.Mdtipocolaborador03s.Remove(mdtipocolaborador03);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mdtipocolaborador03Exists(int id)
        {
          return _context.Mdtipocolaborador03s.Any(e => e.Id03 == id);
        }
    }
}
