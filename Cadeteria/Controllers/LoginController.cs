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
            if (DB.RepositorioUsuarios.UsuarioExiste(Username,Password))
            {
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Password", Password);

                string User = HttpContext.Session.GetString("Username");
                string Pass = HttpContext.Session.GetString("Password");

                return View("../Cadete/ListaCadetes", DB.RepositorioCadete.GetAllCadetes());
            }
            else
            {
                //usuario no existe
                return View();
            }

        }
    }
}
