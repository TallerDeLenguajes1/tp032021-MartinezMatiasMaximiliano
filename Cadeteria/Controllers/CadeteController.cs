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
                if (true) //CORREGIR rol admin
                {
                    return View(DB.RepositorioCadete.GetAllCadetes());
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
                if (true) //CORREGIR rol admin
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
        public IActionResult AltaCadete(Cadete Cadete)
        {
            try
            {
                if (true) //CORREGIR rol admin
                {
                DB.RepositorioCadete.SaveCadete(Cadete);
                return RedirectToAction(nameof(ListaCadetes));
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
                if (true) //CORREGIR rol admin
                {
                  
                DB.RepositorioCadete.DesactivarCadete(ID);
                return RedirectToAction(nameof(ListaCadetes));
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
                if (true) //CORREGIR rol admin
                {
                    return View("../Cadete/ModCadete",DB.RepositorioCadete.GetCadeteByID(ID));
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
        public IActionResult ModificarCadete(Cadete Cadete)
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
