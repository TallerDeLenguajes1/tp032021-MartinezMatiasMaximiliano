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
        private readonly IDataBase DB;

        public ClienteController(IDataBase _DB)
        {
            DB = _DB;
        }

        public IActionResult ListaClientes()
        {
            try
            {
                if (true) //CORREGIR rol admin
                {
                    return View(DB.RepositorioCliente.GetAllClientes());
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View("../Login/Login");
            }
        }

        public IActionResult AltaCliente()
        {
            try
            {
                if (true) //CORREGIR rol admin y cadete
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View("../Login/Login");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaCliente(Cliente Cliente)
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
