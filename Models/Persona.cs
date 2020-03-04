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
        [RegularExpression("^.* (?=.{18})(?=.*[0 - 9])(?=.*[A - ZÑ]).*$", ErrorMessage = "La CURP no es VALIDA")]
        [Required(ErrorMessage = "Se requiere la CRUP")]
        public string CURP { get; set; }
        [Required(ErrorMessage = "Se requiere el RFC")]
        public string RFC { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string correo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string fechaNacimiento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string nacionalidad { get; set; }
        public int GeneroID { get; set; }
        public Genero Genero { get; set; }
        public int Estado_CivilID { get; set; }
        public Estado_Civil Estado_Civil { get; set; }
        public int Tipo_IdentidadID { get; set; }
        public Tipo_Identidad Tipo_Identidad { get; set; }
        [Required(ErrorMessage = "Se requiere num de indentificacion")]
        public string num_identificacion { get; set; }
        public string telefono { get; set; }
        public int Tipo_PersonaID { get; set; }
        public Tipo_Persona Tipo_Persona { get; set; }
        public int EtniaID { get; set; }
        public Etnia Etnia { get; set; }
        public int DiscapacidadID { get; set; }
        public Discapacidad Discapacidad { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.Now;


    }
}

