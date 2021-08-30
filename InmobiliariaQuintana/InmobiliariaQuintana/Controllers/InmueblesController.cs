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
    public class InmueblesController : Controller
    {
        protected readonly IConfiguration configuration;
        RepositorioInmueble repositorio;
        RepositorioPropietario repoPropietario;
        public InmueblesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorio = new RepositorioInmueble(configuration);
            repoPropietario = new RepositorioPropietario(configuration);
        }
        // GET: InmueblesController
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            if (TempData.ContainsKey("Id"))
                ViewBag.Id = TempData["Id"];
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            return View(lista);
        }

        // GET: InmueblesController/Details/5
        public ActionResult Details(int id)
        {
            var inmueble = repositorio.ObtenerPorId(id);
            return View(inmueble);
        }

        // GET: InmueblesController/Create
        public ActionResult Create()
        {
            ViewBag.Propietarios = repoPropietario.ObtenerTodos();
            return View();
        }

        // POST: InmueblesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Alta(entidad);
                    TempData["IdInmueble"] = entidad.IdInmueble;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Propietarios = repoPropietario.ObtenerTodos();
                    return View(entidad);
                }
            }
            catch(Exception e)
            {

                return View();
            }
        }

        // GET: InmueblesController/Edit/5
        public ActionResult Edit(int id)
        {
            var inmueble = repositorio.ObtenerPorId(id);
            ViewBag.Propietarios = repoPropietario.ObtenerTodos();
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(inmueble);
        }

        // POST: InmueblesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble inmueble)
        {
            try
            {
                inmueble.IdInmueble = id;
                repositorio.Modificacion(inmueble);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Propietarios = repoPropietario.ObtenerTodos();
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                
                return View(inmueble);
            }
        }

        // GET: InmueblesController/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
            
        }

        // POST: InmueblesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble entidad)
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
