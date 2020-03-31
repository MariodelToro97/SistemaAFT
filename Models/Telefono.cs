using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Telefono
    {
        public int TelefonoID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string numero { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int CompaniaID { get; set; }
        public Compania Compania { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Tipo_TelefonoID { get; set; }
        public Tipo_Telefono Tipo_Telefono { get; set; }
        public int PersonaID { get; set; }
        public Persona Persona { get; set; }

    }
}
