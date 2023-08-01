using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Login_Pape.Entities
{
    public class Roles
    {
        [Key]
        public int PkRol { get; set; }
        public string Nombre { get; set; }
    }
}
