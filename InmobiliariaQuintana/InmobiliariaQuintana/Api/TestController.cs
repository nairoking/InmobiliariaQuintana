﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InmobiliariaQuintana.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria_.Net_Core.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly DataContext Contexto;

		public TestController(DataContext dataContext)
		{
			this.Contexto = dataContext;
		}
		// GET: api/<controller>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				return Ok(new
				{
					Mensaje = "Éxito",
					Error = 0,
					Resultado = new
					{
						Clave = "Key",
						Valor = new Random().Next(0, 10000)
					},
				});
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(Contexto.Propietarios.Find(id));
		}

		// GET api/<controller>/5
		[HttpGet("usuarios/{id=0}")]
		public IActionResult GetUsers(int id)
		{
			return Ok(Contexto.Usuarios.ToList());
		}

		// GET api/<controller>/5
		[HttpGet("emails/{id=0}")]
		public IActionResult Emails(int id)
		{
			if(id > 0)
				return Ok(Contexto.Propietarios.Where(x => x.IdPropietario == id).Select(x => x.Email).Single());
			else
				return Ok(Contexto.Propietarios.Select(x => x.Email).ToList());
		}

		// GET api/<controller>/5
		[HttpGet("anonimo/{id}")]
		public IActionResult GetAnonimo(int id)
		{
			return id > 0 ?
				Ok(Contexto.Propietarios.Where(x => x.IdPropietario == id)
				.Select(x => new { Id = x.IdPropietario, x.Email }).Single()) :
				Ok(Contexto.Propietarios.Select(x => new { Id = x.IdPropietario, x.Email }).ToList());
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromForm] string value, IFormFile file)
		{

		}

		// POST api/<controller>/usuario/5
		[HttpPost("usuario/{id}")]
		public Usuario Post([FromForm] Usuario usuario, int id)
		{
			usuario.Id = id;
			return usuario;
		}

		// POST api/<controller>/usuario/5
		[HttpPost("login")]
		public async Task<IActionResult> Post([FromForm] LoginView login)
		{
			return Ok(login);
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		

		
	}
}
