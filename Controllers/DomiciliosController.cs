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
    public class DomiciliosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DomiciliosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Domicilios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Domicilio.Include(d => d.Municipio).Include(d => d.Persona).Include(d => d.Tipo_Ambito).Include(d => d.Tipo_Asentamiento).Include(d => d.Tipo_Vialidad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Domicilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio
                .Include(d => d.Municipio)
                .Include(d => d.Persona)
                .Include(d => d.Tipo_Ambito)
                .Include(d => d.Tipo_Asentamiento)
                .Include(d => d.Tipo_Vialidad)
                .FirstOrDefaultAsync(m => m.DomicilioID == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // GET: Domicilios/Create
        public IActionResult Create()
        {
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "MunicipioID");
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "PersonaID");
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Tipo_AmbitoID");
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Tipo_AsentamientoID");
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Tipo_VialidadID");
            return View();
        }

        // POST: Domicilios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DomicilioID,Tipo_AmbitoID,estado,nombreasentamiento,Tipo_VialidadID,noexterior,MunicipioID,referenciavialidad,nombrevialidad,nointerior,localidad,referenciaposterior,codigopostal,Tipo_AsentamientoID,referenciaubicacion,PersonaID")] Domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domicilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "MunicipioID", domicilio.MunicipioID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "PersonaID", domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Tipo_AmbitoID", domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Tipo_AsentamientoID", domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Tipo_VialidadID", domicilio.Tipo_VialidadID);
            return View(domicilio);
        }

        // GET: Domicilios/Edit/5
        public async Task<IActionResult> Edit(int? id, GranModelo granModelo)
        {
            if (id == null)
            {
                return NotFound();
            }

            granModelo.Domicilio = await _context.Domicilio.FindAsync(id);
            if (granModelo.Domicilio == null)
            {
                return NotFound();
            }
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "MunicipioID", granModelo.Domicilio.MunicipioID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CURP", granModelo.Domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Tipo_AmbitoID", granModelo.Domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Tipo_AsentamientoID", granModelo.Domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Tipo_VialidadID", granModelo.Domicilio.Tipo_VialidadID);
            return View(granModelo);
        }

        // POST: Domicilios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GranModelo granModelo, int id)
        {
            id = granModelo.Domicilio.DomicilioID;

            if (id != granModelo.Domicilio.DomicilioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(granModelo.Domicilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomicilioExists(granModelo.Domicilio.DomicilioID))
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
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "MunicipioID", granModelo.Domicilio.MunicipioID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CURP", granModelo.Domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Tipo_AmbitoID", granModelo.Domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Tipo_AsentamientoID", granModelo.Domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Tipo_VialidadID", granModelo.Domicilio.Tipo_VialidadID);
            return View(granModelo);
        }

        // GET: Domicilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio
                .Include(d => d.Municipio)
                .Include(d => d.Persona)
                .Include(d => d.Tipo_Ambito)
                .Include(d => d.Tipo_Asentamiento)
                .Include(d => d.Tipo_Vialidad)
                .FirstOrDefaultAsync(m => m.DomicilioID == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // POST: Domicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domicilio = await _context.Domicilio.FindAsync(id);
            _context.Domicilio.Remove(domicilio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomicilioExists(int id)
        {
            return _context.Domicilio.Any(e => e.DomicilioID == id);
        }

        [HttpPost]
        public JsonResult GetDomicilio(int id)
        {
            System.Diagnostics.Debug.WriteLine("ENTROOOOOOOOOOOOOO");
            id = id + 1;
            return Json("'mensaje' :  'Realizado'");
        }
    }
}
