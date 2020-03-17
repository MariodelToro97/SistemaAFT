using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Representante
    {
        public int RepresentanteID { get; set; }
        [RegularExpression("^[A-Z]{4}[0-9]{6}[H,M][A-Z]{5}[A-Z,0-9][0-9]", ErrorMessage = "La CURP no es Válida")]
        [Required(ErrorMessage = "Campo requerido")]
        public string CURP { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]     
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }

        public int PersonaID { get; set; }
        public Persona Persona { get; set; }
    }
}
