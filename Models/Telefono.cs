using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Telefono
    {
        public int TelefonoID { get; set; }
        public string numero { get; set; }
        public int CompaniaID { get; set; }
        public Compania Compania { get; set; }
        public int Tipo_TelefonoID { get; set; }
        public Tipo_Telefono Tipo_Telefono { get; set; }
        public int PersonaID { get; set; }
        public Persona Persona { get; set; }

    }
}
