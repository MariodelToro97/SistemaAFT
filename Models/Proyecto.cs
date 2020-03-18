using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Proyecto
    {
        public int ProyectoID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string nombreProyecto { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Tipo_ProyectoID { get; set; }
        public Tipo_Proyecto Tipo_Proyecto { get; set; }
        public string objetivo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string fechaRecepcion { get; set; }
        public int SolicitudID { get; set; }
        public Solicitud Solicitud { get; set; }

    }
}
