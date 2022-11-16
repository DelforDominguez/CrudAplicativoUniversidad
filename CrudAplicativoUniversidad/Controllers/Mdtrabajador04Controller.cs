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
    public class Mdtrabajador04Controller : Controller
    {
        private readonly PruebaUniversidadContext _context;

        public Mdtrabajador04Controller(PruebaUniversidadContext context)
        {
            _context = context;
        }

        // GET: Mdtrabajador04
        public async Task<IActionResult> Index()
        {
            var pruebaUniversidadContext = _context.Mdtrabajador04s.Include(m => m.IdTipo03Navigation);
            return View(await pruebaUniversidadContext.ToListAsync());
        }

        // GET: Mdtrabajador04/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mdtrabajador04s == null)
            {
                return NotFound();
            }

            var mdtrabajador04 = await _context.Mdtrabajador04s
                .Include(m => m.IdTipo03Navigation)
                .FirstOrDefaultAsync(m => m.Id04 == id);
            if (mdtrabajador04 == null)
            {
                return NotFound();
            }

            return View(mdtrabajador04);
        }

        // GET: Mdtrabajador04/Create
        public IActionResult Create()
        {
            ViewData["IdTipo03"] = new SelectList(_context.Mdtipocolaborador03s, "Id03", "Tipo03");
            return View();
        }

        // POST: Mdtrabajador04/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id04,Nombres04,Apellidos04,IdTipo03")] Mdtrabajador04 mdtrabajador04)
        {

            //if (ModelState.IsValid)
            //{
                _context.Add(mdtrabajador04);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["IdTipo03"] = new SelectList(_context.Mdtipocolaborador03s, "Id03", "Id03", mdtrabajador04.IdTipo03);
            return View(mdtrabajador04);
        }

        // GET: Mdtrabajador04/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mdtrabajador04s == null)
            {
                return NotFound();
            }

            var mdtrabajador04 = await _context.Mdtrabajador04s.FindAsync(id);
            if (mdtrabajador04 == null)
            {
                return NotFound();
            }
            ViewData["IdTipo03"] = new SelectList(_context.Mdtipocolaborador03s, "Id03", "Id03", mdtrabajador04.IdTipo03);
            return View(mdtrabajador04);
        }

        // POST: Mdtrabajador04/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id04,Nombres04,Apellidos04,IdTipo03")] Mdtrabajador04 mdtrabajador04)
        {
            if (id != mdtrabajador04.Id04)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(mdtrabajador04);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mdtrabajador04Exists(mdtrabajador04.Id04))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["IdTipo03"] = new SelectList(_context.Mdtipocolaborador03s, "Id03", "Id03", mdtrabajador04.IdTipo03);
            return View(mdtrabajador04);
        }

        // GET: Mdtrabajador04/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mdtrabajador04s == null)
            {
                return NotFound();
            }

            var mdtrabajador04 = await _context.Mdtrabajador04s
                .Include(m => m.IdTipo03Navigation)
                .FirstOrDefaultAsync(m => m.Id04 == id);
            if (mdtrabajador04 == null)
            {
                return NotFound();
            }

            return View(mdtrabajador04);
        }

        // POST: Mdtrabajador04/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mdtrabajador04s == null)
            {
                return Problem("Entity set 'PruebaUniversidadContext.Mdtrabajador04s'  is null.");
            }
            var mdtrabajador04 = await _context.Mdtrabajador04s.FindAsync(id);
            if (mdtrabajador04 != null)
            {
                _context.Mdtrabajador04s.Remove(mdtrabajador04);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mdtrabajador04Exists(int id)
        {
          return _context.Mdtrabajador04s.Any(e => e.Id04 == id);
        }
    }
}
