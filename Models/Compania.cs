using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Compania
    {
        public int CompaniaID { get; set; }
        public string nombre_compania { get; set; }

        public ICollection<Telefono> Telefonos { get; set; }
    }
}
