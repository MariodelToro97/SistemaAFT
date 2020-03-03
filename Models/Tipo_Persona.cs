using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Tipo_Persona
    {
        public int Tipo_PersonaID { get; set; }
        public string Nombre_Tipo { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
