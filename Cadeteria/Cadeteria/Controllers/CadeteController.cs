using Cadeteria.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly IDB DB;

        public CadeteController(IDB _DB)
        {
            DB = _DB;
        }

        public IActionResult ListaCadetes()
        {
            return View(DB.RepositorioCadete.GetAllCadetes());
        }
                
        public IActionResult AltaCadete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CargarCadete(Cadete Cadete)
        {
            try
            {
                DB.RepositorioCadete.SaveCadete(Cadete);
                return RedirectToAction(nameof(ListaCadetes));
            }
            catch(Exception e)
            {
                string error = e.Message;
                return RedirectToAction(nameof(ListaCadetes));
            }
        }

        public IActionResult BajaCadete(int id)
        {
            try
            {
                DB.RepositorioCadete.DesactivarCadete(id);
                return RedirectToAction(nameof(ListaCadetes));
            }
            catch
            {
                return RedirectToAction(nameof(ListaCadetes));
            }
        }

        public IActionResult ModificarCadete(int id)
        {
            return View("../Cadete/ModCadete",DB.RepositorioCadete.GetCadeteById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarCadete(Cadete Cadete)
        {
            try
            {
                DB.RepositorioCadete.EditarCadete(Cadete);
                return RedirectToAction(nameof(ListaCadetes));
            }
            catch(Exception e)
            {
                string error = e.Message;
                return RedirectToAction(nameof(ListaCadetes));
            }
        }
    }
}
