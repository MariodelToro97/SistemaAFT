using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaAFT.Data;

namespace SistemaAFT.Controllers
{
    public class PeticionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext _context;

        public PeticionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Llamada a procedimiento de insertar Integrante en la base de datos spAddIntegrante
        [HttpPost]
        public string addIntegrante(string curp, string nombre, string aPaterno, string aMaterno, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddIntegrante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@curp", curp);
                com.Parameters.AddWithValue("@nombre", nombre);
                com.Parameters.AddWithValue("@aPaterno", aPaterno);
                com.Parameters.AddWithValue("@aMaterno", aMaterno);
                com.Parameters.AddWithValue("@persona", persona);

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

        //Llamada a procedimiento de borrar Integrante en la base de datos spADeletentegrante
        [HttpPost]
        public string deleteIntegrante(int id)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteIntegrante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@intID", id);

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

        //Método para obtener los datos de un integrante
        [HttpGet]
        public JsonResult getIntegrante(int id)
        {
            var classes = _context.Integrante.FromSqlRaw("Select * From dbo.Integrante WHERE IntegranteID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento de actualizar Integrante en la base de datos spUpdateIntegrante
        [HttpPost]
        public string updateIntegrante(int id, string curp, string nombre, string aPaterno, string aMaterno, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateIntegrante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@curp", curp);
                com.Parameters.AddWithValue("@nombre", nombre);
                com.Parameters.AddWithValue("@aPaterno", aPaterno);
                com.Parameters.AddWithValue("@aMaterno", aMaterno);
                com.Parameters.AddWithValue("@persona", persona);

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

        //Método para obtener los datos de los representantes
        [HttpGet]
        public JsonResult getRepresentantes(int id)
        {
            var classes = _context.Representante.FromSqlRaw("Select * From dbo.Representante WHERE RepresentanteID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento de borrar representante en la base de datos spADeleteRepresentante
        [HttpPost]
        public string deleteRepresentante(int id)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteRepresentante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@intID", id);

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
        
        //Llamada a procedimiento de insertar Representante en la base de datos spAddRepresentante
        [HttpPost]
        public string addRepresentante(string curp, string nombre, string aPaterno, string aMaterno, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddRepresentante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@curp", curp);
                com.Parameters.AddWithValue("@nombre", nombre);
                com.Parameters.AddWithValue("@aPaterno", aPaterno);
                com.Parameters.AddWithValue("@aMaterno", aMaterno);
                com.Parameters.AddWithValue("@persona", persona);

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

        //Llamada a procedimiento de actualizar Representante en la base de datos spUpdateIntegrante
        [HttpPost]
        public string updateRepresentante(int id, string curp, string nombre, string aPaterno, string aMaterno, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateRepresentante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@curp", curp);
                com.Parameters.AddWithValue("@nombre", nombre);
                com.Parameters.AddWithValue("@aPaterno", aPaterno);
                com.Parameters.AddWithValue("@aMaterno", aMaterno);
                com.Parameters.AddWithValue("@persona", persona);

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