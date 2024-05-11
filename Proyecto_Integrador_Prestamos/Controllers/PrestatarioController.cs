using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Proyecto_Integrador_Prestamos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestatarioController : ControllerBase
    {
        private readonly IPrestatarioRepository prestatarioRepository;
        public PrestatarioController(IPrestatarioRepository prestatarioRepository)
        {
            this.prestatarioRepository = prestatarioRepository;
        }

        [HttpGet("getPrestatarioByCreatorUser")]
        public async Task<ActionResult<IEnumerable<Prestamista>>> GetPrestatarioByCreatorUser(string creatorUser)
        {
            return StatusCode(StatusCodes.Status200OK, await prestatarioRepository.GetPrestatarioByCreatorUser(creatorUser));
        }
        [HttpGet("getPrestatarioById")]
        public async Task<ActionResult<Prestatario>> GetPrestatarioById(int prestatarioId)
        {
            return StatusCode(StatusCodes.Status200OK, await prestatarioRepository.GetPrestatarioById(prestatarioId));
        }

        [HttpGet]
        [Route("GetPrestatario")]
        public async Task<ActionResult<IEnumerable<Prestatario>>> GetPrestatario()
        {
            return StatusCode(StatusCodes.Status200OK, await prestatarioRepository.GetPrestatario());
        }

        [HttpPost]
        [Route("CrearPrestatario")]
        public async Task<ActionResult<Prestatario>> CreatePrestatario(Prestatario prestatario)
        {
            prestatario.Estado = "Activo";
            return StatusCode(StatusCodes.Status201Created, await prestatarioRepository.CreatePrestatario(prestatario));

        }

        [HttpPut]
        [Route("ActualizarPrestatario")]
        public async Task<ActionResult<Prestatario>> UpdatePrestatario(Prestatario prestatario)
        {
            return StatusCode(StatusCodes.Status200OK, await prestatarioRepository.UpdatePrestatario(prestatario));
        }

        [HttpDelete]
        [Route("EliminarPrestatario")]
        public async Task<ActionResult<bool>> DeletePrestatario(int idPrestatario)
        {
            return StatusCode(StatusCodes.Status200OK, await prestatarioRepository.DeletePrestatario(idPrestatario));
        }
    }
}