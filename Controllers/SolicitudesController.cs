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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SistemaAFT.Models
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index2(GranModelo granModelo)
        {
            var libros = _context.Solicitud.FromSqlRaw("Select * From dbo.Solicitud").ToList();
            ViewBag.Libros = libros;
            
            return View(granModelo);

            
        }

        public IActionResult Index()
        {
            ViewData["YearID"] = new SelectList(_context.Year, "YearID", "year");
            ViewData["ProgramaID"] = new SelectList(_context.Programa, "ProgramaID", "nombre");
            ViewData["ComponenteID"] = new SelectList(_context.Componente, "ComponenteID", "nombre");
            ViewData["Instancia_EjecutoraID"] = new SelectList(_context.Instancia_Ejecutora, "Instancia_EjecutoraID", "nombre");
            ViewData["DelegacionID"] = new SelectList(_context.Delegacion, "DelegacionID", "nombre");
            ViewData["Tipo_ProyectoID"] = new SelectList(_context.Tipo_Proyecto, "Tipo_ProyectoID", "Nombre");
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Nombre_Tipo");
            ViewData["Etnia"] = new SelectList(_context.Etnia, "EtniaID", "Pertenece_Etnia");            
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Set<Tipo_Telefono>(), "Tipo_TelefonoID", "nombre_tipo");
            ViewData["Tipo_DocumentoID"] = new SelectList(_context.Set<Tipo_Documento>(), "Tipo_DocumentoID", "nombre");
            ViewData["Concepto_ApoyoID"] = new SelectList(_context.Set<Concepto_Apoyo>(), "Concepto_ApoyoID", "nombre");
            ViewData["Subconcepto_ApoyoID"] = new SelectList(_context.Set<Subconcepto_Apoyo>(), "Subconcepto_ApoyoID", "nombre");

            ViewBag.Nacionalidad = _context.Nacionalidad.FromSqlRaw("Select * From dbo.Nacionalidad").ToList();
            ViewBag.Civil = _context.Estado_Civil.FromSqlRaw("Select * From dbo.Estado_Civil").OrderBy(e => e.Nombre_Edo_Civil).ToList();
            ViewBag.Genero = _context.Genero.FromSqlRaw("Select * From dbo.Genero ").ToList();
            ViewBag.Tipo_Iden = _context.Tipo_Identidad.FromSqlRaw("Select * From dbo.Tipo_Identidad").OrderBy(i => i.Nombre).ToList();
            ViewBag.CompaniaID = _context.Compania.FromSqlRaw("Select * From dbo.Compania").OrderBy(i => i.nombre_compania).ToList();
            ViewBag.Tipo_VialidadID = _context.Tipo_Vialidad.FromSqlRaw("Select * From dbo.Tipo_Vialidad").OrderBy(i => i.Nombre).ToList();
            ViewBag.Tipo_AsentamientoID = _context.Tipo_Asentamiento.FromSqlRaw("Select * From dbo.Tipo_Asentamiento").OrderBy(i => i.Nombre).ToList();
            ViewBag.Tipo_AmbitoID = _context.Tipo_Ambito.FromSqlRaw("Select * From dbo.Tipo_Ambito").OrderBy(i => i.Nombre).ToList();

            return View();
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(p => p.Year)
                .Include(p => p.Programa)
                .Include(p => p.Componente)
                .Include(p => p.Instancia_Ejecutora)
                .Include(p => p.Delegacion)
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.PersonaID == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            _context.Solicitud.Remove(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id, GranModelo granModelo)
        {

            ViewData["YearID"] = new SelectList(_context.Year, "YearID", "year");
            ViewData["ProgramaID"] = new SelectList(_context.Programa, "ProgramaID", "nombre");
            ViewData["ComponenteID"] = new SelectList(_context.Componente, "ComponenteID", "nombre");
            ViewData["Instancia_EjecutoraID"] = new SelectList(_context.Instancia_Ejecutora, "Instancia_EjecutoraID", "nombre");
            ViewData["DelegacionID"] = new SelectList(_context.Delegacion, "DelegacionID", "nombre");
            ViewData["Tipo_ProyectoID"] = new SelectList(_context.Tipo_Proyecto, "Tipo_ProyectoID", "Nombre");
            ViewData["Tipo_PersonaID"] = new SelectList(_context.Tipo_Persona, "Tipo_PersonaID", "Nombre_Tipo");
            ViewData["Etnia"] = new SelectList(_context.Etnia, "EtniaID", "Pertenece_Etnia");
            ViewData["CompaniaID"] = new SelectList(_context.Set<Compania>(), "CompaniaID", "nombre_compania");
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Set<Tipo_Telefono>(), "Tipo_TelefonoID", "nombre_tipo");
            ViewData["Tipo_DocumentoID"] = new SelectList(_context.Set<Tipo_Documento>(), "Tipo_DocumentoID", "nombre");
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre");
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre");
            ViewData["Concepto_ApoyoID"] = new SelectList(_context.Set<Concepto_Apoyo>(), "Concepto_ApoyoID", "nombre");
            ViewData["Subconcepto_ApoyoID"] = new SelectList(_context.Set<Subconcepto_Apoyo>(), "Subconcepto_ApoyoID", "nombre");

            ViewBag.Proyectos = _context.Proyecto.FromSqlRaw("Select * From dbo.Proyecto WHERE SolicitudID = {0}", id).ToList();
            
            return View(granModelo);
        }




        
        //Método para buscar si existe el usuario con los datos de solicitante MORAL mediante RFC
        [HttpGet]
        public JsonResult GetCotizacion(int id)
        {
            var classes = _context.Cotizacion.FromSqlRaw("Select * From dbo.Cotizacion WHERE ProyectoID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento para insertar solicitudes
        public string addSolicitud(int year, int programa, int componente, int instancia, int delegacion, string estado, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddSolicitud", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@year", year);
                com.Parameters.AddWithValue("@programa", programa);
                com.Parameters.AddWithValue("@componente", componente);
                com.Parameters.AddWithValue("@instancia", instancia);
                com.Parameters.AddWithValue("@delegacion", delegacion);
                com.Parameters.AddWithValue("@estado", estado);
                com.Parameters.AddWithValue("@persona", persona);
                

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

        //Llamada a procedimiento para actualizar solicitudes
        public string updateSolicitud(int year, int programa, int componente, int instancia, int delegacion, string estado, int id)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateSolicitudes", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@year", year);
                com.Parameters.AddWithValue("@programa", programa);
                com.Parameters.AddWithValue("@componente", componente);
                com.Parameters.AddWithValue("@instancia", instancia);
                com.Parameters.AddWithValue("@delegacion", delegacion);
                com.Parameters.AddWithValue("@estado", estado);
                com.Parameters.AddWithValue("@id", id);

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

        //Llamada a procedimiento para insertar proyectos
        public string addProyecto(string nombreproyecto, int tipoproyecto, string objetivo, string fecha, int solicitudID)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddProyecto", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@nombreproyecto", nombreproyecto);
                com.Parameters.AddWithValue("@tipoproyecto", tipoproyecto);
                com.Parameters.AddWithValue("@objetivo", objetivo);
                com.Parameters.AddWithValue("@fecha", fecha);
                com.Parameters.AddWithValue("@solicitudID", solicitudID);


                SqlParameter ID = new SqlParameter("@ID", 0);
                ID.Direction = ParameterDirection.Output;
                com.Parameters.Add(ID);

                cn.Open();
                com.ExecuteNonQuery();
                string valor = com.Parameters["@ID"].Value.ToString();
                cn.Close();

                return valor;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Llamada a procedimiento para actualizar el proyecto
        public string updateProyecto(string nombreproyecto, int tipoproyecto, string objetivo, string fecha, int solicitudID, int id)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateProyecto", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@nombreproyecto", nombreproyecto);
                com.Parameters.AddWithValue("@tipoproyecto", tipoproyecto);
                com.Parameters.AddWithValue("@objetivo", objetivo);
                com.Parameters.AddWithValue("@fecha", fecha);
                com.Parameters.AddWithValue("@solicitudID", solicitudID);
                com.Parameters.AddWithValue("@id", id);

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
        
        //Método para buscar si existe el usuario con los datos de solicitante MORAL mediante RFC
        [HttpGet]
        public JsonResult GetUserMoral(string rfc)
        {
            var classes = _context.Persona.FromSqlRaw("Select * From dbo.Persona WHERE Tipo_PersonaID = 2 AND RFC = {0}", rfc);
            return Json(classes);
        }

        //Método para buscar si existe el usuario con los datos de solicitante MORAL mediante RFC
        [HttpGet]
        public JsonResult GetUserFisica(string curp)
        {
            var classes = _context.Persona.FromSqlRaw("Select * From dbo.Persona WHERE Tipo_PersonaID = 1 AND CURP = {0}", curp);
            return Json(classes);
        }

        //Llamada a procedimiento para insertar cotizacion
        public string addCotizacion(int conc, int subc, string uniMed, string uniImp, float canSol, float costUni, float apoPro, float apoFed, float apoEst, float montApo, float otroApo, float invTot, string desc, int proyecto)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddCotizacion", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@conc", conc);
                com.Parameters.AddWithValue("@subcon", subc);
                com.Parameters.AddWithValue("@uniMed", uniMed);
                com.Parameters.AddWithValue("@uniImp", uniImp);
                com.Parameters.AddWithValue("@canSol", canSol);
                com.Parameters.AddWithValue("@costUni", costUni);
                com.Parameters.AddWithValue("@apoPro", apoPro);
                com.Parameters.AddWithValue("@apoFed", apoFed);
                com.Parameters.AddWithValue("@apoEst", apoEst);
                com.Parameters.AddWithValue("@montApo", montApo);
                com.Parameters.AddWithValue("@otroApo", otroApo);
                com.Parameters.AddWithValue("@invTot", invTot);
                com.Parameters.AddWithValue("@desc", desc);
                com.Parameters.AddWithValue("@proyecto", proyecto);


                SqlParameter ID = new SqlParameter("@idCot", 0);
                ID.Direction = ParameterDirection.Output;
                com.Parameters.Add(ID);

                cn.Open();
                com.ExecuteNonQuery();
                string valor = com.Parameters["@idCot"].Value.ToString();
                cn.Close();

                return valor;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Llamada a procedimiento de borrar Cotización en la base de datos spDeleteCotizacion
        [HttpPost]
        public string deleteCotizacion(int id, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteCotizacion", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@intID", id);
                com.Parameters.AddWithValue("@proyecto", persona);

                SqlParameter ID = new SqlParameter("@contador", 0);
                ID.Direction = ParameterDirection.Output;
                com.Parameters.Add(ID);

                cn.Open();
                com.ExecuteNonQuery();
                string valor = com.Parameters["@contador"].Value.ToString();
                cn.Close();

                return valor;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Método para obtener los datos del Apoyo seleccionado en la tabla
        [HttpGet]
        public JsonResult GetApoyos(int id)
        {
            var classes = _context.Cotizacion.FromSqlRaw("Select * From dbo.Cotizacion WHERE CotizacionID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento para actualizar cotizacion
        public string updateCotizacion(int conc, int subc, string uniMed, string uniImp, float canSol, float costUni, float apoPro, float apoFed, float apoEst, float montApo, float otroApo, float invTot, string desc, int proyecto, int id)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateCotizacion", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@conc", conc);
                com.Parameters.AddWithValue("@subcon", subc);
                com.Parameters.AddWithValue("@uniMed", uniMed);
                com.Parameters.AddWithValue("@uniImp", uniImp);
                com.Parameters.AddWithValue("@canSol", canSol);
                com.Parameters.AddWithValue("@costUni", costUni);
                com.Parameters.AddWithValue("@apoPro", apoPro);
                com.Parameters.AddWithValue("@apoFed", apoFed);
                com.Parameters.AddWithValue("@apoEst", apoEst);
                com.Parameters.AddWithValue("@montApo", montApo);
                com.Parameters.AddWithValue("@otroApo", otroApo);
                com.Parameters.AddWithValue("@invTot", invTot);
                com.Parameters.AddWithValue("@desc", desc);
                com.Parameters.AddWithValue("@proyecto", proyecto);
                com.Parameters.AddWithValue("@id", id);

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
