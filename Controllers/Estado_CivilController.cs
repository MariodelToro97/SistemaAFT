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
    public class Estado_CivilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Estado_CivilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estado_Civil
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estado_Civil.ToListAsync());
        }

        // GET: Estado_Civil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado_Civil = await _context.Estado_Civil
                .FirstOrDefaultAsync(m => m.Estado_CivilID == id);
            if (estado_Civil == null)
            {
                return NotFound();
            }

            return View(estado_Civil);
        }

        // GET: Estado_Civil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estado_Civil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Estado_CivilID,Nombre_Edo_Civil")] Estado_Civil estado_Civil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estado_Civil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estado_Civil);
        }

        // GET: Estado_Civil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado_Civil = await _context.Estado_Civil.FindAsync(id);
            if (estado_Civil == null)
            {
                return NotFound();
            }
            return View(estado_Civil);
        }

        // POST: Estado_Civil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Estado_CivilID,Nombre_Edo_Civil")] Estado_Civil estado_Civil)
        {
            if (id != estado_Civil.Estado_CivilID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estado_Civil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Estado_CivilExists(estado_Civil.Estado_CivilID))
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
            return View(estado_Civil);
        }

        // GET: Estado_Civil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado_Civil = await _context.Estado_Civil
                .FirstOrDefaultAsync(m => m.Estado_CivilID == id);
            if (estado_Civil == null)
            {
                return NotFound();
            }

            return View(estado_Civil);
        }

        // POST: Estado_Civil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado_Civil = await _context.Estado_Civil.FindAsync(id);
            _context.Estado_Civil.Remove(estado_Civil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Estado_CivilExists(int id)
        {
            return _context.Estado_Civil.Any(e => e.Estado_CivilID == id);
        }
    }
}
