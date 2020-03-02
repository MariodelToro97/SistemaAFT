using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Estado_Civil
	{
		public int Estado_CivilID { get; set; }
		public string Nombre_Edo_Civil { get; set; }
		public ICollection<Persona> Personas { get; set; }

	}
}
