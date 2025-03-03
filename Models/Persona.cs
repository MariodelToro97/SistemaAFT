﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Persona
	{
        
		public int PersonaID { get; set; }
        [RegularExpression("^[A-Z]{4}[0-9]{6}[H,M][A-Z]{5}[A-Z,0-9][0-9]", ErrorMessage = "La CURP no es Válida")]
        [Required(ErrorMessage = "Campo requerido")]
        public string CURP { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("^[A-Z]{4}[0-9]{6}[A-Z,0-9]{3}", ErrorMessage = "El RFC no es válido")]
        public string RFC { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression("^[A-ZÑÁÉÍÓÚ]+[.]*([ ]*[A-ZÑÁÉÍÓÚ]*)*", ErrorMessage = "Formato no válido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression("^[A-ZÑÁÉÍÓÚ]+([ ]*[A-ZÑÁÉÍÓÚ]*)*", ErrorMessage = "Formato no válido")]
        public string apellido_paterno { get; set; }
        [RegularExpression("^[A-ZÑÁÉÍÓÚ]+([ ]*[A-ZÑÁÉÍÓÚ]*)*", ErrorMessage = "Formato no válido")]
        public string apellido_materno { get; set; }
        public string correo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string fechaNacimiento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int NacionalidadID { get; set; }
        public Nacionalidad Nacionalidad { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int GeneroID { get; set; }
        public Genero Genero { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Estado_CivilID { get; set; }
        public Estado_Civil Estado_Civil { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Tipo_IdentidadID { get; set; }
        public Tipo_Identidad Tipo_Identidad { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string num_identificacion { get; set; }
        public int Tipo_PersonaID { get; set; }
        public Tipo_Persona Tipo_Persona { get; set; }
        public int EtniaID { get; set; }
        public Etnia Etnia { get; set; }
        public int DiscapacidadID { get; set; }
        public Discapacidad Discapacidad { get; set; }
        [Required(ErrorMessage = "ACUSE SURI")]
        public string ACUSESURI { get; set; } = "ACUSE SURI";
        [Required(ErrorMessage ="Campo Requerido")]
        [RegularExpression("^[A-ZÑÁÉÍÓÚ]+([.]*[ ]*[A-ZÑÁÉÍÓÚ]*)*", ErrorMessage = "Formato no válido")]
        public string nombreMoral { get; set; }
        public ICollection<Domicilio> Domicilios { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Campo Requerido")]
        public int actividadEconomica { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string fecha_Consti { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string folio_Acta { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int num_Notario { get; set; }


    }
}

