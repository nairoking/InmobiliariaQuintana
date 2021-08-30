using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Controllers
{
    public class PropietariosController : Controller
    {
        protected readonly IConfiguration configuration;
        RepositorioPropietario repositorio;

        public PropietariosController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorio = new RepositorioPropietario(configuration);

        }
        // GET: PropietariosController
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: PropietariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PropietariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropietariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario p)
        {
            try
            {
                repositorio.Alta(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PropietariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var propi = repositorio.ObtenerPorId(id);
            return View(propi);
        }

        // POST: PropietariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Propietario propi)
        {
            try
            {
                propi.IdPropietario = id;
                repositorio.Modificacion(propi);
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(propi);
            }
        }

        // GET: PropietariosController/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: PropietariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Propietario p)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
