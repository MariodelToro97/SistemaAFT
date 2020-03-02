using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Tipo_Identidad
	{
		public int Tipo_IdentidadID { get; set; }
		public string Nombre { get; set; }
		public ICollection<Persona> Personas { get; set; }
	}
}
