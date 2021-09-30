using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        protected readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;
        RepositorioUsuario repositorio;

        public UsuarioController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            ViewBag.Roles = Usuario.ObtenerRoles();
            this.configuration = configuration;
            this.environment = environment;
            repositorio = new RepositorioUsuario(configuration);

        }
       [Authorize(Policy = "Administrador")]
        public ActionResult Index()
        {
            var usuarios = repositorio.ObtenerTodos();
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        [Authorize(Policy = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.Roles = Usuario.ObtenerRoles();
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Create(Usuario u)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                
                u.Rol = User.IsInRole("Administrador") ? u.Rol : (int)enRoles.Empleado;
                var nbreRnd = Guid.NewGuid();//posible nombre aleatorio
                int res = repositorio.Alta(u);
                if (u.AvatarFile != null && u.Id > 0)
                {
                    string wwwPath = environment.WebRootPath;
                    string path = Path.Combine(wwwPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //Path.GetFileName(u.AvatarFile.FileName);//este nombre se puede repetir
                    string fileName = "avatar_" + u.Id + Path.GetExtension(u.AvatarFile.FileName);
                    string pathCompleto = Path.Combine(path, fileName);
                    u.Avatar = Path.Combine("/Uploads", fileName);
                    // Esta operación guarda la foto en memoria en el ruta que necesitamos
                    using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                    {
                        u.AvatarFile.CopyTo(stream);
                    }
                    repositorio.Modificacion(u);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Roles = Usuario.ObtenerRoles();
                return View();
            }
        }


        // GET: UsuarioController/Edit/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id)
        {
            ViewBag.Roles = Usuario.ObtenerRoles();
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id, Usuario u)
        {
            try
            {
                Usuario usuViejo = repositorio.ObtenerPorId(u.Id);

                if (u.Clave == null)
                {
                    u.Clave = usuViejo.Clave;
                }
               
                if (u.AvatarFile != null && u.Id > 0)
                {
                    string wwwPath = environment.WebRootPath;
                    if (usuViejo.Avatar != @"/Uploads\usuario.png")
                    {
                        string urlAvatar = usuViejo.Avatar.Substring(1);
                        System.IO.File.Delete(Path.Combine(wwwPath, urlAvatar));
                    }

                    string path = Path.Combine(wwwPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //Path.GetFileName(u.AvatarFile.FileName);//este nombre se puede repetir
                    string fileName = "avatar_" + u.Id + Path.GetExtension(u.AvatarFile.FileName);
                    string pathCompleto = Path.Combine(path, fileName);
                    u.Avatar = Path.Combine("/Uploads", fileName);
                    using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                    {
                        u.AvatarFile.CopyTo(stream);
                    }
                    repositorio.Modificacion(u);
                }
                else
                {
                    u.Avatar = usuViejo.Avatar;
                    repositorio.Modificacion(u);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    

        // GET: UsuarioController/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var entidad = repositorio.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Usuario u)
        {
            try
            {
                repositorio.Baja(u.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginView login)
        {
            try
            {
                /*string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                         password: login.Clave,
                         salt: System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]),
                         prf: KeyDerivationPrf.HMACSHA1,
                         iterationCount: 1000,
                         numBytesRequested: 256 / 8));*/

                var e = repositorio.ObtenerPorEmail(login.Usuario);
                if (e == null)
                {

                    TempData["error"] = "El email o la clave no son correctos";
                    return RedirectToAction(nameof(Index));
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, e.Email),
                        new Claim("FullName", e.Nombre + " " + e.Apellido),
                        new Claim("fotoUrl", e.Avatar),
                        new Claim(ClaimTypes.Role, e.RolNombre),
                    };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));


                if (TempData["url"] != null)
                {
                    return Redirect(TempData["url"].ToString());
                }
                else
                {
                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
