using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Login_Pape.Entities
{
    public class Turnos
    {
        [Key]
        public int PkTurnos { get; set; }
        public string Nombre { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
    }
}
