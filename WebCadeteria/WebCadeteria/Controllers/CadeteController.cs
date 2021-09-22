using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCadeteria.Entities;
using WebCadeteria.Helpers;

namespace WebCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly Cadeteria cadeteria;

        public CadeteController(Cadeteria _cadeteria)
        {
            cadeteria = _cadeteria;
        }

        public IActionResult AltaCadete(string _Nombre, string _Direccion, string _Telefono)
        {
            if (_Nombre == null || _Direccion == null || _Telefono == null)
            {
                return View(cadeteria);
            }
            else
            {
                Cadete nuevoCadete = new Cadete(_Nombre, _Direccion, _Telefono);
                cadeteria.ListaCadetes.Add(nuevoCadete);
                return View("../Home/Index",cadeteria);
            }
        }

        public IActionResult BajaCadete(int _IdCadete)
        {
            cadeteria.ListaCadetes.Remove(cadeteria.ListaCadetes.Find(x => x.Id == _IdCadete));
            return View("../Home/Index", cadeteria);
        }

        public IActionResult ModCadete()
        {

            return View("../Home/Index", cadeteria);
        }
    }
}
