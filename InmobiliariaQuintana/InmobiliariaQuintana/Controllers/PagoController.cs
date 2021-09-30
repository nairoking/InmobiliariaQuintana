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
    public class PagoController : Controller
    {
        protected readonly IConfiguration configuration;
        RepositorioInmueble repoInmueble;
        RepositorioContrato repoContrato;
        RepositorioInquilinos repoInquilino;
        RepositorioPropietario repoPropietario;
        RepositorioPago repoPago;

        public PagoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repoContrato = new RepositorioContrato(configuration);
            repoInmueble = new RepositorioInmueble(configuration);
            repoInquilino = new RepositorioInquilinos(configuration);
            repoPropietario = new RepositorioPropietario(configuration);
            repoPago = new RepositorioPago(configuration);
        }
        // GET: PagoController
        public ActionResult Index()
        {
            ViewBag.Roles = Usuario.ObtenerRoles();
            var lista = repoPago.ObtenerTodos();
            return View(lista);
        }
        public ActionResult PagosPorContrato(int id)
        {
            ViewBag.Roles = Usuario.ObtenerRoles();
            if (id != 0)
            {
                ViewBag.idContratoR = id;
                var con = repoContrato.ObtenerPorId(id);
                ViewBag.contrato = con;
                var list = repoPago.ObtenerTodosPorId(id);

                return View(list);
            }
            else
            {
                TempData["error"] = "El pago que esta buscando no se encuentra";
                return RedirectToAction("Index", "Contrato");
            }
        }

        // GET: PagoController/Details/5
        public ActionResult Details(int id)
        {
            var entidad = repoPago.ObtenerPorId(id);
            return View(entidad);
          
        }

        // GET: PagoController/Create
        public ActionResult Create(int id)
        {
            ViewBag.Contratos = repoContrato.ObtenerTodos();
            ViewBag.contrato = id;

            return View();
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago pago)
        {
            try
            {
                ViewBag.contrato = pago.ContratoId;
                int id = pago.Id;
                
             
                
                
                repoPago.Alta(pago);
                return RedirectToAction(nameof(Index), new { id});
            }
            catch
            {
                return View();
            }
        }

        // GET: PagoController/Edit/5
        public ActionResult Edit(int id)
        {
            var pago = repoPago.ObtenerPorId(id);
            return View(pago);
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pago p)
        {
            try
            {
                int idCont = p.ContratoId;
                repoPago.Modificacion(p);
                return RedirectToAction(nameof(Index), new {idCont });
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: PagoController/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var entidad = repoPago.ObtenerPorId(id);
            return View(entidad);
           
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Pago p)
        {
            try
            {
                repoPago.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
