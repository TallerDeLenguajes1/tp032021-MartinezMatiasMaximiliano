using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebCadeteria.Entities;
using WebCadeteria.Helpers;

namespace WebCadeteria.Controllers
{
    public class CadeteController : Controller
    {

        private readonly DBTemporal DB;

        public CadeteController(DBTemporal dB)
        {
            DB = dB;
        }

        public IActionResult AltaCadete(string _Nombre, string _Direccion, string _Telefono)
        {
            if (_Nombre == null || _Direccion == null || _Telefono == null)
            {
                return View(DB.MiCadeteria);
            }
            else
            {
                Cadete nuevoCadete = new Cadete(_Nombre, _Direccion, _Telefono);
                DB.MiCadeteria.ListaCadetes.Add(nuevoCadete);
                HelperModules.WriteFile(JsonSerializer.Serialize(DB.MiCadeteria.ListaCadetes), DB.pathCadetes);
                return View("../Home/Index", DB.MiCadeteria);
            }
        }

        public IActionResult BajaCadete(int _IdCadete)
        {
            DB.MiCadeteria.ListaCadetes.Remove(DB.MiCadeteria.ListaCadetes.Find(x => x.Id == _IdCadete));
            HelperModules.WriteFile(JsonSerializer.Serialize(DB.MiCadeteria.ListaCadetes), DB.pathCadetes);
            return View("../Home/Index", DB.MiCadeteria);
        }

        public IActionResult SelectCadete(int _IdCadete)
        {
            return View("ModificarCadete",DB.MiCadeteria.ListaCadetes.Find(x => x.Id == _IdCadete));
        }


        public IActionResult ModificarCadete(int _IdCadete, string _Nombre, string _Direccion, string _Telefono)
        {
            Cadete aux = DB.MiCadeteria.ListaCadetes.Find(x => x.Id == _IdCadete);
            aux.Nombre = _Nombre;
            aux.Direccion = _Direccion;
            aux.Telefono = _Telefono;
            HelperModules.WriteFile(JsonSerializer.Serialize(DB.MiCadeteria.ListaCadetes), DB.pathCadetes);
            return View("../Home/Index", DB.MiCadeteria);
        }
    }
}

