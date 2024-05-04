using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JefePrestamistaController : ControllerBase
    {
        private readonly IJefePrestamistaRepository jefePrestamistaRepository;
        public JefePrestamistaController(IJefePrestamistaRepository jefePrestamistaRepository)
        {
            this.jefePrestamistaRepository = jefePrestamistaRepository;
        }

        [HttpGet("getJefePrestamistaByCreatorUser")]
        public async Task<ActionResult<IEnumerable<JefePrestamista>>> GetJefePrestamistaByCreatorUser(string creatorUser)
        {
            return StatusCode(StatusCodes.Status200OK, await jefePrestamistaRepository.GetJefePrestamistaByCreatorUser(creatorUser));
        }

        [HttpGet]
        [Route("GetJefePrestamista")]
        public async Task<ActionResult<IEnumerable<JefePrestamista>>> GetJefePrestamista()
        {
            return StatusCode(StatusCodes.Status200OK, await jefePrestamistaRepository.GetJefePrestamista());
        }

        [HttpPost]
        [Route("CrearJefePrestamista")]
        public async Task<ActionResult<JefePrestamista>> CreateJefePrestamista(JefePrestamista jefePrestamista)
        {
            jefePrestamista.Estado = "Activo";
            return StatusCode(StatusCodes.Status201Created, await jefePrestamistaRepository.CreateJefePrestamista(jefePrestamista));

        }

        [HttpPut]
        [Route("ActualizarJefePrestamista")]
        public async Task<ActionResult<JefePrestamista>> UpdateJefePrestamista(JefePrestamista jefePrestamista)
        {
            return StatusCode(StatusCodes.Status200OK, await jefePrestamistaRepository.UpdateJefePrestamista(jefePrestamista));
        }

        [HttpDelete]
        [Route("EliminarJefePrestamista")]
        public async Task<ActionResult<bool>> DeleteJefePrestamista(int idJefePrestamista)
        {
            return StatusCode(StatusCodes.Status200OK, await jefePrestamistaRepository.DeleteJefePrestamista(idJefePrestamista));
        }

    }
}
