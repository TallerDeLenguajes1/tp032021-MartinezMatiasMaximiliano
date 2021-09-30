using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebCadeteria.Entities;
using WebCadeteria.Helpers;

namespace WebCadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly DBTemporal DB;

        public PedidoController(DBTemporal dB)
        {
            DB = dB;
        }

        public IActionResult ListaPedidos()
        {
            return View(DB.MiCadeteria);
        }

        public IActionResult AltaPedido(string _NombreClie, string _DireccionClie, string _TelefonoClie, string _Obs, int _Estado)
        {
            if (_NombreClie == null || _DireccionClie == null || _TelefonoClie == null)
            {
                return View(DB.MiCadeteria);
            }
            else
            {
                Pedido nuevoPedido = new(_NombreClie, _DireccionClie, _TelefonoClie, _Obs, _Estado);
                DB.MiCadeteria.ListaPedidos.Add(nuevoPedido);
                HelperModules.WriteFile(JsonSerializer.Serialize(DB.MiCadeteria.ListaPedidos), DB.pathPedidos);
                return View("../Pedido/ListaPedidos", DB.MiCadeteria);
            }
        }

        public IActionResult BajaPedido(int _IdPedido)
        {
            DB.MiCadeteria.ListaPedidos.Remove(DB.MiCadeteria.ListaPedidos.Find(x => x.Nro == _IdPedido));
            return View("../Pedido/ListaPedidos", DB.MiCadeteria);
        }


        public IActionResult AsignarCadete(int _IdPedido, int _IdCadete)
        {
            if (_IdCadete == -1)
            {
                DB.MiCadeteria.ListaCadetes.Find(x => x.Id == _IdCadete).ListaPedidos.Remove(DB.MiCadeteria.ListaPedidos.Find(a => a.Nro == _IdPedido));
                return View("ListaPedidos", DB.MiCadeteria);
            }
            else
            {
                DB.MiCadeteria.ListaCadetes.Find(x => x.Id == _IdCadete).ListaPedidos.Add(DB.MiCadeteria.ListaPedidos.Find(a => a.Nro == _IdPedido));
                return View("ListaPedidos", DB.MiCadeteria);
            }
        }

    }
}
