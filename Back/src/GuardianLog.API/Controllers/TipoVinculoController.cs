using AutoMapper;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVinculoController() : ControllerBase
    {

        [HttpGet]
        public IActionResult getTiposVinculo()
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
