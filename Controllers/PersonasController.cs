using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
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
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Nombre_Edo_Civil");
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID");
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "Nombre_Genero");
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Nombre");
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Nombre_Tipo");
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "Nombre");
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "PersonaID");
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Nombre");
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre");
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre");
            ViewData["NacionalidadID"] = new SelectList(_context.Set<Nacionalidad>(), "NacionalidadID", "Nombre");
            ViewData["CompaniaID"] = new SelectList(_context.Set<Compania>(), "CompaniaID", "nombre_compania");
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Set<Tipo_Telefono>(), "Tipo_TelefonoID", "nombre_tipo");
            return View();
        }
         

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       /* [Bind("PersonaID,CURP,RFC,nombre,apellido_paterno,apellido_materno,correo,fechaNacimiento,NacionalidadID,GeneroID,Estado_CivilID,Tipo_IdentidadID,num_identificacion,telefono,Tipo_PersonaID,EtniaID,DiscapacidadID,Created,ACUSESURI,nombreMoral")]*/
        public async Task<IActionResult> Create( GranModelo granModelo)
        {
            
                System.Diagnostics.Debug.WriteLine("entrooo");
            if(granModelo.Persona != null)
            {
                _context.Add(granModelo.Persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));                
            }
                           

            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID", granModelo.Persona.DiscapacidadID);
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Nombre_Edo_Civil", granModelo.Persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", granModelo.Persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "Nombre_Genero", granModelo.Persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Nombre", granModelo.Persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Nombre_Tipo", granModelo.Persona.Tipo_PersonaID);
            ViewData["NacionalidadID"] = new SelectList(_context.Nacionalidad, "NacionalidadID", "Nombre", granModelo.Persona.Nacionalidad);
            return View(granModelo);
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

            var libros = _context.Domicilio.FromSqlRaw("Select * From dbo.Domicilio WHERE PersonaID = {0}", id).ToList();
            var integrantes = _context.Integrante.FromSqlRaw("Select * From dbo.Integrante WHERE PersonaID = {0}", id).ToList();
            var telefonos = _context.Telefono.FromSqlRaw("Select * From dbo.Telefono WHERE PersonaID = {0}", id).ToList();
            var representantes = _context.Representante.FromSqlRaw("Select * From dbo.Representante WHERE PersonaID = {0}", id).ToList();

            ViewBag.Libros = libros;
            ViewBag.Integrantes = integrantes;
            ViewBag.Representante = representantes;
            ViewBag.Telefonos = telefonos;

            if (libros.FirstOrDefault() == null)
            {
                return RedirectToAction("Index", "Error");
            }

            if (telefonos.FirstOrDefault() == null)
            {
                return RedirectToAction("IndexTel", "Error");
            }

            if (libros.Count() > 0)
            {
                granModelo.Domicilio = await _context.Domicilio.FindAsync(libros.First().DomicilioID);
            }

            if (integrantes.Count() > 0)
            {
                granModelo.Integrante = await _context.Integrante.FindAsync(integrantes.First().IntegranteID);
            }

            if (representantes.Count() > 0)
            {
                granModelo.Representante = await _context.Representante.FindAsync(representantes.First().RepresentanteID);
            }
            
            if (telefonos.Count() > 0)
            {
                granModelo.Telefono = await _context.Telefono.FindAsync(telefonos.First().TelefonoID);
            }

            ViewData["DiscapacidadID"] = new SelectList(_context.Discapacidad, "DiscapacidadID", "DiscapacidadID", granModelo.Persona.DiscapacidadID);
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Nombre_Edo_Civil", granModelo.Persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", granModelo.Persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "Nombre_Genero", granModelo.Persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Nombre", granModelo.Persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Nombre_Tipo", granModelo.Persona.Tipo_PersonaID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CURP", granModelo.Persona.PersonaID);

            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Nombre", granModelo.Domicilio.Tipo_AmbitoID);
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "Nombre", granModelo.Domicilio.MunicipioID);            
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre", granModelo.Domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre", granModelo.Domicilio.Tipo_VialidadID);
            ViewData["NacionalidadID"] = new SelectList(_context.Set<Nacionalidad>(), "NacionalidadID", "Nombre");
            ViewData["CompaniaID"] = new SelectList(_context.Set<Compania>(), "CompaniaID", "nombre_compania", granModelo.Telefono.CompaniaID);
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Set<Tipo_Telefono>(), "Tipo_TelefonoID", "nombre_tipo", granModelo.Telefono.Tipo_TelefonoID);

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
            ViewData["Estado_CivilID"] = new SelectList(_context.Estado_Civil, "Estado_CivilID", "Nombre_Edo_Civil", granModelo.Persona.Estado_CivilID);
            ViewData["EtniaID"] = new SelectList(_context.Etnia, "EtniaID", "EtniaID", granModelo.Persona.EtniaID);
            ViewData["GeneroID"] = new SelectList(_context.Genero, "GeneroID", "Nombre_Genero", granModelo.Persona.GeneroID);
            ViewData["Tipo_IdentidadID"] = new SelectList(_context.Tipo_Identidad, "Tipo_IdentidadID", "Nombre", granModelo.Persona.Tipo_IdentidadID);
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Nombre_Tipo", granModelo.Persona.Tipo_PersonaID);
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "Nombre", granModelo.Domicilio.MunicipioID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CURP", granModelo.Domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Nombre", granModelo.Domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre", granModelo.Domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre", granModelo.Domicilio.Tipo_VialidadID);
            ViewData["NacionalidadID"] = new SelectList(_context.Set<Nacionalidad>(), "NacionalidadID", "Nombre");
            ViewData["CompaniaID"] = new SelectList(_context.Set<Compania>(), "CompaniaID", "nombre_compania", granModelo.Telefono.CompaniaID);
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Set<Tipo_Telefono>(), "Tipo_TelefonoID", "nombre_tipo", granModelo.Telefono.Tipo_TelefonoID);

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

        public IActionResult Solicitante()
        {
            return View();
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.PersonaID == id);
        }
        private bool DomicilioExists(int id_dom)
        {
            return _context.Domicilio.Any(e => e.DomicilioID == id_dom);
        }

        //Llamada a procedimiento para insertar persona spAddPersona
        public string addPersona (string curp, string rfc, string nombrePersona, string aPaterno, string aMAterno, string correo, string nacimiento, int nacionalidad, int genero, int civil, int identidad, string numIdent, int tipoPersona, int etnia, int discapacidad, string suri, string nombreMoral)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddPersona", cn);
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.AddWithValue("@CURP", curp);
                com.Parameters.AddWithValue("@rfc", rfc);
                com.Parameters.AddWithValue("@nombre", nombrePersona);
                com.Parameters.AddWithValue("@aPaterno", aPaterno);
                com.Parameters.AddWithValue("@aMaterno", aMAterno);
                com.Parameters.AddWithValue("@correo", correo);
                com.Parameters.AddWithValue("@nacimiento", nacimiento);
                com.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                com.Parameters.AddWithValue("@genero", genero);
                com.Parameters.AddWithValue("@civil", civil);
                com.Parameters.AddWithValue("@identidad", identidad);
                com.Parameters.AddWithValue("@identificacion", numIdent);                
                com.Parameters.AddWithValue("@persona", tipoPersona);
                com.Parameters.AddWithValue("@etnia", etnia);
                com.Parameters.AddWithValue("@discapacidad", discapacidad);
                com.Parameters.AddWithValue("@suri", suri);
                com.Parameters.AddWithValue("@moral", nombreMoral);

                SqlParameter ID = new SqlParameter("@ID", 0);
                ID.Direction = ParameterDirection.Output;
                com.Parameters.Add(ID);

                cn.Open();
                com.ExecuteNonQuery();
                //int valor = Int32.Parse (com.Parameters["@id"].Value.ToString());
                //string valor = com.ExecuteScalar().ToString();
                string valor = com.Parameters["@ID"].Value.ToString();
                cn.Close();

                return valor;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

    }
}
