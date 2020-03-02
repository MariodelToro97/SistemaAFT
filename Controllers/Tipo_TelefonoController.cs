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
    public class Tipo_TelefonoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tipo_TelefonoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipo_Telefono
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_Telefono.ToListAsync());
        }

        // GET: Tipo_Telefono/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Telefono = await _context.Tipo_Telefono
                .FirstOrDefaultAsync(m => m.Tipo_TelefonoID == id);
            if (tipo_Telefono == null)
            {
                return NotFound();
            }

            return View(tipo_Telefono);
        }

        // GET: Tipo_Telefono/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Telefono/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo_TelefonoID,Nombre")] Tipo_Telefono tipo_Telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_Telefono);
        }

        // GET: Tipo_Telefono/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Telefono = await _context.Tipo_Telefono.FindAsync(id);
            if (tipo_Telefono == null)
            {
                return NotFound();
            }
            return View(tipo_Telefono);
        }

        // POST: Tipo_Telefono/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo_TelefonoID,Nombre")] Tipo_Telefono tipo_Telefono)
        {
            if (id != tipo_Telefono.Tipo_TelefonoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Telefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_TelefonoExists(tipo_Telefono.Tipo_TelefonoID))
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
            return View(tipo_Telefono);
        }

        // GET: Tipo_Telefono/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Telefono = await _context.Tipo_Telefono
                .FirstOrDefaultAsync(m => m.Tipo_TelefonoID == id);
            if (tipo_Telefono == null)
            {
                return NotFound();
            }

            return View(tipo_Telefono);
        }

        // POST: Tipo_Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo_Telefono = await _context.Tipo_Telefono.FindAsync(id);
            _context.Tipo_Telefono.Remove(tipo_Telefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_TelefonoExists(int id)
        {
            return _context.Tipo_Telefono.Any(e => e.Tipo_TelefonoID == id);
        }
    }
}
