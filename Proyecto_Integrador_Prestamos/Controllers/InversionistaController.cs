using Microsoft.AspNetCore.Mvc;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InversionistaController : ControllerBase
    {
        private readonly IInversionistaRepository inversionistaRepository;
        public InversionistaController(IInversionistaRepository inversionistaRepository)
        {
            this.inversionistaRepository = inversionistaRepository;
        }

        [HttpGet]
        [Route("GetInversionista")]
        public async Task<ActionResult<IEnumerable<Inversionista>>> GetInversionista()
        {
            return StatusCode(StatusCodes.Status200OK, await inversionistaRepository.GetInversionista());
        }

        [HttpPost]
        [Route("CrearInversionista")]
        public async Task<ActionResult<Inversionista>> CreateInversionista(Inversionista inversionista)
        {
            inversionista.Estado = "Activo";
            return StatusCode(StatusCodes.Status201Created, await inversionistaRepository.CreateInversionista(inversionista));

        }

        [HttpPut]
        [Route("ActualizarInversionista")]
        public async Task<ActionResult<Inversionista>> UpdateInversionista(Inversionista inversionista)
        {
            return StatusCode(StatusCodes.Status200OK, await inversionistaRepository.UpdateInversionista(inversionista));
        }

        [HttpDelete]
        [Route("EliminarInversionista")]
        public async Task<ActionResult<bool>> DeleteInversionista(int idInversionista)
        {
            return StatusCode(StatusCodes.Status200OK, await inversionistaRepository.DeleteInversionista(idInversionista));
        }

    }
}
