using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaAFT.Models
{
	public class Domicilio
	{
        public int DomicilioID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Tipo_AmbitoID { get; set; }
        public Tipo_Ambito Tipo_Ambito { get; set; }
        public string estado { get; set; }
        public string nombreasentamiento { get; set; }
        public int Tipo_VialidadID { get; set; }
        public Tipo_Vialidad Tipo_Vialidad { get; set; }
        public string noexterior { get; set; }
        public int MunicipioID { get; set; }
        public Municipio Municipio { get; set; }
        public string referenciavialidad { get; set; }
        public string nombrevialidad { get; set; }
        public string nointerior { get; set; }
        public string localidad { get; set; }
        public string referenciaposterior { get; set; }
        public string codigopostal { get; set; }
        public int Tipo_AsentamientoID { get; set; }
        public Tipo_Asentamiento Tipo_Asentamiento { get; set; }
        public string referenciaubicacion { get; set; }



    }
}
