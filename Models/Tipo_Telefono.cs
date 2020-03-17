using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Tipo_Telefono
    {
        public int Tipo_TelefonoID { get; set; }
        public string nombre_tipo { get; set; }

        public ICollection<Telefono> Telefonos { get; set; }
    }
}
