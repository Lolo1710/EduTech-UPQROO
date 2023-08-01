using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Login_Pape.Entities
{
    public class Horarios
    {
        [Key]
        public DateTime Dia { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }

        //grupo
        [ForeignKey("Grupo")]
        public int? FkGrupo { get; set; }
        public Grupos Grupo { get; set; }

        //aula
        [ForeignKey("Aula")]
        public int? FkAula { get; set; }
        public Aulas Aula { get; set; }

        //materia
        [ForeignKey("Materia")]
        public int? FkMateria { get; set; }
        public Materias Materia { get; set; }

        //profesor
        [ForeignKey("Profesor")]
        public int? FkProfesor{ get; set; }
        public Profesor Profesor { get; set; }

        //semestre
        [ForeignKey("Semestre")]
        public int? FkSemestre { get; set; }
        public Semestre Semestre { get; set; }
    }
}
