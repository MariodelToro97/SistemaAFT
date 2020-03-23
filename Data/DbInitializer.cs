﻿using System;
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

			if (context.Year.Any() || context.Programa.Any() || context.Componente.Any() || context.Instancia_Ejecutora.Any() || context.Delegacion.Any() ||
				context.Nacionalidad.Any() || context.Tipo_Documento.Any()  || context.Genero.Any() || 
				context.Estado_Civil.Any() || context.Tipo_Identidad.Any() || context.Municipio.Any() || 
				context.Tipo_Persona.Any() || context.Etnia.Any() || context.Discapacidad.Any() || 
				context.Tipo_Ambito.Any() || context.Tipo_Asentamiento.Any() || context.Tipo_Vialidad.Any() || context.Tipo_Proyecto.Any())
			{
				return;
			}

			//YEAR
			var tipo_proyecto = new Tipo_Proyecto[]
			{
				new Tipo_Proyecto {Nombre = "Social"},
				new Tipo_Proyecto {Nombre = "Privado"},

			};

			foreach (Tipo_Proyecto g in tipo_proyecto)
			{
				context.Tipo_Proyecto.Add(g);
			}

			//YEAR
			var year = new Year[]
			{
				new Year {year = 2020},
			};

			foreach (Year g in year)
			{
				context.Year.Add(g);
			}

			//PROGRAMA
			var programa = new Programa[]
			{
				new Programa {nombre = "prestamos para tractor"},
				new Programa {nombre = "prestamos para terreno"},
				new Programa {nombre = "prestamos para comida"},
				new Programa {nombre = "prestamos para carros"},
				new Programa {nombre = "prestamos para huertas"},
				new Programa {nombre = "prestamos para casas"},

			};

			foreach (Programa g in programa)
			{
				context.Programa.Add(g);
			}

			//COMPONENTE
			var componente = new Componente[]
			{
				new Componente {nombre = "Componente 1"},
				new Componente {nombre = "Componente 2"},
				new Componente {nombre = "Componente 3"},
				new Componente {nombre = "Componente 4"},
				new Componente {nombre = "Componente 5"},
				new Componente {nombre = "Componente 6"},
			};

			foreach (Componente g in componente)
			{
				context.Componente.Add(g);
			}

			//INSTANCIA EJECUTORA
			var instancia = new Instancia_Ejecutora[]
			{
				new Instancia_Ejecutora {nombre = "Instancia 1"},
				new Instancia_Ejecutora {nombre = "Instancia 2"},
				new Instancia_Ejecutora {nombre = "Instancia 3"},

			};

			foreach (Instancia_Ejecutora g in instancia)
			{
				context.Instancia_Ejecutora.Add(g);
			}

			//DELEGACION
			var delegacion = new Delegacion[]
			{
				new Delegacion {nombre = "Delegacion 1"},
				new Delegacion {nombre = "Delegacion 2"},
				new Delegacion {nombre = "Delegacion 3"},

			};

			foreach (Delegacion g in delegacion)
			{
				context.Delegacion.Add(g);
			}

			//COMPANIA
			var compania = new Compania[]
			{
				new Compania {nombre_compania = "Telcel"},
				new Compania {nombre_compania = "Movistar"}
			};

			foreach (Compania g in compania)
			{
				context.Compania.Add(g);
			}

			//TUIPO_TELEFONO
			var tipo_telefono = new Tipo_Telefono[]
			{
				new Tipo_Telefono {nombre_tipo = "Fijo"},
				new Tipo_Telefono {nombre_tipo = "Movil"}
			};

			foreach (Tipo_Telefono g in tipo_telefono)
			{
				context.Tipo_Telefono.Add(g);
			}

			//GENEROS
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
				new Estado_Civil {Nombre_Edo_Civil = "Concubinato"},
			};

			foreach (Estado_Civil g in civil)
			{
				context.Estado_Civil.Add(g);
			}


			//TIPO DE IDENTIDAD
			var tipo_identidad = new Tipo_Identidad[]
			{				
				new Tipo_Identidad {Nombre = "Cartilla del servicio militar"},
				new Tipo_Identidad {Nombre = "Licencia de Manejo"},
				new Tipo_Identidad {Nombre = "Pasaporte"},
				new Tipo_Identidad {Nombre = "Credencial para votar con fotografía"},
				new Tipo_Identidad {Nombre = "Credencial del IMSS o del ISSSTE"},
				new Tipo_Identidad {Nombre = "Constancia exp. por autoridad legal con fotografía"},
				new Tipo_Identidad {Nombre = "Cédula profesional"},
				new Tipo_Identidad {Nombre = "Credencial del Instituto Nacional de la SENECTUD"},
				new Tipo_Identidad {Nombre = "Acta de nacimiento"},
				new Tipo_Identidad {Nombre = "Credencial o acta de naturalización exp. por Sec. de Rel. Exteriores"},
				new Tipo_Identidad {Nombre = "Tarjeta PROCAMPO"},
				new Tipo_Identidad {Nombre = "Tarjeta SAGARPA/CURP"},
				new Tipo_Identidad {Nombre = "Libreta de mar o navegación con fotoggrafía exp. por la SCT"},
				new Tipo_Identidad {Nombre = "Credencial de Pesca"},
				new Tipo_Identidad {Nombre = "CURP"},
				new Tipo_Identidad {Nombre = "INE ESTATAL"},
				new Tipo_Identidad {Nombre = "Instituto Nacional de las personas Adultas y Mayores (INAPAM)"},
				new Tipo_Identidad {Nombre = "Credencial del Servicio Postal Mexicano"},
				new Tipo_Identidad {Nombre = "Matricula consular"}
			};

			foreach (Tipo_Identidad g in tipo_identidad)
			{
				context.Tipo_Identidad.Add(g);
			}


			//MUNICIPIO 
			/*
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
			*/
			
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

			//Tipo de Etnia
			var tipo_etnia = new Etnia[]
			{
				new Etnia { Pertenece_Etnia = "Si"},
				new Etnia { Pertenece_Etnia = "No" }
			};

			foreach (Etnia g in tipo_etnia)
			{
				context.Etnia.Add(g);
			}

			//Discapacidad
			var discapacidad = new Discapacidad[]
			{
				new Discapacidad {Tiene_Discapacidad = "Si"},
				new Discapacidad {Tiene_Discapacidad = "No"}
			};

			foreach(Discapacidad g in discapacidad)
			{
				context.Discapacidad.Add(g);
			}

			//tipo ambito
			var tipo_ambito = new Tipo_Ambito[]
			{
				new Tipo_Ambito {Nombre = "AMBITO URBANO"},
				new Tipo_Ambito {Nombre = "AMBITO RURAL"},
				new Tipo_Ambito {Nombre = "SOBRE VIA DE COMUNICACION"},
				new Tipo_Ambito {Nombre = "NO DEFINIDO"},
			};

			foreach (Tipo_Ambito g in tipo_ambito)
			{
				context.Tipo_Ambito.Add(g);
			}

			//tipo asentamiento
			var tipo_asentamiento = new Tipo_Asentamiento[]
			{
				new Tipo_Asentamiento {Nombre = "AEROPUERTO"},
				new Tipo_Asentamiento {Nombre = "AMPLIACION"},
				new Tipo_Asentamiento {Nombre = "BARRIO"},
				new Tipo_Asentamiento {Nombre = "CAMPAMENTO"},
				new Tipo_Asentamiento {Nombre = "CANTON"},
				new Tipo_Asentamiento {Nombre = "CIUDAD"},
				new Tipo_Asentamiento {Nombre = "CIUDAD INDUSTRIAL"},
				new Tipo_Asentamiento {Nombre = "CLUB DE GOLF"},
				new Tipo_Asentamiento {Nombre = "COLONIA"},
				new Tipo_Asentamiento {Nombre = "CONDOMINIO"},
				new Tipo_Asentamiento {Nombre = "CONGREGACION"},
				new Tipo_Asentamiento {Nombre = "CONJUNTO HABITACIONAL"},
				new Tipo_Asentamiento {Nombre = "CORREDOR INDUSTRIAL"},
				new Tipo_Asentamiento {Nombre = "COTO"},
				new Tipo_Asentamiento {Nombre = "CUARTEL"},
				new Tipo_Asentamiento {Nombre = "EJIDO"},
				new Tipo_Asentamiento {Nombre = "EQUIPAMIENTO"},
				new Tipo_Asentamiento {Nombre = "ESTACION"},
				new Tipo_Asentamiento {Nombre = "EXHACIENDA"},
				new Tipo_Asentamiento {Nombre = "FINCA"},
				new Tipo_Asentamiento {Nombre = "FRACCION"},
				new Tipo_Asentamiento {Nombre = "FRACCIONAMIENTO"},
				new Tipo_Asentamiento {Nombre = "GRAN USUARIO"},
				new Tipo_Asentamiento {Nombre = "GRANJA"},
				new Tipo_Asentamiento {Nombre = "HACIENDA"},
				new Tipo_Asentamiento {Nombre = "INGENIO"},
				new Tipo_Asentamiento {Nombre = "MANZANA"},
				new Tipo_Asentamiento {Nombre = "PARAJE"},
				new Tipo_Asentamiento {Nombre = "PARQUE INDUSTRIAL"},
				new Tipo_Asentamiento {Nombre = "POBLADO COMUNAL"},
				new Tipo_Asentamiento {Nombre = "PRIVADA"},
				new Tipo_Asentamiento {Nombre = "PROLONGACION"},
				new Tipo_Asentamiento {Nombre = "PUEBLO"},
				new Tipo_Asentamiento {Nombre = "PUERTO"},
				new Tipo_Asentamiento {Nombre = "RANCHERIA"},
				new Tipo_Asentamiento {Nombre = "RANCHO"},
				new Tipo_Asentamiento {Nombre = "REGION"},
				new Tipo_Asentamiento {Nombre = "RESIDENCIAL"},
				new Tipo_Asentamiento {Nombre = "RINCONADA"},
				new Tipo_Asentamiento {Nombre = "SECCION"},
				new Tipo_Asentamiento {Nombre = "SECTOR"},
				new Tipo_Asentamiento {Nombre = "SUPERMANZANA"},
				new Tipo_Asentamiento {Nombre = "UNIDAD"},
				new Tipo_Asentamiento {Nombre = "UNIDAD HABITACIONAL"},
				new Tipo_Asentamiento {Nombre = "VILLA"},
				new Tipo_Asentamiento {Nombre = "ZONA COMERCIAL"},
				new Tipo_Asentamiento {Nombre = "ZONA FEDERAL"},
				new Tipo_Asentamiento {Nombre = "ZONA INDUSTRIAL"},
				new Tipo_Asentamiento {Nombre = "ZONA MILITAR"},
				new Tipo_Asentamiento {Nombre = "ZONA NAVAL"},
			};

			foreach (Tipo_Asentamiento g in tipo_asentamiento)
			{
				context.Tipo_Asentamiento.Add(g);
			}

			//tipo vialid
			var tipo_vialidad = new Tipo_Vialidad[]
			{
				new Tipo_Vialidad {Nombre = "AMPLIACION"},
				new Tipo_Vialidad {Nombre = "ANDADOR"},
				new Tipo_Vialidad {Nombre = "AVENIDA"},
				new Tipo_Vialidad {Nombre = "BOULEVARD"},
				new Tipo_Vialidad {Nombre = "CALLE"},
				new Tipo_Vialidad {Nombre = "CALLEJON"},
				new Tipo_Vialidad {Nombre = "CALZADA"},
				new Tipo_Vialidad {Nombre = "CERRADA"},
				new Tipo_Vialidad {Nombre = "CIRCUITO"},
				new Tipo_Vialidad {Nombre = "CIRCUNVALACION"},
				new Tipo_Vialidad {Nombre = "CONTINUACION"},
				new Tipo_Vialidad {Nombre = "CORREDOR"},
				new Tipo_Vialidad {Nombre = "DIAGONAL"},
				new Tipo_Vialidad {Nombre = "EJE VIAL"},
				new Tipo_Vialidad {Nombre = "PASAJE"},
				new Tipo_Vialidad {Nombre = "PEATONAL"},
				new Tipo_Vialidad {Nombre = "PERIFERICO"},
				new Tipo_Vialidad {Nombre = "PRIVADA"},
				new Tipo_Vialidad {Nombre = "PROLONGACION"},
				new Tipo_Vialidad {Nombre = "RETORNO"},
				new Tipo_Vialidad {Nombre = "VIADUCTO"},
				new Tipo_Vialidad {Nombre = "CARRETERA"},
				new Tipo_Vialidad {Nombre = "CAMINO"}
			};

			foreach (Tipo_Vialidad g in tipo_vialidad)
			{
				context.Tipo_Vialidad.Add(g);
			}

			//Nacionalidad
			var nacionalidad = new Nacionalidad[]
			{
				new Nacionalidad {Nombre = "MEXICANO"},
				new Nacionalidad {Nombre = "EXTRANJERA"}
			};

			foreach (Nacionalidad g in nacionalidad)
			{
				context.Nacionalidad.Add(g);
			}

			//Tipo de documento
			var tipoDocumento = new Tipo_Documento[]
			{
				new Tipo_Documento {nombre = "ACTA CONSTITUTIVA"},
				new Tipo_Documento {nombre = "ANEXO MODIFICATORIO DE ACTA CONSTITUTIVA"},
				new Tipo_Documento {nombre = "OTRO"},
				new Tipo_Documento {nombre = "PODER NOTARIAL"},
				new Tipo_Documento {nombre = "CARTA PODER SIMPLE"},
				new Tipo_Documento {nombre = "CARTA PODER ANTE NOTARIO"},
				new Tipo_Documento {nombre = "ACTA DE ASAMBLEA"}
			};

			foreach (Tipo_Documento g in tipoDocumento)
			{
				context.Tipo_Documento.Add(g);
			}

			context.SaveChanges();
		}
	}
}
