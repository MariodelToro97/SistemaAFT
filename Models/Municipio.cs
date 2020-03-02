using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Municipio
	{
		public int MunicipioID { get; set; }
		public string Nombre { get; set; }
		public ICollection<Domicilio> Domicilios { get; set; }
	}
}
