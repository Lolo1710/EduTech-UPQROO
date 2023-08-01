using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Login_Pape.Entities
{
    public class Grupos
    {
        [Key]
        public int? PkGrupo { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Carrera")]
        public int? FkCarrera { get; set; }
        public Carrera Carrera { get; set; }

        [ForeignKey("Turno")]
        public int? FkTurno { get; set; }
        public Turnos Turno { get; set; }
    }
}
