using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicion.Datos;
using Medicion.Models;

namespace Medicion.Controllers
{
    public class DatosPuntosController : Controller
    {
        private readonly MedicionDbContext _context;

        public DatosPuntosController(MedicionDbContext context)
        {
            _context = context;
        }

        // GET: DatosPuntos
        public async Task<IActionResult> Index()
        {
            var medicionDbContext = _context.DatosPuntos.Include(d => d.PuntoEstudio);
            return View(await medicionDbContext.ToListAsync());
        }

        // GET: DatosPuntos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPunto = await _context.DatosPuntos
                .Include(d => d.PuntoEstudio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosPunto == null)
            {
                return NotFound();
            }

            return View(datosPunto);
        }

        // GET: DatosPuntos/Create
        public IActionResult Create()
        {
            ViewData["PuntoEstudioId"] = new SelectList(_context.PuntoEstudios, "Id", "Id");
            return View();
        }

        // POST: DatosPuntos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Valor,PuntoEstudioId")] DatosPunto datosPunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosPunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PuntoEstudioId"] = new SelectList(_context.PuntoEstudios, "Id", "Id", datosPunto.PuntoEstudioId);
            return View(datosPunto);
        }

        // GET: DatosPuntos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPunto = await _context.DatosPuntos.FindAsync(id);
            if (datosPunto == null)
            {
                return NotFound();
            }
            ViewData["PuntoEstudioId"] = new SelectList(_context.PuntoEstudios, "Id", "Id", datosPunto.PuntoEstudioId);
            return View(datosPunto);
        }

        // POST: DatosPuntos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Valor,PuntoEstudioId")] DatosPunto datosPunto)
        {
            if (id != datosPunto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosPunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosPuntoExists(datosPunto.Id))
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
            ViewData["PuntoEstudioId"] = new SelectList(_context.PuntoEstudios, "Id", "Id", datosPunto.PuntoEstudioId);
            return View(datosPunto);
        }

        // GET: DatosPuntos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPunto = await _context.DatosPuntos
                .Include(d => d.PuntoEstudio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosPunto == null)
            {
                return NotFound();
            }

            return View(datosPunto);
        }

        // POST: DatosPuntos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosPunto = await _context.DatosPuntos.FindAsync(id);
            _context.DatosPuntos.Remove(datosPunto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosPuntoExists(int id)
        {
            return _context.DatosPuntos.Any(e => e.Id == id);
        }
    }
}
