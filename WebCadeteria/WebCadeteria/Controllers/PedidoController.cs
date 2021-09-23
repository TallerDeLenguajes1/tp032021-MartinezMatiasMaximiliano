using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCadeteria.Entities;

namespace WebCadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Cadeteria cadeteria;

        public PedidoController(Cadeteria _cadeteria)
        {
            cadeteria = _cadeteria;
        }

        public IActionResult ListaPedidos()
        {
            return View(cadeteria);
        }

        public IActionResult AltaPedido(string _NombreClie, string _DireccionClie, string _TelefonoClie, string _Obs, int _Estado)
        {
            if (_NombreClie == null || _DireccionClie == null || _TelefonoClie == null)
            {
                return View(cadeteria);
            }
            else
            {
                Pedido nuevoPedido = new(_NombreClie, _DireccionClie, _TelefonoClie, _Obs, _Estado);
                cadeteria.ListaPedidos.Add(nuevoPedido);
                return View("../Pedido/ListaPedidos", cadeteria);
            }
        }

        public IActionResult BajaPedido(int _IdPedido)
        {
            cadeteria.ListaPedidos.Remove(cadeteria.ListaPedidos.Find(x => x.Nro == _IdPedido));
            return View("../Pedido/ListaPedidos", cadeteria);
        }


        public IActionResult AsignarCadete(int _IdPedido, int _IdCadete)
        {
            if (_IdCadete != -1)
            {
                cadeteria.ListaCadetes.Find(x => x.Id == _IdCadete).ListaPedidos.Add(cadeteria.ListaPedidos.Find(a => a.Nro == _IdPedido));
                return View("ListaPedidos", cadeteria);

            }
            else
            {
                cadeteria.ListaCadetes.Find(x => x.Id == _IdCadete).ListaPedidos.Remove(cadeteria.ListaPedidos.Find(a => a.Nro == _IdPedido));
                return View("ListaPedidos", cadeteria);
            }
        }

    }
}
