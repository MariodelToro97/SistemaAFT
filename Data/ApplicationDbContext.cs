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
	}
}
