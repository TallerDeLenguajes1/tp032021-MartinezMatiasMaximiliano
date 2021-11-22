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

        public ClienteController(IDataBase _DB, IMapper _mapper)
        {
            DB = _DB;
            mapper = _mapper;
        }

        public IActionResult ListaClientes()
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2)
                {
                    ListaClientesViewModel listaClientesVM = new();
                    DB.RepositorioCliente.GetAllClientes().ForEach(a => listaClientesVM.listaClientes.Add(mapper.Map<Cliente, ClienteViewModel>(a)));
                    return View(listaClientesVM);
                }
                else
                {
                    return View("../Login/Login");
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View("../Login/Login");
            }
        }

        //reemplazado por altausuario

        //public IActionResult AltaCliente() 
        //{
        //    try
        //    {
        //        if (true) //CORREGIR rol?
        //        {
        //            return View();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        string error = e.Message;
        //        return View("../Login/Login");
        //    }

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AltaCliente(Cliente Cliente) //rol?
        //{
        //    try
        //    {
        //        DB.RepositorioCliente.SaveCliente(Cliente);
        //        return RedirectToAction(nameof(ListaClientes));
        //    }
        //    catch
        //    {
        //        return RedirectToAction(nameof(ListaClientes));
        //    }
        //}

        public IActionResult BajaCliente(int ID) //listo
        {
            try
            {

                if (IsSesionIniciada() && GetRol() == 2)
                {
                    DB.RepositorioCliente.DesactivarCliente(ID);
                    return RedirectToAction(nameof(ListaClientes));
                }
                else
                {
                    return View("../Login/Login");
                }
                
            }
            catch
            {
                return RedirectToAction(nameof(ListaClientes));
            }
        }

        public IActionResult EditarCliente(int ID)
        {
            try
            {
                if (IsSesionIniciada() && (GetRol() == 2 || GetRol() == 0))
                {
                    ClienteViewModel ClienteVM = mapper.Map<Cliente, ClienteViewModel>(DB.RepositorioCliente.GetClienteByID(ID));
                    return View("../Cliente/ModCliente", ClienteVM);
                }
                else
                {
                    return View("../Login/Login");
                }
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(ListaClientes));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarCliente(ClienteViewModel ClienteVM) 
        {
            try
            {
                if (IsSesionIniciada() && (GetRol() == 2 || GetRol() == 0))
                {
                    Cliente Cliente = mapper.Map<ClienteViewModel, Cliente>(ClienteVM);
                    DB.RepositorioCliente.ModificarCliente(Cliente);
                    return RedirectToAction(nameof(ListaClientes));
                }
                else
                {
                    return View("../Login/Login");
                }
                
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(ListaClientes));
            }
        }
    }
}
