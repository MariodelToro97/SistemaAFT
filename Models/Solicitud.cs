using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Solicitud
    {
        public int SolicitudID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int YearID { get; set; }
        public Year Year { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int ProgramaID { get; set; }
        public Programa Programa { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int ComponenteID { get; set; }
        public Componente Componente { get; set; }
        public int Instancia_EjecutoraID { get; set; }
        public Instancia_Ejecutora Instancia_Ejecutora { get; set; }
        public int DelegacionID { get; set; }
        public Delegacion Delegacion { get; set; }
    }
}
