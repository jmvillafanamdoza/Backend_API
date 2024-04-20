using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Proyecto_Integrador_Prestamos.Controllers
{
    public class PrestatarioController : ControllerBase
    {
        private readonly IPrestatarioRepository prestatarioRepository;
        public PrestatarioController(IPrestatarioRepository prestatarioRepository)
        {
            this.prestatarioRepository = prestatarioRepository;
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