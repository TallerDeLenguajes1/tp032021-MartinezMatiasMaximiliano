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
    public class PedidoController : BaseController
    {
        private readonly IDataBase DB;

        public PedidoController(IDataBase _DB)
        {
            DB = _DB;
        }

        public IActionResult ListaPedidos() //solo admin
        {
            return View(DB.RepositorioPedido.GetAllPedidos());
        }

        public IActionResult AltaPedido() //todos
        {
            return View(new AltaPedidoViewModel(DB.RepositorioCadete.GetAllCadetes(),DB.RepositorioCliente.GetAllClientes()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaPedido(Pedido Pedido,int CadeteID, int ClienteID) //todos
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

        
        public IActionResult BajaPedido(int ID)//cliente y admin
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

        public IActionResult ModificarPedido(int ID) //cliente y admin
        {
            return View("../Pedido/ModPedido", DB.RepositorioPedido.GetPedidoByID(ID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPedido(Pedido Pedido) //cliente y admin
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
