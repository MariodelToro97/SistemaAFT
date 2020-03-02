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
    public class Tipo_CompaniaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tipo_CompaniaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipo_Compania
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_Compania.ToListAsync());
        }

        // GET: Tipo_Compania/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Compania = await _context.Tipo_Compania
                .FirstOrDefaultAsync(m => m.Tipo_CompaniaID == id);
            if (tipo_Compania == null)
            {
                return NotFound();
            }

            return View(tipo_Compania);
        }

        // GET: Tipo_Compania/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Compania/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo_CompaniaID,Nombre")] Tipo_Compania tipo_Compania)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Compania);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_Compania);
        }

        // GET: Tipo_Compania/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Compania = await _context.Tipo_Compania.FindAsync(id);
            if (tipo_Compania == null)
            {
                return NotFound();
            }
            return View(tipo_Compania);
        }

        // POST: Tipo_Compania/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo_CompaniaID,Nombre")] Tipo_Compania tipo_Compania)
        {
            if (id != tipo_Compania.Tipo_CompaniaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Compania);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_CompaniaExists(tipo_Compania.Tipo_CompaniaID))
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
            return View(tipo_Compania);
        }

        // GET: Tipo_Compania/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Compania = await _context.Tipo_Compania
                .FirstOrDefaultAsync(m => m.Tipo_CompaniaID == id);
            if (tipo_Compania == null)
            {
                return NotFound();
            }

            return View(tipo_Compania);
        }

        // POST: Tipo_Compania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo_Compania = await _context.Tipo_Compania.FindAsync(id);
            _context.Tipo_Compania.Remove(tipo_Compania);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_CompaniaExists(int id)
        {
            return _context.Tipo_Compania.Any(e => e.Tipo_CompaniaID == id);
        }
    }
}
