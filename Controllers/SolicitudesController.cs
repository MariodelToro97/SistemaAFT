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

namespace SistemaAFT.Models
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesController(ApplicationDbContext context)
        {
            _context = context;
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
            ViewData["CompaniaID"] = new SelectList(_context.Set<Compania>(), "CompaniaID", "nombre_compania");
            ViewData["Tipo_TelefonoID"] = new SelectList(_context.Set<Tipo_Telefono>(), "Tipo_TelefonoID", "nombre_tipo");
            ViewData["Tipo_DocumentoID"] = new SelectList(_context.Set<Tipo_Documento>(), "Tipo_DocumentoID", "nombre");
            ViewData["Tipo_AsentamientoID"] = new SelectList(_context.Set<Tipo_Asentamiento>(), "Tipo_AsentamientoID", "Nombre");
            ViewData["Tipo_VialidadID"] = new SelectList(_context.Set<Tipo_Vialidad>(), "Tipo_VialidadID", "Nombre");

            return View();
        }

        //Llamada a procedimiento para insertar solicitudes
        public string addSolicitud(int year, int programa, int componente, int instancia, int delegacion, string estado)
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

        //Método para buscar si existe el usuario con los datos de solicitante MORAL mediante RFC
        [HttpGet]
        public JsonResult GetUserMoral(string rfc)
        {
            var classes = _context.Persona.FromSqlRaw("Select * From dbo.Persona WHERE Tipo_PersonaID = 2 AND RFC = {0}", rfc);
            return Json(classes);
        }
    }
}
