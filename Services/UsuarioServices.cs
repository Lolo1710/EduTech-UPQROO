using Login_Pape.Context;
using Login_Pape.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login_Pape.Services
{
    class UsuarioServices
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario res = new Usuario();
                        res = _context.Usuarios.Find(request.PkUser);
                        res.Nombre = request.Nombre;
                        res.ApellidoM = request.ApellidoM;
                        res.ApellidoP = request.ApellidoP;
                        res.SuperMz = request.SuperMz;
                        res.Mz = request.Mz;
                        res.Lt = request.Lt;
                        res.Calle = request.Calle;
                        res.Telefono = request.Telefono;

                        _context.Entry(res).State = EntityState.Modified;
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
