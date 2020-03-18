using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class Cotizacion
    {
        public int CotizacionID { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Concepto_ApoyoID { get; set; }        
        public Concepto_Apoyo Concepto_Apoyo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Subconcepto_ApoyoID { get; set; }
        public Subconcepto_Apoyo Subconcepto_Apoyo { get; set; }
        public string Unidad_Medida { get; set; }
        public string Unidad_Impacto { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public float can_Sol { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public float cos_Uni { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public float apo_Pro { get; set; }
        public float apo_Fed { get; set; }
        public float apo_Est { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public float mon_Apo { get; set; }
        public float otro_Apo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public float inv_Total { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Descripcion { get; set; }
    }
}
