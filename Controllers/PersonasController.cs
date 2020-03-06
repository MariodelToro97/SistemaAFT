using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "MunicipioID");
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "PersonaID");
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Tipo_AmbitoID");
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Tipo_AsentamientoID");
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Tipo_VialidadID");
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
        public async Task<IActionResult> Edit(int? id, GranModelo granModelo)
        {
            if (id == null)
            {
                return NotFound();
            }

            granModelo.Persona = await _context.Persona.FindAsync(id);
            if (granModelo.Persona == null)
            {
                return NotFound();
            }
            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID", granModelo.Persona.DiscapacidadID);
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Estado_CivilID", granModelo.Persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", granModelo.Persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "GeneroID", granModelo.Persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Tipo_IdentidadID", granModelo.Persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Tipo_PersonaID", granModelo.Persona.Tipo_PersonaID);
            

            return View(granModelo);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GranModelo granModelo)
        {

            if (id != granModelo.Persona.PersonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(granModelo.Persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(granModelo.Persona.PersonaID))
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
            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID", granModelo.Persona.DiscapacidadID);
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Estado_CivilID", granModelo.Persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", granModelo.Persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "GeneroID", granModelo.Persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Tipo_IdentidadID", granModelo.Persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Tipo_PersonaID", granModelo.Persona.Tipo_PersonaID);
            /*
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "MunicipioID", domicilio.MunicipioID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CURP", domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Tipo_AmbitoID", domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Tipo_AsentamientoID", domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Tipo_VialidadID", domicilio.Tipo_VialidadID);
            */
            return View(granModelo);
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
