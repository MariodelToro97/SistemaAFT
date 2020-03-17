using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaAFT.Models;

namespace SistemaAFT.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<SistemaAFT.Models.Persona> Persona { get; set; }
		public DbSet<SistemaAFT.Models.Domicilio> Domicilio { get; set; }
		public DbSet<SistemaAFT.Models.Genero> Genero { get; set; }
		public DbSet<SistemaAFT.Models.Estado_Civil> Estado_Civil { get; set; }
		public DbSet<SistemaAFT.Models.Tipo_Identidad> Tipo_Identidad { get; set; }
		public DbSet<SistemaAFT.Models.Municipio> Municipio { get; set; }
		public DbSet<SistemaAFT.Models.Tipo_Persona> Tipo_Persona { get; set; }
		public DbSet<SistemaAFT.Models.Etnia> Etnia { get; set; }
		public DbSet<SistemaAFT.Models.Discapacidad> Discapacidad { get; set; }
		public DbSet<SistemaAFT.Models.Tipo_Ambito> Tipo_Ambito { get; set; }
		public DbSet<SistemaAFT.Models.Tipo_Asentamiento> Tipo_Asentamiento { get; set; }
		public DbSet<SistemaAFT.Models.Tipo_Vialidad> Tipo_Vialidad { get; set; }
		public DbSet<SistemaAFT.Models.Integrante> Integrante { get; set; }
		public DbSet<SistemaAFT.Models.Representante> Representante { get; set; }
		public DbSet<SistemaAFT.Models.documentoRepresentante> documentoRepresentante { get; set; }
		public DbSet<SistemaAFT.Models.Nacionalidad> Nacionalidad { get; set; }

	}
}
