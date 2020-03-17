using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAFT.Data;

namespace SistemaAFT.Models
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Solicituds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Solicitud.Include(s => s.Componente).Include(s => s.Delegacion).Include(s => s.Instancia_Ejecutora).Include(s => s.Programa).Include(s => s.Year);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Solicituds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.Componente)
                .Include(s => s.Delegacion)
                .Include(s => s.Instancia_Ejecutora)
                .Include(s => s.Programa)
                .Include(s => s.Year)
                .FirstOrDefaultAsync(m => m.SolicitudID == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solicituds/Create
        public IActionResult Create()
        {
            ViewData["ComponenteID"] = new SelectList(_context.Componente, "ComponenteID", "ComponenteID");
            ViewData["DelegacionID"] = new SelectList(_context.Delegacion, "DelegacionID", "DelegacionID");
            ViewData["Instancia_EjecutoraID"] = new SelectList(_context.Instancia_Ejecutora, "Instancia_EjecutoraID", "Instancia_EjecutoraID");
            ViewData["ProgramaID"] = new SelectList(_context.Programa, "ProgramaID", "ProgramaID");
            ViewData["YearID"] = new SelectList(_context.Year, "YearID", "YearID");
            return View();
        }

        // POST: Solicituds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SolicitudID,YearID,ProgramaID,ComponenteID,Instancia_EjecutoraID,DelegacionID")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComponenteID"] = new SelectList(_context.Componente, "ComponenteID", "ComponenteID", solicitud.ComponenteID);
            ViewData["DelegacionID"] = new SelectList(_context.Delegacion, "DelegacionID", "DelegacionID", solicitud.DelegacionID);
            ViewData["Instancia_EjecutoraID"] = new SelectList(_context.Instancia_Ejecutora, "Instancia_EjecutoraID", "Instancia_EjecutoraID", solicitud.Instancia_EjecutoraID);
            ViewData["ProgramaID"] = new SelectList(_context.Programa, "ProgramaID", "ProgramaID", solicitud.ProgramaID);
            ViewData["YearID"] = new SelectList(_context.Year, "YearID", "YearID", solicitud.YearID);
            return View(solicitud);
        }

        // GET: Solicituds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            ViewData["ComponenteID"] = new SelectList(_context.Componente, "ComponenteID", "ComponenteID", solicitud.ComponenteID);
            ViewData["DelegacionID"] = new SelectList(_context.Delegacion, "DelegacionID", "DelegacionID", solicitud.DelegacionID);
            ViewData["Instancia_EjecutoraID"] = new SelectList(_context.Instancia_Ejecutora, "Instancia_EjecutoraID", "Instancia_EjecutoraID", solicitud.Instancia_EjecutoraID);
            ViewData["ProgramaID"] = new SelectList(_context.Programa, "ProgramaID", "ProgramaID", solicitud.ProgramaID);
            ViewData["YearID"] = new SelectList(_context.Year, "YearID", "YearID", solicitud.YearID);
            return View(solicitud);
        }

        // POST: Solicituds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SolicitudID,YearID,ProgramaID,ComponenteID,Instancia_EjecutoraID,DelegacionID")] Solicitud solicitud)
        {
            if (id != solicitud.SolicitudID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.SolicitudID))
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
            ViewData["ComponenteID"] = new SelectList(_context.Componente, "ComponenteID", "ComponenteID", solicitud.ComponenteID);
            ViewData["DelegacionID"] = new SelectList(_context.Delegacion, "DelegacionID", "DelegacionID", solicitud.DelegacionID);
            ViewData["Instancia_EjecutoraID"] = new SelectList(_context.Instancia_Ejecutora, "Instancia_EjecutoraID", "Instancia_EjecutoraID", solicitud.Instancia_EjecutoraID);
            ViewData["ProgramaID"] = new SelectList(_context.Programa, "ProgramaID", "ProgramaID", solicitud.ProgramaID);
            ViewData["YearID"] = new SelectList(_context.Year, "YearID", "YearID", solicitud.YearID);
            return View(solicitud);
        }

        // GET: Solicituds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.Componente)
                .Include(s => s.Delegacion)
                .Include(s => s.Instancia_Ejecutora)
                .Include(s => s.Programa)
                .Include(s => s.Year)
                .FirstOrDefaultAsync(m => m.SolicitudID == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solicituds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            _context.Solicitud.Remove(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.SolicitudID == id);
        }
    }
}
