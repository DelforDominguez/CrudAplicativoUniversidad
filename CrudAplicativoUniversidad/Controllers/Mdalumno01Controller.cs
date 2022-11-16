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
    public class Mdalumno01Controller : Controller
    {
        private readonly PruebaUniversidadContext _context;

        public Mdalumno01Controller(PruebaUniversidadContext context)
        {
            _context = context;
        }

        // GET: Mdalumno01
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mdalumno01s.ToListAsync());
        }

        // GET: Mdalumno01/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mdalumno01s == null)
            {
                return NotFound();
            }

            var mdalumno01 = await _context.Mdalumno01s
                .FirstOrDefaultAsync(m => m.Id01 == id);
            if (mdalumno01 == null)
            {
                return NotFound();
            }

            return View(mdalumno01);
        }

        // GET: Mdalumno01/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mdalumno01/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id01,Nombres01,Apellidos01")] Mdalumno01 mdalumno01)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdalumno01);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdalumno01);
        }

        // GET: Mdalumno01/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mdalumno01s == null)
            {
                return NotFound();
            }

            var mdalumno01 = await _context.Mdalumno01s.FindAsync(id);
            if (mdalumno01 == null)
            {
                return NotFound();
            }
            return View(mdalumno01);
        }

        // POST: Mdalumno01/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id01,Nombres01,Apellidos01")] Mdalumno01 mdalumno01)
        {
            if (id != mdalumno01.Id01)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdalumno01);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mdalumno01Exists(mdalumno01.Id01))
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
            return View(mdalumno01);
        }

        // GET: Mdalumno01/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mdalumno01s == null)
            {
                return NotFound();
            }

            var mdalumno01 = await _context.Mdalumno01s
                .FirstOrDefaultAsync(m => m.Id01 == id);
            if (mdalumno01 == null)
            {
                return NotFound();
            }

            return View(mdalumno01);
        }

        // POST: Mdalumno01/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mdalumno01s == null)
            {
                return Problem("Entity set 'PruebaUniversidadContext.Mdalumno01s'  is null.");
            }
            var mdalumno01 = await _context.Mdalumno01s.FindAsync(id);
            if (mdalumno01 != null)
            {
                _context.Mdalumno01s.Remove(mdalumno01);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mdalumno01Exists(int id)
        {
          return _context.Mdalumno01s.Any(e => e.Id01 == id);
        }
    }
}
