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
    public class InmueblesController : Controller
    {
        protected readonly IConfiguration configuration;
        RepositorioInmueble repositorio;
        RepositorioPropietario repoPropietario;
        RepositorioContrato repoContrato;
        public InmueblesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorio = new RepositorioInmueble(configuration);
            repoPropietario = new RepositorioPropietario(configuration);
            repoContrato = new RepositorioContrato(configuration);
        }
        // GET: InmueblesController
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            ViewBag.Propietarios = repoPropietario.ObtenerTodos();
            ViewBag.error = TempData["error"];
            return View(lista);
        }
        // GET: InmueblesController
        public ActionResult Disponibles()
        {
            var lista = repositorio.ObtenerTodos();
            var aux = new List<Inmueble>();
            foreach(var i in lista)
            {
                if (i.Estado == "si")
                    aux.Add(i);
            }
            ViewBag.Propietarios = repoPropietario.ObtenerTodos();
            ViewBag.error = TempData["error"];
            return View(aux);
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
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
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
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
            
        }

        // POST: InmueblesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
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

        // GET: InmueblesController/Create
        public ActionResult Contratos(int id)
        {
            ViewBag.Propietarios = repoPropietario.ObtenerTodos();
            ViewBag.Inmuebles = repositorio.ObtenerTodos();
            var lista = repoContrato.ObtenerPorInmueble(id);
            return View(lista);
        }

      
    }
}
