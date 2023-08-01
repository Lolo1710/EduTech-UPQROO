using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Login_Pape.Entities
{
    public class Profesor
    {
        [Key]
        public int PkProfe { get; set; }
        public string Jornada { get; set; }
        public TimeSpan InicioJ { get; set; }
        public TimeSpan FinJ { get; set; }
        public string Correo { get; set; }

        [ForeignKey("Usuario")]
        public int? FkUser { get; set; }
        public Usuario Usuario { get; set; }
    }
}
