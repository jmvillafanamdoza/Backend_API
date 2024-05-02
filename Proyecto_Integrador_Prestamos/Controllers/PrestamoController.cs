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

        [HttpPost]
        [Route("CrearPrestamo")]
        public async Task<ActionResult<Prestamo>> CreatePrestamo([FromBody] Prestamo prestamo)
        {
            try
            {
                if (prestamo == null) return BadRequest("Invalid data");

                var created = await prestamoRepository.CreatePrestamo(prestamo);
                return CreatedAtAction(nameof(CreatePrestamo), new { id = created.NroPrestamo }, created);
            }
            catch (Exception ex)
            {
                // Log the exception detail
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }

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