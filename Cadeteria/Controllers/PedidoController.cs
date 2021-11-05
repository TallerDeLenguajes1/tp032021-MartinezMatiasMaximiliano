using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Entities;

namespace Cadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IDB DB;

        public PedidoController(IDB _DB)
        {
            DB = _DB;
        }

        public IActionResult ListaPedidos()
        {
            return View(DB.RepositorioPedido.GetAllPedidos());
        }

        public IActionResult AltaPedido()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CargarPedido(Pedido Pedido,int CadeteID, int ClienteID)
        {
            try
            {
                DB.RepositorioPedido.SavePedido(Pedido,CadeteID,ClienteID);
                return RedirectToAction(nameof(ListaPedidos));
            }
            catch
            {
                return RedirectToAction(nameof(ListaPedidos));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BajaPedido(int ID)
        {
            try
            {
                DB.RepositorioPedido.DesactivarPedido(ID);
                return RedirectToAction(nameof(ListaPedidos));
            }
            catch
            {
                return RedirectToAction(nameof(ListaPedidos));
            }
        }

        public IActionResult ModificarPedido(int ID)
        {
            return View("../Pedido/ModPedido", DB.RepositorioPedido.GetPedidoByID(ID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPedido(Pedido Pedido)
        {
            try
            {
                DB.RepositorioPedido.ModificarPedido(Pedido);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                string error = e.Message;
                return RedirectToAction(nameof(ListaPedidos));
            }
        }
    }
}
