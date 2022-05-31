using InmobiliariaQuintana.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly DataContext applicationDbContext;
        private readonly IConfiguration configuration;

        public ContratoController(DataContext applicationDbContext, IConfiguration configuration)
        {
            this.applicationDbContext = applicationDbContext;
            this.configuration = configuration;
        }

        //Contrato de un inmueble
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContratoXInmueble(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return await applicationDbContext.Contratos.Include(x => x.inquilino).Include(x => x.inmueble).Where(x =>
                     x.InmuebleId == id &&
                     x.FechaHasta > DateTime.Now && x.FechaDesde < DateTime.Now)
                    .FirstOrDefaultAsync();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

            }
        }
    }
}
