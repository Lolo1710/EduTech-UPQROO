using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Login_Pape.Entities
{
    public class Estudiante
    {
        [Key]
        public int PkEstudent { get; set; }
        public string Carrera { get; set; }
        public byte[] Foto { get; set; }
        public byte[] ActaPDF { get; set; }
        public byte[] CertificadoPDF { get; set; }
        public byte[] CurpPDF { get; set; }
        public string Nss { get; set; }
        public string Matricula { get; set; }
        public string ContactoE { get; set; }
        public string Correo { get; set; }
        public int Creditos { get; set; }
        public string Situacion { get; set; }
        public string Generacion { get; set; }

        [ForeignKey("Usuario")]
        public int? FkUser { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Carrera")]
        public int? FkCarrera { get; set; }
        public Carrera FCarrera { get; set; }

        [ForeignKey("Grupo")]
        public int? FkGrupo { get; set; }
        public Grupos Grupo { get; set; }
    }
}
