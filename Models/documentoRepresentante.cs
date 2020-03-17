using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
    public class documentoRepresentante
    {
        public int documentoRepresentanteID { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int tipoDocumento { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string folioDocumento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string fechaDocumento { get; set; }
        public int RepresentanteID { get; set; }
        public Representante Representante { get; set; }
    }
}
