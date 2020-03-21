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
        [Required(ErrorMessage = "Campo Requerido")]
        public string estado { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string nombreasentamiento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Tipo_VialidadID { get; set; }
        public Tipo_Vialidad Tipo_Vialidad { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string noexterior { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Municipio { get; set; }
        public string referenciavialidad { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string nombrevialidad { get; set; }
        public string nointerior { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string localidad { get; set; }
        public string referenciaposterior { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string codigopostal { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Tipo_AsentamientoID { get; set; }
        public Tipo_Asentamiento Tipo_Asentamiento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string referenciaubicacion { get; set; }

        public int PersonaID { get; set; }
        public Persona Persona { get; set; }

    }
}
