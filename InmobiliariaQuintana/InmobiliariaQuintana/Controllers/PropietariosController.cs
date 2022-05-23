using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
    public class PropietariosController : Controller
    {
        protected readonly IConfiguration configuration;
        RepositorioPropietario repositorio;
        RepositorioInmueble repoInmueble;

        public PropietariosController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorio = new RepositorioPropietario(configuration);
            repoInmueble = new RepositorioInmueble(configuration);

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
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        // GET: PropietariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropietariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario propietario)
        {

            try
            {
                if (ModelState.IsValid)// Pregunta si el modelo es válido
                {
                    // Reemplazo de clave plana por clave con hash
                    propietario.Clave = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: propietario.Clave,
                        salt: System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]),
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 1000,
                        numBytesRequested: 256 / 8));
                    repositorio.Alta(propietario);
                    TempData["Id"] = propietario.IdPropietario;
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(propietario);
            }
            catch (Exception ex)
            {//poner breakpoints para detectar errores
                throw;
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
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: PropietariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
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
        public ActionResult VerInmuebles(int id)
        {
            var prop = repositorio.ObtenerPorId(id);
            ViewBag.Nombre = prop.Nombre + " " + prop.Apellido;
            var lista = repoInmueble.BuscarPorPropietario(id);
            return View(lista);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerInmuebles(int id, Propietario p)
        {
            try
            {
                var lista = repoInmueble.BuscarPorPropietario(id);
               return View(lista);

            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
        }
    }
}
