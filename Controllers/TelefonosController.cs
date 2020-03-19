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
    public class TelefonosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TelefonosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Telefonos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Telefono.Include(t => t.Compania).Include(t => t.Persona).Include(t => t.Tipo_Telefono);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono
                .Include(t => t.Compania)
                .Include(t => t.Persona)
                .Include(t => t.Tipo_Telefono)
                .FirstOrDefaultAsync(m => m.TelefonoID == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefonos/Create
        public IActionResult Create()
        {
            ViewData["CompaniaID"] = new SelectList(_context.Compania, "CompaniaID", "nombre_compania");
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "PersonaID");
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Tipo_Telefono, "Tipo_TelefonoID", "nombre_tipo");
            return View();
        }

        // POST: Telefonos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelefonoID,numero,CompaniaID,Tipo_TelefonoID,PersonaID")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompaniaID"] = new SelectList(_context.Compania, "CompaniaID", "CompaniaID", telefono.CompaniaID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "ACUSESURI", telefono.PersonaID);
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Tipo_Telefono, "Tipo_TelefonoID", "Tipo_TelefonoID", telefono.Tipo_TelefonoID);
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["CompaniaID"] = new SelectList(_context.Compania, "CompaniaID", "CompaniaID", telefono.CompaniaID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "ACUSESURI", telefono.PersonaID);
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Tipo_Telefono, "Tipo_TelefonoID", "Tipo_TelefonoID", telefono.Tipo_TelefonoID);
            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelefonoID,numero,CompaniaID,Tipo_TelefonoID,PersonaID")] Telefono telefono)
        {
            if (id != telefono.TelefonoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.TelefonoID))
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
            ViewData["CompaniaID"] = new SelectList(_context.Compania, "CompaniaID", "CompaniaID", telefono.CompaniaID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "ACUSESURI", telefono.PersonaID);
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Tipo_Telefono, "Tipo_TelefonoID", "Tipo_TelefonoID", telefono.Tipo_TelefonoID);
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono
                .Include(t => t.Compania)
                .Include(t => t.Persona)
                .Include(t => t.Tipo_Telefono)
                .FirstOrDefaultAsync(m => m.TelefonoID == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefono = await _context.Telefono.FindAsync(id);
            _context.Telefono.Remove(telefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
            return _context.Telefono.Any(e => e.TelefonoID == id);
        }
    }
}
