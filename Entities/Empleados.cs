using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Login_Pape.Entities
{
    public class Empleados
    {
        [Key]
        public int PkEmpleado { get; set; }
        public string Jornada { get; set; }
        public TimeSpan InicioJ { get; set; }
        public TimeSpan FinJ { get; set; }
        public string Correo { get; set; }

        [ForeignKey("Roles")]
        public int? FkRol { get; set; }
        public Roles Roles { get; set; }

        [ForeignKey("Datos")]
        public int? FkUsuario { get; set; }
        public Usuario Datos { get; set; }
    }
}
