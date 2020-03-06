using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAFT.Data;
using SistemaAFT.Models;
using System.Linq;
using System.Threading.Tasks;

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
            var applicationDbContext = _context.Persona.Include(p => p.Estado_Civil).Include(p => p.Genero).Include(p => p.Tipo_Identidad).Include(p => p.Tipo_Persona).Include(p => p.Etnia);
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
                .Include(p => p.Estado_Civil)
                .Include(p => p.Genero)
                .Include(p => p.Tipo_Identidad)
                .Include(p => p.Tipo_Persona)
                .Include(p => p.Etnia)
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
            ViewData["Estado_CivilID"] = new SelectList(_context.Set<Estado_Civil>(), "Estado_CivilID", "Nombre_Edo_Civil");
            ViewData["GeneroID"] = new SelectList(_context.Set<Genero>(), "GeneroID", "Nombre_Genero");
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Set<Tipo_Identidad>(), "Tipo_IdentidadID", "Nombre");
            return View();
        }
        //cOMENTARIO

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaID,CURP,RFC,nombre,apellido_paterno,apellido_materno,correo,fechaNacimiento,nacionalidad,GeneroID,Estado_CivilID,Tipo_IdentidadID,num_identificacion,telefono,Tipo_PersonaID,EtniaID,DiscapacidadID")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Estado_CivilID"] = new SelectList(_context.Set<Estado_Civil>(), "Estado_CivilID", "Estado_CivilID", persona.Estado_CivilID);
            ViewData["GeneroID"] = new SelectList(_context.Set<Genero>(), "GeneroID", "GeneroID", persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Set<Tipo_Identidad>(), "Tipo_IdentidadID", "Tipo_IdentidadID", persona.Tipo_IdentidadID);

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
            var domicilio = await _context.Domicilio.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }
            ViewData["Estado_CivilID"] = new SelectList(_context.Set<Estado_Civil>(), "Estado_CivilID", "Nombre_Edo_Civil", persona.Estado_CivilID);
            ViewData["GeneroID"] = new SelectList(_context.Set<Genero>(), "GeneroID", "Nombre_Genero", persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Set<Tipo_Identidad>(), "Tipo_IdentidadID", "Nombre", persona.Tipo_IdentidadID);
            return View((persona, domicilio));
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("DomicilioID,Tipo_AmbitoID,estado,nombreasentamiento,Tipo_VialidadID,noexterior,MunicipioID,referenciavialidad,nombrevialidad,nointerior,localidad,referenciaposterior,codigopostal,Tipo_AsentamientoID,referenciaubicacion,PersonaID")] Domicilio domicilio
        public async Task<IActionResult> Edit(int id, [Bind("PersonaID,CURP,RFC,nombre,apellido_paterno,apellido_materno,correo,fechaNacimiento,nacionalidad,GeneroID,Estado_CivilID,Tipo_IdentidadID,num_identificacion,telefono,Tipo_PersonaID,EtniaID,DiscapacidadID")] Persona persona, Domicilio domicilio)
        {
            //   Tuple<Persona, Domicilio> Model = new Tuple<Persona, Domicilio>(new Persona(), new Domicilio());
            id = persona.PersonaID;
            if (id != persona.PersonaID)
            {
                return NotFound();
            }
            System.Diagnostics.Debug.WriteLine(persona.PersonaID);
            if (ModelState.IsValid)
            {
               
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                    _context.Update(domicilio);
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
           
            ViewData["Estado_CivilID"] = new SelectList(_context.Set<Estado_Civil>(), "Estado_CivilID", "Estado_CivilID", persona.Estado_CivilID);
            ViewData["GeneroID"] = new SelectList(_context.Set<Genero>(), "GeneroID", "GeneroID", persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Set<Tipo_Identidad>(), "Tipo_IdentidadID", "Tipo_IdentidadID", persona.Tipo_IdentidadID);
            //return View(persona);
            return View((persona, domicilio));
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.Estado_Civil)
                .Include(p => p.Genero)
                .Include(p => p.Tipo_Identidad)
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
