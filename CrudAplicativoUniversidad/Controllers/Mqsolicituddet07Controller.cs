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
    public class Mqsolicituddet07Controller : Controller
    {
        private readonly PruebaUniversidadContext _context;

        public Mqsolicituddet07Controller(PruebaUniversidadContext context)
        {
            _context = context;
        }

        // GET: Mqsolicituddet07
        public async Task<IActionResult> Index()
        {
            var pruebaUniversidadContext = _context.Mqsolicituddet07s.Include(m => m.IdCurso02Navigation).Include(m => m.IdProfesor04Navigation).Include(m => m.IdSolicitud06Navigation);
            return View(await pruebaUniversidadContext.ToListAsync());
        }

        // GET: Mqsolicituddet07/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mqsolicituddet07s == null)
            {
                return NotFound();
            }

            var mqsolicituddet07 = await _context.Mqsolicituddet07s
                .Include(m => m.IdCurso02Navigation)
                .Include(m => m.IdProfesor04Navigation)
                .Include(m => m.IdSolicitud06Navigation)
                .FirstOrDefaultAsync(m => m.Id07 == id);
            if (mqsolicituddet07 == null)
            {
                return NotFound();
            }

            return View(mqsolicituddet07);
        }

        // GET: Mqsolicituddet07/Create
        public IActionResult Create()
        {
            ViewData["IdCurso02"] = new SelectList(_context.Mdcursos02s.Where(n => n.Activo02 == 1), "Id02", "Nombre02");
            ViewData["IdProfesor04"] = new SelectList(_context.Mdtrabajador04s.Where(n => n.IdTipo03 ==1), "Id04", "Nombres04");
            ViewData["IdSolicitud06"] = new SelectList(_context.Mqsolicitudcab06s, "Id06", "Id06");
            return View();
        }

        // POST: Mqsolicituddet07/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id07,IdSolicitud06,IdCurso02,IdProfesor04,Aula07,Sede07,Observacion07")] Mqsolicituddet07 mqsolicituddet07)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(mqsolicituddet07);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["IdCurso02"] = new SelectList(_context.Mdcursos02s, "Id02", "Id02", mqsolicituddet07.IdCurso02);
            ViewData["IdProfesor04"] = new SelectList(_context.Mdtrabajador04s, "Id04", "Id04", mqsolicituddet07.IdProfesor04);
            ViewData["IdSolicitud06"] = new SelectList(_context.Mqsolicitudcab06s, "Id06", "Id06", mqsolicituddet07.IdSolicitud06);
            return View(mqsolicituddet07);
        }

        // GET: Mqsolicituddet07/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mqsolicituddet07s == null)
            {
                return NotFound();
            }

            var mqsolicituddet07 = await _context.Mqsolicituddet07s.FindAsync(id);
            if (mqsolicituddet07 == null)
            {
                return NotFound();
            }
            ViewData["IdCurso02"] = new SelectList(_context.Mdcursos02s, "Id02", "Id02", mqsolicituddet07.IdCurso02);
            ViewData["IdProfesor04"] = new SelectList(_context.Mdtrabajador04s, "Id04", "Id04", mqsolicituddet07.IdProfesor04);
            ViewData["IdSolicitud06"] = new SelectList(_context.Mqsolicitudcab06s, "Id06", "Id06", mqsolicituddet07.IdSolicitud06);
            return View(mqsolicituddet07);
        }

        // POST: Mqsolicituddet07/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id07,IdSolicitud06,IdCurso02,IdProfesor04,Aula07,Sede07,Observacion07")] Mqsolicituddet07 mqsolicituddet07)
        {
            if (id != mqsolicituddet07.Id07)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(mqsolicituddet07);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mqsolicituddet07Exists(mqsolicituddet07.Id07))
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
            ViewData["IdCurso02"] = new SelectList(_context.Mdcursos02s, "Id02", "Id02", mqsolicituddet07.IdCurso02);
            ViewData["IdProfesor04"] = new SelectList(_context.Mdtrabajador04s, "Id04", "Id04", mqsolicituddet07.IdProfesor04);
            ViewData["IdSolicitud06"] = new SelectList(_context.Mqsolicitudcab06s, "Id06", "Id06", mqsolicituddet07.IdSolicitud06);
            return View(mqsolicituddet07);
        }

        // GET: Mqsolicituddet07/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mqsolicituddet07s == null)
            {
                return NotFound();
            }

            var mqsolicituddet07 = await _context.Mqsolicituddet07s
                .Include(m => m.IdCurso02Navigation)
                .Include(m => m.IdProfesor04Navigation)
                .Include(m => m.IdSolicitud06Navigation)
                .FirstOrDefaultAsync(m => m.Id07 == id);
            if (mqsolicituddet07 == null)
            {
                return NotFound();
            }

            return View(mqsolicituddet07);
        }

        // POST: Mqsolicituddet07/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mqsolicituddet07s == null)
            {
                return Problem("Entity set 'PruebaUniversidadContext.Mqsolicituddet07s'  is null.");
            }
            var mqsolicituddet07 = await _context.Mqsolicituddet07s.FindAsync(id);
            if (mqsolicituddet07 != null)
            {
                _context.Mqsolicituddet07s.Remove(mqsolicituddet07);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mqsolicituddet07Exists(int id)
        {
          return _context.Mqsolicituddet07s.Any(e => e.Id07 == id);
        }
    }
}
