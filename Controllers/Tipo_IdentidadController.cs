using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAFT.Data;
using SistemaAFT.Models;

namespace SistemaAFT.Controllers
{
    public class Tipo_IdentidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tipo_IdentidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipo_Identidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_Identidad.ToListAsync());
        }

        // GET: Tipo_Identidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Identidad = await _context.Tipo_Identidad
                .FirstOrDefaultAsync(m => m.Tipo_IdentidadID == id);
            if (tipo_Identidad == null)
            {
                return NotFound();
            }

            return View(tipo_Identidad);
        }

        // GET: Tipo_Identidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Identidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo_IdentidadID,Nombre")] Tipo_Identidad tipo_Identidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Identidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_Identidad);
        }

        // GET: Tipo_Identidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Identidad = await _context.Tipo_Identidad.FindAsync(id);
            if (tipo_Identidad == null)
            {
                return NotFound();
            }
            return View(tipo_Identidad);
        }

        // POST: Tipo_Identidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo_IdentidadID,Nombre")] Tipo_Identidad tipo_Identidad)
        {
            if (id != tipo_Identidad.Tipo_IdentidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Identidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_IdentidadExists(tipo_Identidad.Tipo_IdentidadID))
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
            return View(tipo_Identidad);
        }

        // GET: Tipo_Identidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Identidad = await _context.Tipo_Identidad
                .FirstOrDefaultAsync(m => m.Tipo_IdentidadID == id);
            if (tipo_Identidad == null)
            {
                return NotFound();
            }

            return View(tipo_Identidad);
        }

        // POST: Tipo_Identidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo_Identidad = await _context.Tipo_Identidad.FindAsync(id);
            _context.Tipo_Identidad.Remove(tipo_Identidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_IdentidadExists(int id)
        {
            return _context.Tipo_Identidad.Any(e => e.Tipo_IdentidadID == id);
        }
    }
}
