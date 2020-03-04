using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Etnia
    {
        public int EtniaID { get; set; }
        public string Pertenece_Etnia { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
