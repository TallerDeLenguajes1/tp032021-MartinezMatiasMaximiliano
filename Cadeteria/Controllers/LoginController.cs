using Cadeteria.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDataBase DB;

        public LoginController(IDataBase _DB)
        {
            this.DB = _DB;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            try
            {
                Usuario Usuario = DB.RepositorioUsuarios.ValidarUsuario(Username, Password);
                if (Usuario != null)
                {
                    switch (Usuario.Rol)
                    {
                        case Rol.Admin:
                            HttpContext.Session.SetString("Username", Usuario.Username);
                            HttpContext.Session.SetString("Password", Usuario.Password);

                            return View("../Admin/AdminPage");
                        case Rol.Cadete:
                            HttpContext.Session.SetString("Username", Usuario.Username);
                            HttpContext.Session.SetString("Password", Usuario.Password);

                            return View("../Cadete/InfoCadete", DB.RepositorioCadete.GetCadeteByID(Usuario.ID)); ;
                        case Rol.Cliente:
                            HttpContext.Session.SetString("Username", Usuario.Username);
                            HttpContext.Session.SetString("Password", Usuario.Password);

                            return View("../Cliente/InfoCliente", DB.RepositorioCliente.GetClienteByID(Usuario.ID));
                        default:
                            return View();
                    }
                }
                else
                {
                    return View(nameof(Login));
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

        public IActionResult AltaUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaUsuario(Usuario Usuario)
        {
            try
            {
                DB.RepositorioUsuarios.SaveUsuario(Usuario);
                return View(nameof(Login));
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }
        
        public IActionResult BajaUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

        public IActionResult BajaUsuario(Usuario Usuario)
        {
            try
            {
                DB.RepositorioUsuarios.DesactivarUsuario(Usuario.ID);
                return View(nameof(Login));
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

    }
}
