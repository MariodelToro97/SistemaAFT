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
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Persona.Include(p => p.Discapacidad).Include(p => p.Estado_Civil).Include(p => p.Etnia).Include(p => p.Genero).Include(p => p.Tipo_Identidad).Include(p => p.Tipo_Persona);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.Discapacidad)
                .Include(p => p.Estado_Civil)
                .Include(p => p.Etnia)
                .Include(p => p.Genero)
                .Include(p => p.Tipo_Identidad)
                .Include(p => p.Tipo_Persona)
                .FirstOrDefaultAsync(m => m.PersonaID == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID");
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Estado_CivilID");
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID");
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "GeneroID");
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Tipo_IdentidadID");
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Tipo_PersonaID");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaID,CURP,RFC,nombre,apellido_paterno,apellido_materno,correo,fechaNacimiento,nacionalidad,GeneroID,Estado_CivilID,Tipo_IdentidadID,num_identificacion,telefono,Tipo_PersonaID,EtniaID,DiscapacidadID,Created")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID", persona.DiscapacidadID);
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Estado_CivilID", persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "GeneroID", persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Tipo_IdentidadID", persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Tipo_PersonaID", persona.Tipo_PersonaID);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID", persona.DiscapacidadID);
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Estado_CivilID", persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "GeneroID", persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Tipo_IdentidadID", persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Tipo_PersonaID", persona.Tipo_PersonaID);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaID,CURP,RFC,nombre,apellido_paterno,apellido_materno,correo,fechaNacimiento,nacionalidad,GeneroID,Estado_CivilID,Tipo_IdentidadID,num_identificacion,telefono,Tipo_PersonaID,EtniaID,DiscapacidadID,Created")] Persona persona)
        {
            if (id != persona.PersonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.PersonaID))
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
            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID", persona.DiscapacidadID);
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Estado_CivilID", persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "GeneroID", persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Tipo_IdentidadID", persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Tipo_PersonaID", persona.Tipo_PersonaID);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.Discapacidad)
                .Include(p => p.Estado_Civil)
                .Include(p => p.Etnia)
                .Include(p => p.Genero)
                .Include(p => p.Tipo_Identidad)
                .Include(p => p.Tipo_Persona)
                .FirstOrDefaultAsync(m => m.PersonaID == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.PersonaID == id);
        }
    }
}
