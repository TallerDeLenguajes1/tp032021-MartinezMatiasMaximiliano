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
        private readonly IDB DB;
        public LoginController(IDB _DB)
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

            HttpContext.Session.SetString("Usuario", Username);
            HttpContext.Session.SetString("Contra", Password);

            string Usu = HttpContext.Session.GetString("Usuario");
            string Pass = HttpContext.Session.GetString("Contra");
            if (Usu == "Admin" && Pass == "Admin")
            {
                return View("../Cadete/ListaCadetes", DB.RepositorioCadete.GetAllCadetes());
            }
            else
            {
                return View("Error");
            }
        }
    }
}
