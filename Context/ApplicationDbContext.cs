using Login_Pape.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login_Pape.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("Server=localhost; database=EduTech; user=root; pass=;");
        }

        public DbSet<Aspirante> Aspirantes { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData
                (
                    new Roles
                    {
                        PkRol = 1,
                        Nombre = "Aspirante"
                    },
                    new Roles
                    {
                        PkRol = 2,
                        Nombre = "Estudiante"
                    },
                    new Roles
                    {
                        PkRol = 3,
                        Nombre = "Profesor"
                    },
                    new Roles
                    {
                        PkRol = 4,
                        Nombre = "Coordinador"
                    },
                    new Roles
                    {
                        PkRol = 5,
                        Nombre = "Encargado"
                    }
                );
            modelBuilder.Entity<Usuario>().HasData
            (
                new Usuario
                {
                    PkUser = 1,
                    Correo = "alfredo@gmail.com",
                    CURP = "JICA991026HTCMSL04",
                    Password = "123",
                    FkRoles = 1,
                }
            );
        }
    }
}
