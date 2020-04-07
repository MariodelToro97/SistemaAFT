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

        public Year Year { get; set; }
        
        public Programa Programa { get; set; }

        public Componente Componente { get; set; }
        public Instancia_Ejecutora Instancia_Ejecutora { get; set; }

        public Delegacion Delegacion { get; set; }

        public Cotizacion Cotizacion { get; set; }




    }
}
