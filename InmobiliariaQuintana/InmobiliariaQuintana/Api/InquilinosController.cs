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
using System.Security.Claims;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinosController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public InquilinosController(DataContext applicationDbContext, IConfiguration configuration)
        {
            this.contexto = applicationDbContext;
            this.config = configuration;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquilinos>> Get(int id)
        {

            try
            {

                var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

                if (id == 0)
                {
                    return BadRequest();
                }


                return await contexto.Inquilinos.Join(
                    contexto.Contratos.Where(x => x.InmuebleId == id),
                    inq => inq.IdInquilino,
                    com => com.InquilinoId,
                    (inq, com) => inq).FirstOrDefaultAsync();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

            }




        }

    }
}
