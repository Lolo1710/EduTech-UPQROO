using Login_Pape.Context;
using Login_Pape.Entities;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_Pape.Services
{
    public class AspiranteServices
    {
        public void AddAspirante(Aspirante request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Aspirante res = new Aspirante();
                        res.Matricula = request.Matricula;
                        res.Carrera = request.Carrera;
                        res.CurpPDF = request.CurpPDF;
                        res.ActaPDF = request.ActaPDF;
                        res.CertificadoPDF = request.CertificadoPDF;
                        res.FkUser = request.FkUser;

                        _context.Aspirantes.Add(res);
                        _context.SaveChanges();
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
    }
}
