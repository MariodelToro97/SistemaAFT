using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Nacionalidad
    {
        public int NacionalidadID { get; set; }
        public string Nombre { get; set; }
        public ICollection<Persona> Persona { get; set; }
    }
}
