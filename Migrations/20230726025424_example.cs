using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Login_Pape.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    PkCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Capacidad = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.PkCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    PkCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    PlanE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.PkCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    PkMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.PkMateria);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "Semestres",
                columns: table => new
                {
                    PkSemestre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Semestres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestres", x => x.PkSemestre);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    PkTurnos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    Fin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.PkTurnos);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    ApellidoP = table.Column<string>(type: "text", nullable: true),
                    ApellidoM = table.Column<string>(type: "text", nullable: true),
                    SuperMz = table.Column<string>(type: "text", nullable: true),
                    Mz = table.Column<string>(type: "text", nullable: true),
                    Lt = table.Column<string>(type: "text", nullable: true),
                    Calle = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    CURP = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    FkRoles = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUser);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRoles",
                        column: x => x.FkRoles,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    PkGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    FkCarrera = table.Column<int>(type: "int", nullable: true),
                    FkTurno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.PkGrupo);
                    table.ForeignKey(
                        name: "FK_Grupos_Carreras_FkCarrera",
                        column: x => x.FkCarrera,
                        principalTable: "Carreras",
                        principalColumn: "PkCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupos_Turnos_FkTurno",
                        column: x => x.FkTurno,
                        principalTable: "Turnos",
                        principalColumn: "PkTurnos",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aspirantes",
                columns: table => new
                {
                    PkAspirante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(type: "text", nullable: true),
                    Carrera = table.Column<string>(type: "text", nullable: true),
                    ActaPDF = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    CertificadoPDF = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    CurpPDF = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    FkUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspirantes", x => x.PkAspirante);
                    table.ForeignKey(
                        name: "FK_Aspirantes_Usuarios_FkUser",
                        column: x => x.FkUser,
                        principalTable: "Usuarios",
                        principalColumn: "PkUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    PkEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Jornada = table.Column<string>(type: "text", nullable: true),
                    InicioJ = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinJ = table.Column<TimeSpan>(type: "time", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    FkRol = table.Column<int>(type: "int", nullable: true),
                    FkUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.PkEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "PkUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    PkProfe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Jornada = table.Column<string>(type: "text", nullable: true),
                    InicioJ = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinJ = table.Column<TimeSpan>(type: "time", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    FkUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.PkProfe);
                    table.ForeignKey(
                        name: "FK_Profesores_Usuarios_FkUser",
                        column: x => x.FkUser,
                        principalTable: "Usuarios",
                        principalColumn: "PkUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    PkEstudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Carrera = table.Column<string>(type: "text", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    ActaPDF = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    CertificadoPDF = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    CurpPDF = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    Nss = table.Column<string>(type: "text", nullable: true),
                    Matricula = table.Column<string>(type: "text", nullable: true),
                    ContactoE = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    Situacion = table.Column<string>(type: "text", nullable: true),
                    Generacion = table.Column<string>(type: "text", nullable: true),
                    FkUser = table.Column<int>(type: "int", nullable: true),
                    FkCarrera = table.Column<int>(type: "int", nullable: true),
                    FCarreraPkCarrera = table.Column<int>(type: "int", nullable: true),
                    FkGrupo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.PkEstudent);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Carreras_FCarreraPkCarrera",
                        column: x => x.FCarreraPkCarrera,
                        principalTable: "Carreras",
                        principalColumn: "PkCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Grupos_FkGrupo",
                        column: x => x.FkGrupo,
                        principalTable: "Grupos",
                        principalColumn: "PkGrupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Usuarios_FkUser",
                        column: x => x.FkUser,
                        principalTable: "Usuarios",
                        principalColumn: "PkUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Dia = table.Column<DateTime>(type: "datetime", nullable: false),
                    Inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    Fin = table.Column<TimeSpan>(type: "time", nullable: false),
                    FkGrupo = table.Column<int>(type: "int", nullable: true),
                    FkAula = table.Column<int>(type: "int", nullable: true),
                    FkMateria = table.Column<int>(type: "int", nullable: true),
                    FkProfesor = table.Column<int>(type: "int", nullable: true),
                    FkSemestre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Dia);
                    table.ForeignKey(
                        name: "FK_Horarios_Aulas_FkAula",
                        column: x => x.FkAula,
                        principalTable: "Aulas",
                        principalColumn: "PkCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horarios_Grupos_FkGrupo",
                        column: x => x.FkGrupo,
                        principalTable: "Grupos",
                        principalColumn: "PkGrupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horarios_Materias_FkMateria",
                        column: x => x.FkMateria,
                        principalTable: "Materias",
                        principalColumn: "PkMateria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horarios_Profesores_FkProfesor",
                        column: x => x.FkProfesor,
                        principalTable: "Profesores",
                        principalColumn: "PkProfe",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horarios_Semestres_FkSemestre",
                        column: x => x.FkSemestre,
                        principalTable: "Semestres",
                        principalColumn: "PkSemestre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[,]
                {
                    { 1, "Aspirante" },
                    { 2, "Estudiante" },
                    { 3, "Profesor" },
                    { 4, "Coordinador" },
                    { 5, "Encargado" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PkUser", "ApellidoM", "ApellidoP", "CURP", "Calle", "Correo", "FkRoles", "Lt", "Mz", "Nombre", "Password", "SuperMz", "Telefono" },
                values: new object[] { 1, null, null, "JICA991026HTCMSL04", null, "alfredo@gmail.com", 1, null, null, null, "123", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Aspirantes_FkUser",
                table: "Aspirantes",
                column: "FkUser");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_FkRol",
                table: "Empleados",
                column: "FkRol");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_FkUsuario",
                table: "Empleados",
                column: "FkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_FCarreraPkCarrera",
                table: "Estudiantes",
                column: "FCarreraPkCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_FkGrupo",
                table: "Estudiantes",
                column: "FkGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_FkUser",
                table: "Estudiantes",
                column: "FkUser");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_FkCarrera",
                table: "Grupos",
                column: "FkCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_FkTurno",
                table: "Grupos",
                column: "FkTurno");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_FkAula",
                table: "Horarios",
                column: "FkAula");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_FkGrupo",
                table: "Horarios",
                column: "FkGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_FkMateria",
                table: "Horarios",
                column: "FkMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_FkProfesor",
                table: "Horarios",
                column: "FkProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_FkSemestre",
                table: "Horarios",
                column: "FkSemestre");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_FkUser",
                table: "Profesores",
                column: "FkUser");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRoles",
                table: "Usuarios",
                column: "FkRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aspirantes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Semestres");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
