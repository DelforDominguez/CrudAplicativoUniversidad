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
    public class Mqsolicitudcab06Controller : Controller
    {
        private readonly PruebaUniversidadContext _context;

        public Mqsolicitudcab06Controller(PruebaUniversidadContext context)
        {
            _context = context;
        }

        // GET: Mqsolicitudcab06
        public async Task<IActionResult> Index()
        {
            var pruebaUniversidadContext = _context.Mqsolicitudcab06s.Include(m => m.Carrera05Navigation).Include(m => m.IdAlumno01Navigation).Include(m => m.IdRegistrante04Navigation);
            return View(await pruebaUniversidadContext.ToListAsync());
        }

        // GET: Mqsolicitudcab06/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mqsolicitudcab06s == null)
            {
                return NotFound();
            }

            var mqsolicitudcab06 = await _context.Mqsolicitudcab06s
                .Include(m => m.Carrera05Navigation)
                .Include(m => m.IdAlumno01Navigation)
                .Include(m => m.IdRegistrante04Navigation)
                .FirstOrDefaultAsync(m => m.Id06 == id);
            if (mqsolicitudcab06 == null)
            {
                return NotFound();
            }

            return View(mqsolicitudcab06);
        }

        // GET: Mqsolicitudcab06/Create
        public IActionResult Create()
        {
            ViewData["Carrera05"] = new SelectList(_context.Mdcarreras05s, "Id05", "Descripcion05");
            ViewData["IdAlumno01"] = new SelectList(_context.Mdalumno01s, "Id01", "Nombres01");
            ViewData["IdRegistrante04"] = new SelectList(_context.Mdtrabajador04s.Where(n => n.IdTipo03 == 2), "Id04", "Nombres04");
            return View();
        }

        // POST: Mqsolicitudcab06/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id06,IdAlumno01,FechaSolicitud06,IdRegistrante04,Carrera05,Periodo06")] Mqsolicitudcab06 mqsolicitudcab06)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(mqsolicitudcab06);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["Carrera05"] = new SelectList(_context.Mdcarreras05s, "Id05", "Id05", mqsolicitudcab06.Carrera05);
            ViewData["IdAlumno01"] = new SelectList(_context.Mdalumno01s, "Id01", "Id01", mqsolicitudcab06.IdAlumno01);
            ViewData["IdRegistrante04"] = new SelectList(_context.Mdtrabajador04s, "Id04", "Id04", mqsolicitudcab06.IdRegistrante04);
            return View(mqsolicitudcab06);
        }

        // GET: Mqsolicitudcab06/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mqsolicitudcab06s == null)
            {
                return NotFound();
            }

            var mqsolicitudcab06 = await _context.Mqsolicitudcab06s.FindAsync(id);
            if (mqsolicitudcab06 == null)
            {
                return NotFound();
            }
            ViewData["Carrera05"] = new SelectList(_context.Mdcarreras05s, "Id05", "Id05", mqsolicitudcab06.Carrera05);
            ViewData["IdAlumno01"] = new SelectList(_context.Mdalumno01s, "Id01", "Id01", mqsolicitudcab06.IdAlumno01);
            ViewData["IdRegistrante04"] = new SelectList(_context.Mdtrabajador04s, "Id04", "Id04", mqsolicitudcab06.IdRegistrante04);
            return View(mqsolicitudcab06);
        }

        // POST: Mqsolicitudcab06/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id06,IdAlumno01,FechaSolicitud06,IdRegistrante04,Carrera05,Periodo06")] Mqsolicitudcab06 mqsolicitudcab06)
        {
            if (id != mqsolicitudcab06.Id06)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(mqsolicitudcab06);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mqsolicitudcab06Exists(mqsolicitudcab06.Id06))
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
            ViewData["Carrera05"] = new SelectList(_context.Mdcarreras05s, "Id05", "Id05", mqsolicitudcab06.Carrera05);
            ViewData["IdAlumno01"] = new SelectList(_context.Mdalumno01s, "Id01", "Id01", mqsolicitudcab06.IdAlumno01);
            ViewData["IdRegistrante04"] = new SelectList(_context.Mdtrabajador04s, "Id04", "Id04", mqsolicitudcab06.IdRegistrante04);
            return View(mqsolicitudcab06);
        }

        // GET: Mqsolicitudcab06/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mqsolicitudcab06s == null)
            {
                return NotFound();
            }

            var mqsolicitudcab06 = await _context.Mqsolicitudcab06s
                .Include(m => m.Carrera05Navigation)
                .Include(m => m.IdAlumno01Navigation)
                .Include(m => m.IdRegistrante04Navigation)
                .FirstOrDefaultAsync(m => m.Id06 == id);
            if (mqsolicitudcab06 == null)
            {
                return NotFound();
            }

            return View(mqsolicitudcab06);
        }

        // POST: Mqsolicitudcab06/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mqsolicitudcab06s == null)
            {
                return Problem("Entity set 'PruebaUniversidadContext.Mqsolicitudcab06s'  is null.");
            }
            var mqsolicitudcab06 = await _context.Mqsolicitudcab06s.FindAsync(id);
            if (mqsolicitudcab06 != null)
            {
                _context.Mqsolicitudcab06s.Remove(mqsolicitudcab06);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mqsolicitudcab06Exists(int id)
        {
          return _context.Mqsolicitudcab06s.Any(e => e.Id06 == id);
        }
    }
}
