using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Tipo_Telefono
	{
		public int Tipo_TelefonoID { get; set; }
		public string Nombre { get; set; }
		public ICollection<Persona> Personas { get; set; }

	}
}
