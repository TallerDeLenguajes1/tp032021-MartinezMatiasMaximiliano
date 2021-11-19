﻿using AutoMapper;
using Cadeteria.Entities;
using Cadeteria.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IDataBase DB;
        private readonly IMapper mapper;

        public LoginController(IDataBase _DB, IMapper mapper)
        {
            this.DB = _DB;
            this.mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario Usuario)
        {
            try
            {

                if (DB.RepositorioUsuarios.ValidarUsuario(Usuario))
                {
                    Usuario SesionLogueada = DB.RepositorioUsuarios.GetUsuario(Usuario);
                    CrearSesion(SesionLogueada);

                    switch ((Rol)GetRol())
                    {
                        case Rol.Admin:
                            return View("../Admin/AdminPage");
                        case Rol.Cadete:
                            Cadete Cadete = DB.RepositorioCadete.GetCadeteByID(GetIdUsuario());
                            return View("../Cadete/InfoCadete", new CadeteInfoViewModel(DB.RepositorioCadete.GetCadeteByID(GetIdUsuario()),DB.RepositorioPedido.GetAllPedidosDeCadete(Cadete.Id))); ;
                        case Rol.Cliente:
                            return View("../Cliente/InfoCliente", DB.RepositorioCliente.GetClienteByID(Usuario.ID));
                        default:
                            return View();
                    }
                }
                else
                {
                    return View(nameof(Login));
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

        public IActionResult AltaUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaUsuario(UsuarioAltaViewModel usuarioVM)
        {
            try
            {
                Usuario nuevo = mapper.Map<UsuarioAltaViewModel, Usuario>(usuarioVM);

                switch (nuevo.Rol)
                {
                    case Rol.Cadete:
                        if (DB.RepositorioUsuarios.SaveUsuario(nuevo))
                        {
                            Cadete cadete = mapper.Map<UsuarioAltaViewModel, Cadete>(usuarioVM);
                            cadete.UsuarioID = DB.RepositorioUsuarios.GetIDUsuario(nuevo);
                            DB.RepositorioCadete.SaveCadete(cadete);
                        }
                        break;
                    case Rol.Cliente:
                    default:
                        break;
                }

                return View(nameof(Login));
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

        public IActionResult Desconectar()
        {
            CerrarSesion();
            return View(nameof(Login));
        }

        
        public IActionResult BajaUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

        public IActionResult BajaUsuario(Usuario Usuario)
        {
            try
            {
                DB.RepositorioUsuarios.DesactivarUsuario(Usuario.ID);
                return View(nameof(Login));
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(nameof(Login));
            }
        }

    }
}
