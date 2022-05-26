﻿using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InmobiliariaQuintana.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PropietariosController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public PropietariosController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<Propietario>> Get()
        {
            try
            {
                /*contexto.Inmuebles
                    .Include(x => x.Duenio)
                    .Where(x => x.Duenio.Nombre == "")//.ToList() => lista de inmuebles
                    .Select(x => x.Duenio)
                    .ToList();//lista de propietarios*/
                var usuario = User.Identity.Name;
                /*contexto.Contratos.Include(x => x.Inquilino).Include(x => x.Inmueble).ThenInclude(x => x.Duenio)
                    .Where(c => c.Inmueble.Duenio.Email....);*/
                /*var res = contexto.Propietarios.Select(x => new { x.Nombre, x.Apellido, x.Email })
                    .SingleOrDefault(x => x.Email == usuario);*/
                return await contexto.Propietarios.SingleOrDefaultAsync(x => x.Email == usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entidad = await contexto.Propietarios.SingleOrDefaultAsync(x => x.IdPropietario == id);
                return entidad != null ? Ok(entidad) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
		[HttpGet("obtenerusuario")]
		public async Task<ActionResult<Propietario>> ObtenerUsuario()
		{
			try
			{

				var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

				return await contexto.Propietarios.FirstOrDefaultAsync(x => x.Email == email);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/<controller>/GetAll
		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				return Ok(await contexto.Propietarios.ToListAsync());
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST api/<controller>/login
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] LoginView loginView)
		{
			try
			{
				/*string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: loginView.Clave,
					salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
					prf: KeyDerivationPrf.HMACSHA1,
					iterationCount: 1000,
					numBytesRequested: 256 / 8));*/
				string hashed = loginView.Clave;
				var p = await contexto.Propietarios.FirstOrDefaultAsync(x => x.Email == loginView.Usuario);
				if (p == null || p.Clave != hashed)
				{
					return BadRequest("Nombre de usuario o clave incorrecta");
				}
				else
				{
					var key = new SymmetricSecurityKey(
						System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
					var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name,p.Email),
						new Claim("FullName", p.Nombre + " " + p.Apellido),
						new Claim(ClaimTypes.Role, "Propietario"),
					};

					var token = new JwtSecurityToken(
						issuer: config["TokenAuthentication:Issuer"],
						audience: config["TokenAuthentication:Audience"],
						claims: claims,
						expires: DateTime.Now.AddMinutes(60),
						signingCredentials: credenciales
					);
					return Ok(new JwtSecurityTokenHandler().WriteToken(token));
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST api/<controller>
		[HttpPost]
		public async Task<IActionResult> Post([FromForm] Propietario entidad)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await contexto.Propietarios.AddAsync(entidad);
					contexto.SaveChanges();
					return CreatedAtAction(nameof(Get), new { id = entidad.IdPropietario }, entidad);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT api/<controller>/5
		[HttpPut("actualizar")]
		public async Task<IActionResult> Put([FromBody] Propietario prop)
		{
			try
			{
				var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
				Propietario original = await contexto.Propietarios.FirstOrDefaultAsync(x => x.Email == email);

				if (prop.IdPropietario != original.IdPropietario)
				{
					return Unauthorized();
				}


				/*if (prop.Clave == null || prop.Clave == "")
				{
					prop.Clave = propietarioV.Clave;
				}
				else
				{
					string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					   password: prop.Clave,
					   salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
					   prf: KeyDerivationPrf.HMACSHA1,
					   iterationCount: 1000,
					   numBytesRequested: 256 / 8));
					prop.Clave = hashed;

				}*/
				contexto.Entry(original).CurrentValues.SetValues(prop);
				//contexto.Propietarios.Update(prop);
				await contexto.SaveChangesAsync();

				return (IActionResult)await contexto.Propietarios.FirstOrDefaultAsync(x => x.Email == email);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var p = contexto.Propietarios.Find(id);
					if (p == null)
						return NotFound();
					contexto.Propietarios.Remove(p);
					contexto.SaveChanges();
					return Ok(p);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/Propietarios/test
		[HttpGet("test")]
		[AllowAnonymous]
		public IActionResult Test()
		{
			try
			{
				return Ok("anduvo");
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/Propietarios/test/5
		[HttpGet("test/{codigo}")]
		[AllowAnonymous]
		public IActionResult Code(int codigo)
		{
			try
			{
				//StatusCodes.Status418ImATeapot //constantes con códigos
				return StatusCode(codigo, new { Mensaje = "Anduvo", Error = false });
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
