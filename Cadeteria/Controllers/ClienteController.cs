using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Entities;

namespace Cadeteria.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IDB DB;

        public ClienteController(IDB _DB)
        {
            DB = _DB;
        }

        public IActionResult ListaClientes()
        {
            return View(DB.RepositorioCliente.GetAllClientes());
        }

        public IActionResult AltaCliente()
        {
            return View(nameof(AltaCliente));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CargarCliente(Cliente Cliente)
        {
            try
            {
                DB.RepositorioCliente.SaveCliente(Cliente);
                return RedirectToAction(nameof(ListaClientes));
            }
            catch
            {
                return RedirectToAction(nameof(ListaClientes));
            }
        }

        public IActionResult BajaCliente(int id)
        {
            try
            {
                DB.RepositorioCliente.DesactivarCliente(id);
                return RedirectToAction(nameof(ListaClientes));
            }
            catch
            {
                return RedirectToAction(nameof(ListaClientes));
            }
        }

        public IActionResult ModificarCliente(int id)
        {
            return View("../Cliente/ModCliente", DB.RepositorioCliente.GetClienteByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarCliente(Cliente Cliente)
        {
            try
            {
                DB.RepositorioCliente.ModificarCliente(Cliente);
                return RedirectToAction(nameof(ListaClientes));
            }
            catch (Exception e)
            {
                string error = e.Message;
                return RedirectToAction(nameof(ListaClientes));
            }
        }
    }
}
