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
    public class PuntoEstudiosController : Controller
    {
        private readonly MedicionDbContext _context;

        public PuntoEstudiosController(MedicionDbContext context)
        {
            _context = context;
        }

        // GET: PuntoEstudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.PuntoEstudios.ToListAsync());
        }

        // GET: PuntoEstudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoEstudio = await _context.PuntoEstudios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puntoEstudio == null)
            {
                return NotFound();
            }

            return View(puntoEstudio);
        }

        // GET: PuntoEstudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PuntoEstudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Localidad,Latitud,Longitud,FechaCreado,FechaBaja,Pozo_Profundidad,Pozo_Diametro,Punzado_Largo,Punzado_Diametro,Temp_Pozo,DensidadRoca,Saturacion,Presion,DensidadFluido")] PuntoEstudio puntoEstudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puntoEstudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puntoEstudio);
        }

        // GET: PuntoEstudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoEstudio = await _context.PuntoEstudios.FindAsync(id);
            if (puntoEstudio == null)
            {
                return NotFound();
            }
            return View(puntoEstudio);
        }

        // POST: PuntoEstudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Localidad,Latitud,Longitud,FechaCreado,FechaBaja,Pozo_Profundidad,Pozo_Diametro,Punzado_Largo,Punzado_Diametro,Temp_Pozo,DensidadRoca,Saturacion,Presion,DensidadFluido")] PuntoEstudio puntoEstudio)
        {
            if (id != puntoEstudio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puntoEstudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuntoEstudioExists(puntoEstudio.Id))
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
            return View(puntoEstudio);
        }

        // GET: PuntoEstudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoEstudio = await _context.PuntoEstudios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puntoEstudio == null)
            {
                return NotFound();
            }

            return View(puntoEstudio);
        }

        // POST: PuntoEstudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puntoEstudio = await _context.PuntoEstudios.FindAsync(id);
            _context.PuntoEstudios.Remove(puntoEstudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuntoEstudioExists(int id)
        {
            return _context.PuntoEstudios.Any(e => e.Id == id);
        }
    }
}
