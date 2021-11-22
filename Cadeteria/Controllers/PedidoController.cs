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
    public class PedidoController : BaseController
    {
        private readonly IDataBase DB;
        private readonly IMapper mapper;

        public PedidoController(IDataBase _DB, IMapper _mapper)
        {
            DB = _DB;
            mapper = _mapper;
        }

        public IActionResult ListaPedidos()
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2)
                {
                    ListaPedidosViewModel ListaPedidosVM = new();
                    DB.RepositorioPedido.GetAllPedidos().ForEach(a => ListaPedidosVM.listaPedidos.Add(mapper.Map<Pedido, PedidoViewModel>(a)));
                    return View(ListaPedidosVM);
                }
                else
                {
                    return View("../Login/Login");
                }
            }
            catch (Exception)
            {
                return View("../Login/Login");

            }
        }

        public IActionResult AltaPedido(int ClienteID)
        {
            try
            {
                NuevoPedidoViewModel AltaVM = new();
                DB.RepositorioCadete.GetAllCadetes().ForEach(a => AltaVM.listaCadetes.Add(mapper.Map<Cadete, CadeteViewModel>(a)));
                AltaVM.ClienteID = ClienteID;
                return View(AltaVM);
            }
            catch (Exception)
            {

                return View("../Login/Login");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaPedido(NuevoPedidoViewModel NuevoPedidoVM)
        {
            try
            {
                Pedido Pedido = mapper.Map<PedidoViewModel, Pedido>(NuevoPedidoVM.PedidoVM);


                DB.RepositorioPedido.SavePedido(Pedido, NuevoPedidoVM.CadeteID, NuevoPedidoVM.ClienteID);
                return RedirectToAction(nameof(ListaPedidos));
            }
            catch
            {
                return RedirectToAction(nameof(ListaPedidos));
            }
        }


        public IActionResult BajaPedido(int ID)
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2 || GetRol() == 1)
                {
                    DB.RepositorioPedido.DesactivarPedido(ID);
                    return RedirectToAction(nameof(ListaPedidos));
                }
                else
                {
                    return View("../Login/Login");
                }
            }
            catch
            {
                return View("../Login/Login");
            }
        }

        public IActionResult ModificarPedido(int ID,int ClienteID) //cliente y admin
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2 || GetRol() == 0)
                {
                    PedidoViewModel PedidoVM = mapper.Map<Pedido, PedidoViewModel>(DB.RepositorioPedido.GetPedidoByID(ID));
                    PedidoVM.ClientePedido = mapper.Map<Cliente,ClienteViewModel>(DB.RepositorioCliente.GetClienteByID(ClienteID));
                    return View("../Pedido/ModPedido", PedidoVM);
                }
                else
                {
                    return View("../Login/Login");
                }
            }
            catch
            {
                return View("../Login/Login");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarPedido(PedidoViewModel PedidoVM) //cliente y admin
        {
            try
            {
                Pedido Pedido = mapper.Map<PedidoViewModel, Pedido>(PedidoVM);
                DB.RepositorioPedido.EditPedido(Pedido);
                return View("../Login/Login");
            }
            catch (Exception)
            {
                return View("../Login/Login");
            }
        }

        //public IActionResult SearchPedidos(string NombreCliente)
        //{
        //    return View("../Pedido/ListaPedidos", DB.RepositorioPedido.GetAllPedidos(NombreCliente));

        //    try
        //    {
        //        if (IsSesionIniciada() && GetRol() == 2)
        //        { }
        //        else
        //        {
        //            return View("../Login/Login");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return View("../Login/Login");

        //    }

        //}

    }

}

