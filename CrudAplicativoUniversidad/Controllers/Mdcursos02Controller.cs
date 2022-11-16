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
    public class Mdcursos02Controller : Controller
    {
        private readonly PruebaUniversidadContext _context;

        public Mdcursos02Controller(PruebaUniversidadContext context)
        {
            _context = context;
        }

        // GET: Mdcursos02
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mdcursos02s.ToListAsync());
        }

        // GET: Mdcursos02/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mdcursos02s == null)
            {
                return NotFound();
            }

            var mdcursos02 = await _context.Mdcursos02s
                .FirstOrDefaultAsync(m => m.Id02 == id);
            if (mdcursos02 == null)
            {
                return NotFound();
            }

            return View(mdcursos02);
        }

        // GET: Mdcursos02/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mdcursos02/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id02,Nombre02,Descripcion02,NroCreditos02,Activo02")] Mdcursos02 mdcursos02)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdcursos02);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdcursos02);
        }

        // GET: Mdcursos02/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mdcursos02s == null)
            {
                return NotFound();
            }

            var mdcursos02 = await _context.Mdcursos02s.FindAsync(id);
            if (mdcursos02 == null)
            {
                return NotFound();
            }
            return View(mdcursos02);
        }

        // POST: Mdcursos02/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id02,Nombre02,Descripcion02,NroCreditos02,Activo02")] Mdcursos02 mdcursos02)
        {
            if (id != mdcursos02.Id02)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdcursos02);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mdcursos02Exists(mdcursos02.Id02))
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
            return View(mdcursos02);
        }

        // GET: Mdcursos02/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mdcursos02s == null)
            {
                return NotFound();
            }

            var mdcursos02 = await _context.Mdcursos02s
                .FirstOrDefaultAsync(m => m.Id02 == id);
            if (mdcursos02 == null)
            {
                return NotFound();
            }

            return View(mdcursos02);
        }

        // POST: Mdcursos02/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mdcursos02s == null)
            {
                return Problem("Entity set 'PruebaUniversidadContext.Mdcursos02s'  is null.");
            }
            var mdcursos02 = await _context.Mdcursos02s.FindAsync(id);
            if (mdcursos02 != null)
            {
                _context.Mdcursos02s.Remove(mdcursos02);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mdcursos02Exists(int id)
        {
          return _context.Mdcursos02s.Any(e => e.Id02 == id);
        }
    }
}
