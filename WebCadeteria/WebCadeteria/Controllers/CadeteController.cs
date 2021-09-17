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
                return View();
            }
        }

        public IActionResult AltaPedidos(string _NombreClie, string _DireccionClie, string _TelefonoClie, string _Obs, EnumEstado _Estado, int _IdCadete)
        {
            if (_NombreClie == null || _DireccionClie == null || _TelefonoClie == null)
            {
                return View(cadeteria.ListaCadetes);
            }
            else
            {
                Pedido nuevoPedido = new Pedido(_Obs, _Estado, _NombreClie, _DireccionClie, _TelefonoClie);

                foreach (var item in cadeteria.ListaCadetes)
                {
                    if (item.Id == _IdCadete){item.AgregarPedido(nuevoPedido);}
                }

                return View(cadeteria.ListaCadetes);
            }
        }

        public void CargarCadete(string _Nombre, string _Direccion, string _Telefono)
        {
            Cadete nuevoCadete = new Cadete(_Nombre, _Direccion, _Telefono);
            cadeteria.ListaCadetes.Add(nuevoCadete);
        }

    }
}
