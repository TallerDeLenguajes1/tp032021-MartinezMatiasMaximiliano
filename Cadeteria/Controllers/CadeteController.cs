using Cadeteria.Entities;
using Cadeteria.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
    public class CadeteController : BaseController
    {
        private readonly IDataBase DB;

        public CadeteController(IDataBase _DB)
        {
            DB = _DB;
        }

        public IActionResult ListaCadetes()
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2) //solo admin
                {
                    return View(new ListaCadetesViewModel(DB.RepositorioCadete.GetAllCadetes()));
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

        public IActionResult AltaCadete()
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2) //admin y cadete
                {
                    return View();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaCadete(Cadete Cadete)
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2) // admin y cadete
                {
                DB.RepositorioCadete.SaveCadete(Cadete);
                return RedirectToAction(nameof(ListaCadetes));
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

        public IActionResult BajaCadete(int ID)
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2) //solo admin
                {
                  
                DB.RepositorioCadete.DesactivarCadete(ID);
                return RedirectToAction(nameof(ListaCadetes));
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

        public IActionResult ModificarCadete(int ID)
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2) //solo admin
                {
                    return View("../Cadete/ModCadete",DB.RepositorioCadete.GetCadeteByID(ID));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarCadete(Cadete Cadete) //solo admin
        {
            try
            {
                DB.RepositorioCadete.EditarCadete(Cadete);
                return RedirectToAction(nameof(ListaCadetes));
            }
            catch (Exception e)
            {
                string error = e.Message;
                return RedirectToAction(nameof(ListaCadetes));
            }
        }
    }
}
