using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Controllers
{
    [Authorize]
    public class InquilinosController : Controller
    {
        protected readonly IConfiguration configuration;
        RepositorioInquilinos repositorio;
        public InquilinosController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorio = new RepositorioInquilinos(configuration);
        }

        // GET: InquilinosController
        public ActionResult Index()
        {
            ViewBag.Roles = Usuario.ObtenerRoles();
            ViewBag.error = TempData["error"];
            var lista = repositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: InquilinosController/Details/5
        public ActionResult Details(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
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
                TempData["error"] = ex.Message;
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
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: InquilinosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Inquilinos inqui)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
