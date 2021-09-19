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
        private readonly ILogger<HomeController> _logger;
        private readonly Cadeteria cadeteria;

        public HomeController(ILogger<HomeController> logger,Cadeteria _cadeteria)
        {
            _logger = logger;
            cadeteria = _cadeteria;
        }

        //lista de cadetes
        public IActionResult Index()
        {
            return View(cadeteria);
        }

        public IActionResult ListaPedidos()
        {
            return View(cadeteria);
        }

        //submit de ListaPedidos
        public IActionResult AsignarCadete(int _IdPedido, int _IdCadete)
        {
            if (_IdCadete == -1)
            {
                foreach (var cadete in cadeteria.ListaCadetes)
                {
                    cadete.ListaPedidos.Remove(cadeteria.ListaPedidos.Find(x => x.Nro == _IdPedido));
                }
                return View("ListaPedidos", cadeteria);
            }
            else{
                foreach (var cadete in cadeteria.ListaCadetes)
                {
                    if (cadete.Id == _IdCadete)
                    {
                        cadete.ListaPedidos.Add(cadeteria.ListaPedidos.Find(x => x.Nro == _IdPedido));
                    }
                }
                return View("ListaPedidos", cadeteria);
            }

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
