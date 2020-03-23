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

            return View();
        }

        //Llamada a procedimiento para insertar persona spAddPersona
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
    }
}
