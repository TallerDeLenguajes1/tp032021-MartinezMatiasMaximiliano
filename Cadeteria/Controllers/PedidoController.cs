using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Entities;
using Cadeteria.ViewModels;

namespace Cadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IDataBase DB;

        public PedidoController(IDataBase _DB)
        {
            DB = _DB;
        }

        public IActionResult ListaPedidos()
        {
            return View(DB.RepositorioPedido.GetAllPedidos());
        }

        public IActionResult AltaPedido()
        {
            return View(new AltaPedidoViewModel(DB.RepositorioCadete.GetAllCadetes(),DB.RepositorioCliente.GetAllClientes()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaPedido(Pedido Pedido,int CadeteID, int ClienteID)
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
                return Redirect("../Login/Login");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return RedirectToAction(nameof(ListaPedidos));
            }
        }

        public IActionResult SearchPedidos(string NombreCliente){
            return View("../Pedido/ListaPedidos",DB.RepositorioPedido.GetAllPedidos(NombreCliente));
        }

    }
}
