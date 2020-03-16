using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SistemaAFT.Controllers
{
    public class PeticionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
    }
}