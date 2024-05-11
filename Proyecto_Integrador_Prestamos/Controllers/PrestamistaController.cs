using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamistaController : ControllerBase
    {
        private readonly IPrestamistaRepository prestamistaRepository;
        public PrestamistaController(IPrestamistaRepository prestamistaRepository)
        {
            this.prestamistaRepository = prestamistaRepository;
        }

        [HttpGet("getPrestamistaByCreatorUser")]
        public async Task<ActionResult<IEnumerable<Prestamista>>> GetPrestamistaByCreatorUser(string creatorUser)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamistaRepository.GetPrestamistaByCreatorUser(creatorUser));
        }
        [HttpGet("getPrestamistaByIdSede")]
        public async Task<ActionResult<IEnumerable<Prestamista>>> GetPrestamistaByIdSede(int idSede)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamistaRepository.GetPrestamistaByIdSede(idSede));
        }

        [HttpGet("getPrestamistaByIdSede")]
        public async Task<ActionResult<IEnumerable<Prestamista>>> GetPrestamistaByIdSede(int idSede)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamistaRepository.GetPrestamistaByIdSede(idSede));
        }

        [HttpGet]
        [Route("GetPrestamista")]
        public async Task<ActionResult<IEnumerable<Prestamista>>> GetPrestamista()
        {
            return StatusCode(StatusCodes.Status200OK, await prestamistaRepository.GetPrestamista());
        }

        [HttpPost]
        [Route("CrearPrestamista")]
        public async Task<ActionResult<Prestatario>> CreatePrestamista(Prestamista prestamista)
        {
            prestamista.Estado = "Activo";
            return StatusCode(StatusCodes.Status201Created, await prestamistaRepository.CreatePrestamista(prestamista));

        }

        [HttpPut]
        [Route("ActualizarPrestamista")]
        public async Task<ActionResult<Prestamista>> UpdatePrestamista(Prestamista prestamista)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamistaRepository.UpdatePrestamista(prestamista));
        }

        [HttpDelete]
        [Route("EliminarPrestamista")]
        public async Task<ActionResult<bool>> DeletePrestamista(int idPrestamista)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamistaRepository.DeletePrestamista(idPrestamista));
        }
    }
}
