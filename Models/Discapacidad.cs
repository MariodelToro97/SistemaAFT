using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Discapacidad
    {
        public int DiscapacidadID { get; set; }
        public string Tiene_Discapacidad { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
