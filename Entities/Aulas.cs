using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Login_Pape.Entities
{
    public class Aulas
    {
        [Key]
        public int PkCarrera { get; set; }
        public string Nombre { get; set; }
        public double Capacidad { get; set; }
    }
}
