using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Login_Pape.Entities
{
    public class Materias
    {
        [Key]
        public int? PkMateria { get; set; }
        public string Nombre { get; set; }
    }
}
