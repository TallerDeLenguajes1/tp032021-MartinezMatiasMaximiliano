using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCadeteria.Entities;

namespace WebCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly Cadeteria cadeteria;

        public CadeteController(Cadeteria _cadeteria)
        {
            cadeteria = _cadeteria;
        }

        public IActionResult AltaCadetes(string _Nombre, string _Direccion, string _Telefono)
        {
            if (_Nombre == null || _Direccion == null || _Telefono == null)
            {
                return View();
            }
            else
            {
                CargarCadete(_Nombre,_Direccion,_Telefono);
                return View("../Home/Index",cadeteria);
            }
        }

        public IActionResult AltaPedidos(string _NombreClie, string _DireccionClie, string _TelefonoClie, string _Obs, int _Estado)
        {
            if (_NombreClie == null || _DireccionClie == null || _TelefonoClie == null)
            {
                return View(cadeteria);
            }
            else
            {
                CargarPedido(_NombreClie, _DireccionClie, _TelefonoClie, _Obs, _Estado);
                return View("../Home/ListaPedidos", cadeteria);
            }
        }
        
        public void CargarPedido(string _NombreClie, string _DireccionClie, string _TelefonoClie, string _Obs, int _Estado)
        {
            Pedido nuevoPedido = new Pedido(_NombreClie, _DireccionClie, _TelefonoClie, _Obs, _Estado);
            cadeteria.ListaPedidos.Add(nuevoPedido);
        }

        public void CargarCadete(string _Nombre, string _Direccion, string _Telefono)
        {
            Cadete nuevoCadete = new Cadete(_Nombre, _Direccion, _Telefono);
            cadeteria.ListaCadetes.Add(nuevoCadete);
        }



    }
}
