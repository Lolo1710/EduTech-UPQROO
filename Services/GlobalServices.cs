using Login_Pape.Context;
using Login_Pape.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_Pape.Services
{
    public class GlobalServices
    {
        
        public List<Usuario> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = _context.Usuarios.Include(x => x.Roles).ToList();

                    if (usuarios.Count > 0)
                    {

                        return usuarios;

                    }

                    return usuarios;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public List<Roles> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Roles> roles = _context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario res = new Usuario();
                        res.Correo = request.Correo;
                        res.CURP = request.CURP;
                        res.Password = request.Password;
                        res.FkRoles = request.FkRoles;

                        _context.Usuarios.Add(res);
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
