using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Entities;
using Cadeteria.ViewModels;
using AutoMapper;

namespace Cadeteria.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IDataBase DB;
        private readonly IMapper mapper;

        public ClienteController(IDataBase _DB,IMapper _mapper)
        {
            DB = _DB;
            mapper = _mapper;
        }

        public IActionResult ListaClientes() //solo admin
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2) //CORREGIR rol admin
                {
                    return View(DB.RepositorioCliente.GetAllClientes());
                }else{
                    return View("../Login/Login");
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
                if (true) //CORREGIR rol?
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
        public IActionResult AltaCliente(Cliente Cliente) //rol?
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

        public IActionResult BajaCliente(int id) //solo admin
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

        public IActionResult EditarCliente(int ID) //admin y cliente
        {
            Cliente cliente = DB.RepositorioCliente.GetClienteByID(ID);
            ClienteViewModel ClienteVM = mapper.Map<Cliente,ClienteViewModel>(cliente);
            return View("../Cliente/ModCliente", clienteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarCliente(Cliente Cliente) //admin y cliente
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
