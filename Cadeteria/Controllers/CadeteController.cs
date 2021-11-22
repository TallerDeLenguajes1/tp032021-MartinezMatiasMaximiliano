using Cadeteria.Entities;
using Cadeteria.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Cadeteria.Controllers
{
    public class CadeteController : BaseController
    {
        private readonly IDataBase DB;
        private readonly IMapper mapper;

        public CadeteController(IDataBase _DB, IMapper _mapper)
        {
            DB = _DB;
            mapper = _mapper;

        }

        public IActionResult ListaCadetes() //listo
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2)
                {
                    ListaCadetesViewModel listaCadetesVM = new();
                    DB.RepositorioCadete.GetAllCadetes().ForEach(a => listaCadetesVM.listaCadetes.Add(mapper.Map<Cadete, CadeteViewModel>(a)));
                    return View(listaCadetesVM);
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

        //reemplazado por alta usuario

        //public IActionResult AltaCadete()
        //{
        //    try
        //    {
        //        if (IsSesionIniciada() && GetRol() == 2) //admin y cadete
        //        {
        //            return View();
        //        }else{
        //            return View("../Login/Login");
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
        //public IActionResult AltaCadete(Cadete Cadete)
        //{
        //    try
        //    {
        //        if (IsSesionIniciada() && GetRol() == 2) // admin y cadete
        //        {
        //        DB.RepositorioCadete.SaveCadete(Cadete);
        //        return RedirectToAction(nameof(ListaCadetes));
        //        }else{
        //            return View("../Login/Login");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        string error = e.Message;
        //        return View("../Login/Login");
        //    }
        //}

        public IActionResult BajaCadete(int ID) // listo
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2)
                {

                    DB.RepositorioCadete.DesactivarCadete(ID);
                    return RedirectToAction(nameof(ListaCadetes));
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

        public IActionResult ModificarCadete(int ID) //listo
        {
            try
            {
                if (IsSesionIniciada() && GetRol() == 2)
                {
                    CadeteViewModel CadeteVM = mapper.Map<Cadete, CadeteViewModel>(DB.RepositorioCadete.GetCadeteByID(ID));
                    return View("../Cadete/ModCadete", CadeteVM);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarCadete(CadeteViewModel CadeteVM) //listo 
        {
            try
            {
                Cadete Cadete = mapper.Map<CadeteViewModel, Cadete>(CadeteVM);

                if (IsSesionIniciada() && GetRol() == 2)
                {
                    DB.RepositorioCadete.EditarCadete(Cadete);
                    return RedirectToAction(nameof(ListaCadetes));
                }
                else
                {
                    return View("../Login/Login");
                }


            }
            catch (Exception)
            {
                return RedirectToAction(nameof(ListaCadetes));
            }
        }
    }
}
