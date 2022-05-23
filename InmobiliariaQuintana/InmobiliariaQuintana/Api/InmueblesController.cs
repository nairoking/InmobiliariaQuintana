using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InmobiliariaQuintana.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly DataContext applicationDbContext;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IWebHostEnvironment environment;

        public InmueblesController(DataContext applicationDbContext, IConfiguration configuration, IHttpContextAccessor contextAccessor, IWebHostEnvironment environment)
        {
            this.applicationDbContext = applicationDbContext;
            this.configuration = configuration;
            this.contextAccessor = contextAccessor;
            this.environment = environment;
        }
        [HttpGet("obtener")]
        public async Task<ActionResult<List<Inmueble>>> Get()
        {

            try
            {

                var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

                var propietario = await applicationDbContext.Propietarios.FirstOrDefaultAsync(x => x.Email == email);

                var inmuebles = await applicationDbContext.Inmuebles.Where(x => x.PropietarioId == propietario.IdPropietario).ToListAsync();


                return inmuebles;


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

            }




        }
        [HttpGet("contrato")]
        public async Task<ActionResult<List<Inmueble>>> GetAlquilados()
        {

            try
            {

                var email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var propietario = await applicationDbContext.Propietarios.FirstOrDefaultAsync(x => x.Email == email);
                var inmuebles = await applicationDbContext.Inmuebles.Join(
                    applicationDbContext.Contratos.Where(x => x.FechaHasta > DateTime.Now && x.FechaDesde < DateTime.Now),
                    inm => inm.IdInmueble,
                    com => com.InmuebleId,
                    (inm, com) => inm)
                    .Where(x => x.PropietarioId == propietario.IdPropietario).ToListAsync();

                return inmuebles;


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

            }
        }
        [HttpPut("{id}")]//Cambiar Estado
        public async Task<ActionResult<Inmueble>> Put([FromForm] byte estado, int id)
        {

            try
            {

                var email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var propietario = await applicationDbContext.Propietarios.FirstOrDefaultAsync(x => x.Email == email);
                Inmueble inmuebleV = await applicationDbContext.Inmuebles.FirstOrDefaultAsync(x => x.IdInmueble == id && x.PropietarioId == propietario.IdPropietario);
                if (inmuebleV == null)
                {
                    return NotFound();
                }

                inmuebleV.Estado = estado + "";
                applicationDbContext.Update(inmuebleV);
                await applicationDbContext.SaveChangesAsync();
                return inmuebleV;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        /*[HttpPost("crear")]
        public async Task<ActionResult<Inmueble>> Post([FromBody] Inmueble inmueble)
        {

            try
            {

                var email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var propietario = await applicationDbContext.Propietarios.FirstOrDefaultAsync(x => x.Email == email);
                inmueble.PropietarioId = propietario.IdPropietario;
                if (inmueble.ImagenGuardar != null)
                {
                    var stream1 = new MemoryStream(Convert.FromBase64String(inmueble.ImagenGuardar));
                    IFormFile ImagenInmo = new FormFile(stream1, 0, stream1.Length, "inmueble", ".jpg");
                    string wwwPath = environment.WebRootPath;
                    string path = Path.Combine(wwwPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    Random r = new Random();
                    //Path.GetFileName(u.AvatarFile.FileName);//este nombre se puede repetir
                    string fileName = "inmueble_" + inmueble.PropietarioId + r.Next(0, 100000) + Path.GetExtension(ImagenInmo.FileName);
                    string pathCompleto = Path.Combine(path, fileName);

                    inmueble.Imagen = Path.Combine("Uploads", fileName);
                    using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                    {
                        ImagenInmo.CopyTo(stream);
                    }
                    applicationDbContext.Add(inmueble);
                    await applicationDbContext.SaveChangesAsync();
                    return inmueble;
                }
                else
                {

                    return BadRequest("debe incluir una imagen ");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }*/
    }
}
