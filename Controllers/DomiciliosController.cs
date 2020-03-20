using System;
using System.Collections.Generic;
using System.Data;
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
            //Include(d => d.Municipio)
            var applicationDbContext = _context.Domicilio.Include(d => d.Persona).Include(d => d.Tipo_Ambito).Include(d => d.Tipo_Asentamiento).Include(d => d.Tipo_Vialidad);
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
                //.Include(d => d.Municipio)
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
            ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "Nombre");
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "PersonaID");
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Nombre");
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre");
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre");
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
            //ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "Nombre", domicilio.Municipio);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CRUP", domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Nombre", domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre", domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre", domicilio.Tipo_VialidadID);
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
            //ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "Nombre", granModelo.Domicilio.Municipio);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CURP", granModelo.Domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Nombre", granModelo.Domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre", granModelo.Domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre", granModelo.Domicilio.Tipo_VialidadID);
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
            //ViewData["MunicipioID"] = new SelectList(_context.Municipio, "MunicipioID", "Nombre", granModelo.Domicilio.MunicipioID);
            ViewData["PersonaID"] = new SelectList(_context.Persona, "PersonaID", "CURP", granModelo.Domicilio.PersonaID);
            ViewData["Tipo_AmbitoID"] = new SelectList(_context.Set<Tipo_Ambito>(), "Tipo_AmbitoID", "Nombre", granModelo.Domicilio.Tipo_AmbitoID);
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre", granModelo.Domicilio.Tipo_AsentamientoID);
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre", granModelo.Domicilio.Tipo_VialidadID);
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
                //.Include(d => d.Municipio)
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

        //Selección de los domicilios pertenecientes a un determinado usuario
        [HttpGet]
        public JsonResult GetDomicilio(int id)
        {
            var classes = _context.Domicilio.FromSqlRaw("Select * From dbo.Domicilio WHERE DomicilioID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento de actualizar en la base de datos spUpdateDomicilio
        public string updateDomicilio(int DomicilioID, int Tipo_AmbitoID, string estado, string nombreasentamiento, int Tipo_Vialidad, string noexterior, string Municipio, string referenciavialidad, string nombrevialidad, string nointerior, string localidad, string referenciaposterior, string codigopostal, int Tipo_Asentamiento, string referenciaubicacion, int PersonaID)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateDomicilio", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@domID", DomicilioID);
                com.Parameters.AddWithValue("@tipoAmbito", Tipo_AmbitoID);
                com.Parameters.AddWithValue("@estado", estado);
                com.Parameters.AddWithValue("@asentamiento", nombreasentamiento);
                com.Parameters.AddWithValue("@vialidad", Tipo_Vialidad);
                com.Parameters.AddWithValue("@noExterior", noexterior);
                com.Parameters.AddWithValue("@munID", Municipio);
                com.Parameters.AddWithValue("@refVialidad", referenciavialidad);
                com.Parameters.AddWithValue("@nomViali", nombrevialidad);
                com.Parameters.AddWithValue("@noInterior", nointerior);
                com.Parameters.AddWithValue("@localidad", localidad);
                com.Parameters.AddWithValue("@referenciaPos", referenciaposterior);
                com.Parameters.AddWithValue("@cp", codigopostal);
                com.Parameters.AddWithValue("@tipoAsentamiento", Tipo_Asentamiento);
                com.Parameters.AddWithValue("@referencia", referenciaubicacion);
                com.Parameters.AddWithValue("@personaID", PersonaID);

                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();

                return "SUCCESS";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Llamada a procedimiento de actualizar en la base de datos spAddDomicilio
        public string addDomicilio(int Tipo_AmbitoID, string estado, string nombreasentamiento, int Tipo_Vialidad, string noexterior, string Municipio, string referenciavialidad, string nombrevialidad, string nointerior, string localidad, string referenciaposterior, string codigopostal, int Tipo_Asentamiento, string referenciaubicacion, int PersonaID)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddDomicilio", cn);
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.AddWithValue("@tipoAmbito", Tipo_AmbitoID);
                com.Parameters.AddWithValue("@estado", estado);
                com.Parameters.AddWithValue("@asentamiento", nombreasentamiento);
                com.Parameters.AddWithValue("@vialidad", Tipo_Vialidad);
                com.Parameters.AddWithValue("@noExterior", noexterior);
                com.Parameters.AddWithValue("@munID", Municipio);
                com.Parameters.AddWithValue("@refVialidad", referenciavialidad);
                com.Parameters.AddWithValue("@nomViali", nombrevialidad);
                com.Parameters.AddWithValue("@noInterior", nointerior);
                com.Parameters.AddWithValue("@localidad", localidad);
                com.Parameters.AddWithValue("@referenciaPos", referenciaposterior);
                com.Parameters.AddWithValue("@cp", codigopostal);
                com.Parameters.AddWithValue("@tipoAsentamiento", Tipo_Asentamiento);
                com.Parameters.AddWithValue("@referencia", referenciaubicacion);
                com.Parameters.AddWithValue("@personaID", PersonaID);

                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();

                return "SUCCESS";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Llamada a procedimiento para eliminar domicilio
        public string deleteDomicilio (int domID)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteAddress", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@domID", domID);                

                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();

                return "SUCCESS";

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}