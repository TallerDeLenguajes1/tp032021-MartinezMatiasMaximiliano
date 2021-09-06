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
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AltaCadetes(string _Nombre,string _Direccion, string _Telefono)
        {
            if (_Nombre == null || _Direccion == null || _Telefono == null)
            {
                return View();
            }
            else
            {
                Cadete nuevoCadete = new Cadete(_Nombre,_Direccion,_Telefono);
                //singleton aqui
                return View();
            }
        }

        public IActionResult AltaPedidos(string _NombreClie,string _DireccionClie, string _TelefonoClie,string _Obs,Pedido.EnumEstado _Estado,Cadete _Cadete)
        {
            if (_NombreClie == null || _DireccionClie == null || _TelefonoClie == null)
            {
                return View();
            }
            else
            {
                Pedido nuevoPedido = new Pedido(_Obs,_Estado, _NombreClie, _DireccionClie, _TelefonoClie);
                _Cadete.AgregarPedido(nuevoPedido);
                return View();
            }
            
            
        }




        public void CargarCadete(string _Nombre, string _Direccion, string _Telefono)
        {
           Cadete nuevoCadete = new Cadete(_Nombre,_Direccion,_Telefono);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
