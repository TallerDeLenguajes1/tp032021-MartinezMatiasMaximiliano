using Cadeteria.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
    public class BaseController : Controller
    {
        public void CrearSesion(Usuario Usuario)
        {
            if (!IsSesionIniciada())
            {
                if (Usuario != null)
                {
                    HttpContext.Session.SetString("Username", Usuario.Username);
                    HttpContext.Session.SetString("Password", Usuario.Password);
                    HttpContext.Session.SetInt32("UserID", Usuario.ID);
                    HttpContext.Session.SetInt32("Rol", (int)Usuario.Rol);
                }
            }
        }

        public bool IsSesionIniciada()
        {
            return (HttpContext.Session.GetString("Username") != null);
        }

        public int GetRol()
        {
            int rol = 0;
            if (IsSesionIniciada())
            {
                rol = (int)HttpContext.Session.GetInt32("Rol");
            }
            else
            {
                rol = -1;
            }
            return rol;
        }
        
        public string GetUser()
        {
            return HttpContext.Session.GetString("Username");
        }
        
        public string GetPass()
        {
            return HttpContext.Session.GetString("Password");
        }
        
        public int GetIdUsuario()
        {
            return (int)HttpContext.Session.GetInt32("UserID");
        }
        
        public void CerrarSesion()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Password");
            HttpContext.Session.Remove("Rol");
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Clear();
        }
    }
}
