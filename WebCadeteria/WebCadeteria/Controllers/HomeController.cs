using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebCadeteria.Models;
using WebCadeteria.Entities;

namespace WebCadeteria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Cadeteria cadeteria;

        public HomeController(ILogger<HomeController> logger,Cadeteria _cadeteria)
        {
            _logger = logger;
            cadeteria = _cadeteria;
        }

        public IActionResult Index()
        {
            return View(cadeteria.ListaCadetes);
        }

        public IActionResult ListaPedidos()
        {
            return View(cadeteria.ListaPedidos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
