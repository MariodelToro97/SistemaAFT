using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class GranModelo
    {
        public Persona Persona { get; set; }
        public Domicilio Domicilio { get; set; }   
        public Integrante Integrante { get; set; }
        public Representante Representante { get; set; }
        public documentoRepresentante documentoRepresentante { get; set; }
        public Telefono Telefono { get; set; }
        public Solicitud Solicitud { get; set; }

        public Proyecto Proyecto { get; set; }


    }
}
