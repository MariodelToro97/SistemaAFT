using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaAFT.Models;

namespace SistemaAFT.Data
{
	public class DbInitializer
	{
		public static void Initialize (ApplicationDbContext context)
		{
			context.Database.EnsureCreated();

			if (context.Genero.Any() || context.Estado_Civil.Any() || context.Tipo_Identidad.Any() || context.Municipio.Any() || context.Tipo_Telefono.Any() || context.Tipo_Compania.Any() || context.Tipo_Persona.Any())
			{
				return;
			}

			var generos = new Genero[]
			{
				new Genero {Nombre_Genero = "Masculino"},
				new Genero {Nombre_Genero = "Femenino"}
			};

			foreach (Genero g in generos )
			{
				context.Genero.Add(g);
			}

			//ESTADO CIVIL
			var civil = new Estado_Civil[]
			{
				new Estado_Civil {Nombre_Edo_Civil = "Soltero"},
				new Estado_Civil {Nombre_Edo_Civil = "Casado"},
				new Estado_Civil {Nombre_Edo_Civil = "Divorciado"},
				new Estado_Civil {Nombre_Edo_Civil = "Viudo/a"},
				new Estado_Civil {Nombre_Edo_Civil = "Unión Libre"},
			};

			foreach (Estado_Civil g in civil)
			{
				context.Estado_Civil.Add(g);
			}


			//TIPO DE IDENTIDAD
			var tipo_identidad = new Tipo_Identidad[]
			{
				new Tipo_Identidad {Nombre = "INE"},
				new Tipo_Identidad {Nombre = "Pasaporte"},
				new Tipo_Identidad {Nombre = "Cédula Profesional"},
				new Tipo_Identidad {Nombre = "Licencia de conducir"}
			};

			foreach (Tipo_Identidad g in tipo_identidad)
			{
				context.Tipo_Identidad.Add(g);
			}


			//MUNICIPIO
			var municipio = new Municipio[]
			{
				new Municipio {Nombre = "Armería"},
				new Municipio {Nombre = "Tecomán"},
				new Municipio {Nombre = "Manzanillo"},
				new Municipio {Nombre = "Coquimatlán"},
				new Municipio {Nombre = "Colima"},
				new Municipio {Nombre = "Cuahutémoc"},
				new Municipio {Nombre = "Comala"},
				new Municipio {Nombre = "Ixtlahuacán"},
				new Municipio {Nombre = "Minatitlán"},
				new Municipio {Nombre = "Villa de Álvarez"},
			};

			foreach (Municipio g in municipio)
			{
				context.Municipio.Add(g);
			}

			//TIPO DE TELEFONO
			var tipo_telefono = new Tipo_Telefono[]
			{
				new Tipo_Telefono {Nombre = "Móvil"},
				new Tipo_Telefono {Nombre = "Fijo"},
				new Tipo_Telefono {Nombre = "Oficina"}
			};

			foreach (Tipo_Telefono g in tipo_telefono)
			{
				context.Tipo_Telefono.Add(g);
			}

			//TIPO DE COMPANIA
			var tipo_compania = new Tipo_Compania[]
			{
				new Tipo_Compania {Nombre = "Telcel"},
				new Tipo_Compania {Nombre = "Movistar"},
				new Tipo_Compania {Nombre = "AT&T"},
				new Tipo_Compania {Nombre = "Unefón"},
				new Tipo_Compania {Nombre = "Virgin Móvil"},
				new Tipo_Compania {Nombre = "Simplii"},
				new Tipo_Compania {Nombre = "FreedomPop"},
				new Tipo_Compania {Nombre = "Flash Móvil"},
				new Tipo_Compania {Nombre = "Weex"},
				new Tipo_Compania {Nombre = "Cierto"},
				new Tipo_Compania {Nombre = "Aló"},
				new Tipo_Compania {Nombre = "Maz Tiempo"},
				new Tipo_Compania {Nombre = "Toca Móvil"},
				new Tipo_Compania {Nombre = "QBOcel"},

			};

			foreach (Tipo_Compania g in tipo_compania)
			{
				context.Tipo_Compania.Add(g);
			}

			//Tipo de persona
			var tipo_persona = new Tipo_Persona[]
			{
				new Tipo_Persona { Nombre_Tipo = "Fisica"},
				new Tipo_Persona { Nombre_Tipo = "Moral" }
			};

			foreach (Tipo_Persona g in tipo_persona)
			{
				context.Tipo_Persona.Add(g);
			}

			context.SaveChanges();
		}
	}
}
