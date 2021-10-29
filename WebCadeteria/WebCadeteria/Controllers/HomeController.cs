using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebCadeteria.Models;
using WebCadeteria.Entities;
using WebCadeteria.Helpers;

namespace WebCadeteria.Controllers
{
    public class HomeController : Controller
    {

        private readonly DBTemporal DB;
        private readonly RepositorioCadete Repo;
        public HomeController(DBTemporal dB,RepositorioCadete repoCadetes)
        {
            DB = dB;
            Repo = repoCadetes;
        }

        public IActionResult Index()
        {
            return View(Repo.getAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
