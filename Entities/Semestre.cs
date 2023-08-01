using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Login_Pape.Entities
{
    public class Semestre
    {
        [Key]
        public int PkSemestre { get; set; }
        public int Semestres { get; set; }
    }
}
