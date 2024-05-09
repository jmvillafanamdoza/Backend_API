using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoRepository prestamoRepository;
        public PrestamoController(IPrestamoRepository prestamoRepository)
        {
            this.prestamoRepository = prestamoRepository;
        }
        [HttpGet]
        [Route("GetPrestamo")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos()
        {
            return StatusCode(StatusCodes.Status200OK, await prestamoRepository.GetPrestamo());
        }

        [HttpGet("getPrestamoByIdPrestatario")]
        public async Task<ActionResult<IEnumerable<Prestamista>>> GetPrestatarioByCreatorUser(int idPrestatario)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamoRepository.GetPrestamoByIdPrestatario(idPrestatario));
        }

        [HttpGet("getPrestamoByIdPrestamista")]
        public async Task<ActionResult<IEnumerable<Prestamista>>> GetPrestamoByIdPrestamista(int idPrestamista)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamoRepository.GetPrestamoByIdPrestamista(idPrestamista));
        }

        [HttpPost]
        [Route("CrearPrestamo")]
        public async Task<ActionResult<Prestamo>> CreatePrestamo(Prestamo prestamo)
        {
            prestamo.Estado = "Pendiente";
            return StatusCode(StatusCodes.Status201Created, await prestamoRepository.CreatePrestamo(prestamo));

        }

        [HttpPut]
        [Route("ActualizarPrestamo")]
        public async Task<ActionResult<Prestamo>> UpdatePrestamo(Prestamo prestamo)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamoRepository.UpdatePrestamo(prestamo));
        }

        [HttpDelete]
        [Route("EliminarPrestamo")]
        public async Task<ActionResult<bool>> DeletePrestamo(int numPrestamo)
        {
            return StatusCode(StatusCodes.Status200OK, await prestamoRepository.DeletePrestamo(numPrestamo));
        }
    }
}