using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Login_Pape.Entities
{
    public class Usuario
    {
        [Key]
        public int PkUser { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoP { get; set; }
        public string? ApellidoM { get; set; }
        public string? SuperMz { get; set; }
        public string? Mz { get; set; }
        public string? Lt { get; set; }
        public string? Calle { get; set; }
        public string? Telefono { get; set; }
        public string Correo { get; set; }
        public string CURP { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]
        public int? FkRoles { get; set; }
        public Roles Roles { get; set; }
    }
}
