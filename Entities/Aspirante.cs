using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Login_Pape.Entities
{
    public class Aspirante
    {
        [Key]
        public int PkAspirante { get; set; }
        public string Matricula { get; set; }
        public string Carrera { get; set; }
        public byte[] ActaPDF { get; set; }
        public byte[] CertificadoPDF { get; set; }
        public byte[] CurpPDF { get; set; }

        [ForeignKey("Usuario")]
        public int? FkUser { get; set; }
        public Usuario Usuario { get; set; }
    }
}
