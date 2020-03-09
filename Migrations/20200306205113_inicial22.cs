using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaAFT.Migrations
{
    public partial class inicial22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discapacidad",
                columns: table => new
                {
                    DiscapacidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tiene_Discapacidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discapacidad", x => x.DiscapacidadID);
                });

            migrationBuilder.CreateTable(
                name: "Estado_Civil",
                columns: table => new
                {
                    Estado_CivilID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Edo_Civil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Civil", x => x.Estado_CivilID);
                });

            migrationBuilder.CreateTable(
                name: "Etnia",
                columns: table => new
                {
                    EtniaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pertenece_Etnia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etnia", x => x.EtniaID);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Genero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    MunicipioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.MunicipioID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Ambito",
                columns: table => new
                {
                    Tipo_AmbitoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Ambito", x => x.Tipo_AmbitoID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Asentamiento",
                columns: table => new
                {
                    Tipo_AsentamientoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Asentamiento", x => x.Tipo_AsentamientoID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Identidad",
                columns: table => new
                {
                    Tipo_IdentidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Identidad", x => x.Tipo_IdentidadID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Persona",
                columns: table => new
                {
                    Tipo_PersonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Persona", x => x.Tipo_PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Vialidad",
                columns: table => new
                {
                    Tipo_VialidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Vialidad", x => x.Tipo_VialidadID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURP = table.Column<string>(nullable: false),
                    RFC = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: false),
                    apellido_paterno = table.Column<string>(nullable: false),
                    apellido_materno = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<string>(nullable: false),
                    nacionalidad = table.Column<string>(nullable: false),
                    GeneroID = table.Column<int>(nullable: false),
                    Estado_CivilID = table.Column<int>(nullable: false),
                    Tipo_IdentidadID = table.Column<int>(nullable: false),
                    num_identificacion = table.Column<string>(nullable: false),
                    telefono = table.Column<string>(nullable: true),
                    Tipo_PersonaID = table.Column<int>(nullable: false),
                    EtniaID = table.Column<int>(nullable: false),
                    DiscapacidadID = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaID);
                    table.ForeignKey(
                        name: "FK_Persona_Discapacidad_DiscapacidadID",
                        column: x => x.DiscapacidadID,
                        principalTable: "Discapacidad",
                        principalColumn: "DiscapacidadID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Estado_Civil_Estado_CivilID",
                        column: x => x.Estado_CivilID,
                        principalTable: "Estado_Civil",
                        principalColumn: "Estado_CivilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Etnia_EtniaID",
                        column: x => x.EtniaID,
                        principalTable: "Etnia",
                        principalColumn: "EtniaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Genero_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Genero",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Tipo_Identidad_Tipo_IdentidadID",
                        column: x => x.Tipo_IdentidadID,
                        principalTable: "Tipo_Identidad",
                        principalColumn: "Tipo_IdentidadID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Tipo_Persona_Tipo_PersonaID",
                        column: x => x.Tipo_PersonaID,
                        principalTable: "Tipo_Persona",
                        principalColumn: "Tipo_PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    DomicilioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_AmbitoID = table.Column<int>(nullable: false),
                    estado = table.Column<string>(nullable: true),
                    nombreasentamiento = table.Column<string>(nullable: true),
                    Tipo_VialidadID = table.Column<int>(nullable: false),
                    noexterior = table.Column<string>(nullable: true),
                    MunicipioID = table.Column<int>(nullable: false),
                    referenciavialidad = table.Column<string>(nullable: true),
                    nombrevialidad = table.Column<string>(nullable: true),
                    nointerior = table.Column<string>(nullable: true),
                    localidad = table.Column<string>(nullable: true),
                    referenciaposterior = table.Column<string>(nullable: true),
                    codigopostal = table.Column<string>(nullable: true),
                    Tipo_AsentamientoID = table.Column<int>(nullable: false),
                    referenciaubicacion = table.Column<string>(nullable: true),
                    PersonaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.DomicilioID);
                    table.ForeignKey(
                        name: "FK_Domicilio_Municipio_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipio",
                        principalColumn: "MunicipioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Domicilio_Persona_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Persona",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Domicilio_Tipo_Ambito_Tipo_AmbitoID",
                        column: x => x.Tipo_AmbitoID,
                        principalTable: "Tipo_Ambito",
                        principalColumn: "Tipo_AmbitoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Domicilio_Tipo_Asentamiento_Tipo_AsentamientoID",
                        column: x => x.Tipo_AsentamientoID,
                        principalTable: "Tipo_Asentamiento",
                        principalColumn: "Tipo_AsentamientoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Domicilio_Tipo_Vialidad_Tipo_VialidadID",
                        column: x => x.Tipo_VialidadID,
                        principalTable: "Tipo_Vialidad",
                        principalColumn: "Tipo_VialidadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_MunicipioID",
                table: "Domicilio",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_PersonaID",
                table: "Domicilio",
                column: "PersonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_Tipo_AmbitoID",
                table: "Domicilio",
                column: "Tipo_AmbitoID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_Tipo_AsentamientoID",
                table: "Domicilio",
                column: "Tipo_AsentamientoID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_Tipo_VialidadID",
                table: "Domicilio",
                column: "Tipo_VialidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_DiscapacidadID",
                table: "Persona",
                column: "DiscapacidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Estado_CivilID",
                table: "Persona",
                column: "Estado_CivilID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_EtniaID",
                table: "Persona",
                column: "EtniaID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_GeneroID",
                table: "Persona",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Tipo_IdentidadID",
                table: "Persona",
                column: "Tipo_IdentidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Tipo_PersonaID",
                table: "Persona",
                column: "Tipo_PersonaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Domicilio");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Tipo_Ambito");

            migrationBuilder.DropTable(
                name: "Tipo_Asentamiento");

            migrationBuilder.DropTable(
                name: "Tipo_Vialidad");

            migrationBuilder.DropTable(
                name: "Discapacidad");

            migrationBuilder.DropTable(
                name: "Estado_Civil");

            migrationBuilder.DropTable(
                name: "Etnia");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Tipo_Identidad");

            migrationBuilder.DropTable(
                name: "Tipo_Persona");
        }
    }
}
