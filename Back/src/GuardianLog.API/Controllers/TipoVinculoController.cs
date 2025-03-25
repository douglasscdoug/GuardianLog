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
                var tiposVinculo = Enum.GetValues(typeof(TipoVinculo));
                var tipoVinculoList = new List<TipoVinculoDto>();

                foreach (var tipo in tiposVinculo)
                {
                    if (Enum.IsDefined(typeof(TipoVinculo), tipo))
                    {
#pragma warning disable CS8601 // Possible null reference assignment.
                        tipoVinculoList.Add(new TipoVinculoDto
                        {
                            Id = (int)tipo,
                            Nome = tipo.ToString()
                        });
#pragma warning restore CS8601 // Possible null reference assignment.
                    }
                }

                return Ok(tipoVinculoList);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
