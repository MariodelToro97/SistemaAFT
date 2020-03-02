using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Tipo_Compania
	{
		public int Tipo_CompaniaID { get; set; }
		public string Nombre { get; set; }
		public ICollection<Persona> Personas { get; set; }

	}
}
