using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Genero
	{
		public int GeneroID { get; set; }
		public string Nombre_Genero { get; set; }

		public ICollection<Persona> Personas { get; set; }

	}
}
