using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAFT.Models
{
	public class Tipo_Vialidad
	{
		public int Tipo_VialidadID { get; set; }
		public string Nombre { get; set; }
		public ICollection<Domicilio> Domicilios { get; set; }
	}
}
