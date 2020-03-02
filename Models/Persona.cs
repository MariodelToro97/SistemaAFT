using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Persona
	{
        
		public int PersonaID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string correo { get; set; }
        public string fechaNacimiento { get; set; }
        public string nacionalidad { get; set; }
        public int GeneroID { get; set; }
        public Genero Genero { get; set; }
        public int Estado_CivilID { get; set; }
        public Estado_Civil Estado_Civil { get; set; }
        public int Tipo_IdentidadID { get; set; }
        public Tipo_Identidad Tipo_Identidad { get; set; }
        public string telefono { get; set; }
        public int Tipo_TelefonoID { get; set; }
        public Tipo_Telefono Tipo_Telefono { get; set; }
        public int Tipo_CompaniaID { get; set; }
        public Tipo_Compania Tipo_Compania { get; set; }

        
        public DateTime Today { get; set; }

        //public SelectList genero { get; set; }

    }
}

