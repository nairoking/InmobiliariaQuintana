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
    public class ContratoController : Controller
    {
        protected readonly IConfiguration configuration;
        RepositorioInmueble repoInmueble;
        RepositorioContrato repoContrato;
        RepositorioInquilinos repoInquilino;
        RepositorioPropietario repoPropietario;

        public ContratoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repoContrato = new RepositorioContrato(configuration);
            repoInmueble = new RepositorioInmueble(configuration);
            repoInquilino = new RepositorioInquilinos(configuration);
            repoPropietario = new RepositorioPropietario(configuration);
        }
        // GET: ContratoController
        public ActionResult Index()
        {
            var lista = repoContrato.ObtenerTodos();
            return View(lista);
        }

        // GET: Propietario/Buscar/5
        [Route("[controller]/Buscar", Name = "Buscar")]
        public IActionResult Buscar(BusquedaInmuebles busInm)
        {
            try
            {
                var lista = repoInmueble.obtenerInmuebles(busInm.Desde, busInm.Hasta, busInm.Id);
                return Json(new { lista });
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }
        // GET: ContratoController/Details/5
        public ActionResult Details(int id)
        {
            var entidad = repoContrato.ObtenerPorId(id);
            return View(entidad);
        }

        // GET: ContratoController/Create
        public ActionResult Create()
        {
            ViewBag.Propietarios = repoPropietario.ObtenerTodos();
            ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
            ViewBag.Contratos = repoContrato.ObtenerTodos();
            ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
            return View();
        }

        // POST: ContratoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repoContrato.Alta(entidad);
                    TempData["IdContrato"] = entidad.IdContrato;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Propietarios = repoPropietario.ObtenerTodos();
                    ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
                    ViewBag.Contratos = repoContrato.ObtenerTodos();
                    ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
                    return View(entidad);
                }
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: ContratoController/Edit/5
        public ActionResult Edit(int id)
        {
            var contrato = repoContrato.ObtenerPorId(id);
            ViewBag.Propietarios = repoPropietario.ObtenerTodos();
            ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
            ViewBag.Contratos = repoContrato.ObtenerTodos();
            ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
            return View(contrato);
        }

        // POST: ContratoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrato entidad)
        {
            try
            {
                entidad.IdContrato = id;
                repoContrato.Mofificar(entidad);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Propietarios = repoPropietario.ObtenerTodos();
                ViewBag.Inquilinos = repoInquilino.ObtenerTodos();
                ViewBag.Contratos = repoContrato.ObtenerTodos();
                ViewBag.Inmuebles = repoInmueble.ObtenerTodos();
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;

                return View(entidad);
            }
        }

        // GET: ContratoController/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var entidad = repoContrato.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: ContratoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Contrato entidad)
        {
            try
            {
                repoContrato.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
