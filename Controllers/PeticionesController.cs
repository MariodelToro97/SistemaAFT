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

        //Llamada a procedimiento de borrar Integrante en la base de datos spADeletentegrante
        [HttpPost]
        public string deleteIntegrante(int id, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteIntegrante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@intID", id);
                com.Parameters.AddWithValue("@persona", persona);

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
        
        //Llamada a procedimiento de insertar Telefonos en la base de datos spAddTelefono
        [HttpPost]
        public string addTelefono(string numero, int CompaniaID, int Tipo_TelefonoID, int persona, Boolean notificacion)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddTelefono", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@numero", numero);
                com.Parameters.AddWithValue("@CompaniaID", CompaniaID);
                com.Parameters.AddWithValue("@Tipo_TelefonoID", Tipo_TelefonoID);
                com.Parameters.AddWithValue("@persona", persona);
                com.Parameters.AddWithValue("@notificacion", notificacion);

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


        //Método para obtener los datos de un integrante
        [HttpGet]
        public JsonResult getTelefono(int id)
        {
            var classes = _context.Telefono.FromSqlRaw("Select * From dbo.Telefono WHERE TelefonoID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento de actualizar Telefonos en la base de datos spUpdateIntegrante
        [HttpPost]
        public string updateTelefono(int id, string numero, int CompaniaID, int Tipo_TelefonoID, int persona, Boolean notificacion)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateTelefono", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@numero", numero);
                com.Parameters.AddWithValue("@CompaniaID", CompaniaID);
                com.Parameters.AddWithValue("@Tipo_TelefonoID", Tipo_TelefonoID);
                com.Parameters.AddWithValue("@persona", persona);
                com.Parameters.AddWithValue("@notificacion", notificacion);

                SqlParameter ID = new SqlParameter("@tel", 0);
                ID.Direction = ParameterDirection.Output;
                com.Parameters.Add(ID);

                cn.Open();
                com.ExecuteNonQuery();
                string valor = com.Parameters["@tel"].Value.ToString();
                cn.Close();

                return valor;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Llamada a procedimiento de borrar Telefono en la base de datos spADeletentegrante
        [HttpPost]
        public string deleteTelefono(int id, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteTelefono", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@intID", id);
                com.Parameters.AddWithValue("@persona", persona);

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

        //Método para obtener los datos de los representantes
        [HttpGet]
        public JsonResult getRepresentantes(int id)
        {
            var classes = _context.Representante.FromSqlRaw("Select * From dbo.Representante WHERE RepresentanteID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento de borrar representante en la base de datos spADeleteRepresentante
        [HttpPost]
        public string deleteRepresentante(int id, int persona)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteRepresentante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@intID", id);
                com.Parameters.AddWithValue("@persona", persona);

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

        //Llamada a procedimiento para insertar documentos del representante spAddDocumentosRepresentante
        [HttpPost]
        public string addDocumentoRepresentante(string tipo, string folio, string fecha, int repre)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spAddDocumentoRepresentante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@tipoDoc", tipo);
                com.Parameters.AddWithValue("@folio", folio);
                com.Parameters.AddWithValue("@fecha", fecha);
                com.Parameters.AddWithValue("@repre", repre);

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

        //Llamada a procedimiento de borrar documento de representante en la base de datos spADeleteDocumentoRepresentante
        [HttpPost]
        public string deleteDocumentoRepresentante(int id, int repre)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spDeleteDocumentoRepresentante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@repre", repre);

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

        //Método para obtener los datos de los documentos de los representantes
        [HttpGet]
        public JsonResult getDocumentosRepresentantes(int id)
        {
            var classes = _context.documentoRepresentante.FromSqlRaw("Select * From dbo.documentoRepresentante WHERE documentoRepresentanteID = {0}", id);
            return Json(classes);
        }

        //Método para obtener los datos de los documentos de los representantes al presionar el botón de edit de la tabla exterior
        [HttpGet]
        public JsonResult getDocumentosRepresentante(int id)
        {
            var classes = _context.documentoRepresentante.FromSqlRaw("Select * From dbo.documentoRepresentante WHERE RepresentanteID = {0}", id);
            return Json(classes);
        }

        //Llamada a procedimiento de actualizar documentos de Representante en la base de datos spUpdatedocumentoRepresentante
        public string updateDocumentoRepresentante(int id, int tipo, string folio, string fecha)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=dbsistemaaft;Trusted_Connection=True;MultipleActiveResultSets=true");

                SqlCommand com = new SqlCommand("spUpdateDocumentoRepresentante", cn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@tipoDoc", tipo);
                com.Parameters.AddWithValue("@folio", folio);
                com.Parameters.AddWithValue("@fecha", fecha);

                SqlParameter ID = new SqlParameter("@docu", 0);
                ID.Direction = ParameterDirection.Output;
                com.Parameters.Add(ID);

                cn.Open();
                com.ExecuteNonQuery();
                string valor = com.Parameters["@docu"].Value.ToString();
                cn.Close();

                return valor;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //Método para obtener los telefonos de una persona
        [HttpGet]
        public JsonResult GetTelefonos(int id)
        {
            var classes = _context.Telefono.FromSqlRaw("Select * From dbo.Telefono WHERE PersonaID = {0}", id);
            return Json(classes);
        }

        //Método para obtener los domicilios de una persona
        [HttpGet]
        public JsonResult getDomicilios(int id)
        {
            var classes = _context.Domicilio.FromSqlRaw("Select * From dbo.Domicilio WHERE PersonaID = {0}", id);
            return Json(classes);
        }

        //Método para obtener los representantes de una persona
        [HttpGet]
        public JsonResult getRepre(int id)
        {
            var classes = _context.Representante.FromSqlRaw("Select * From dbo.Representante WHERE PersonaID = {0}", id);
            return Json(classes);
        }
    }
}