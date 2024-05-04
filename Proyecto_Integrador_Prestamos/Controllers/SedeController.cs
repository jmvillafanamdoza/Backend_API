using Microsoft.AspNetCore.Mvc;
using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SedeController : ControllerBase
    {
        private readonly ISedeRepository sedeRepository;
        public SedeController(ISedeRepository sedeRepository)
        {
            this.sedeRepository = sedeRepository;
        }

        [HttpGet("getSedeById")]
        public async Task<ActionResult<User>> GetSedeById(int idSede)
        {
            return StatusCode(StatusCodes.Status200OK, await sedeRepository.GetSedeById(idSede));
        }

        [HttpGet]
        [Route("GetSede")]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSede()
        {
            return StatusCode(StatusCodes.Status200OK, await sedeRepository.GetSede());
        }

        [HttpPost]
        [Route("CrearSede")]
        public async Task<ActionResult<Sede>> CreateSede(Sede sede)
        {
            sede.Estado = "Activo";
            return StatusCode(StatusCodes.Status201Created, await sedeRepository.CreateSede(sede));

        }

        [HttpPut]
        [Route("ActualizarSede")]
        public async Task<ActionResult<Sede>> UpdateSede(Sede sede)
        {
            return StatusCode(StatusCodes.Status200OK, await sedeRepository.UpdateSede(sede));
        }

        [HttpDelete]
        [Route("EliminarSede")]
        public async Task<ActionResult<bool>> DeleteSede(int idSede)
        {
            return StatusCode(StatusCodes.Status200OK, await sedeRepository.DeleteSede(idSede));
        }
    }
}
