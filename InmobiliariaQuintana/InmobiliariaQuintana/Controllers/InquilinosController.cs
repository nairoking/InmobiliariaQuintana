using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Controllers
{
    public class InquilinosController : Controller
    {
        RepositorioInquilinos repositorio;
        public InquilinosController()
        {
            repositorio = new RepositorioInquilinos();
        }

        // GET: InquilinosController
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: InquilinosController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: InquilinosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InquilinosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilinos I)
        {
            try
            {
                repositorio.Alta(I);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: InquilinosController/Edit/5
        public ActionResult Edit(int id)
        {
            var inqui = repositorio.ObtenerPorId(id);
           
            
            return View(inqui);
            
        }

        // POST: InquilinosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inquilinos inqui)
        {
            try
            {
                inqui.IdInquilino = id;
                repositorio.Modificacion(inqui);
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(inqui);
            }
        }

        // GET: InquilinosController/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: InquilinosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inquilinos inqui)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
