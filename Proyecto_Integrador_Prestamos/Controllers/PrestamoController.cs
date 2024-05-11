using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Integrador_Prestamos.Models.DTO;

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

        [HttpPut]
        [Route("ActualizarEstadoPrestamo/{nroPrestamo}")]
        public async Task<IActionResult> UpdateEstadoPrestamo(int nroPrestamo, [FromBody] EstadoDto estado)
        {
            try
            {
                Prestamo prestamo = await prestamoRepository.FindAsync(nroPrestamo);
                if (prestamo == null)
                {
                    return NotFound("Préstamo no encontrado.");
                }

                prestamo.Estado = estado.NuevoEstado;
                await prestamoRepository.UpdatePrestamo(prestamo);  // Asegúrate de que este método exista y esté implementado correctamente.
                                                                    // Si el estado nuevo es "APROBADO", crea las cuotas
                if (estado.NuevoEstado == "APROBADO")
                {
                    for (int i = 0; i < prestamo.diasDuracion; i++)
                    {
                        var cuota = new Cuota
                        {
                            NroPrestamo = prestamo.NroPrestamo,
                            IdPrestatario = prestamo.idPrestatario,
                            NroCuota = i + 1,
                            FechaCuota = DateTime.Today.AddDays(i),
                            pagoDiario = prestamo.pagoDiario,
                            Estado = "Pendiente"
                        };
                        // Asumiendo que tienes un método para agregar cuotas en tu repositorio
                        await prestamoRepository.AddCuota(cuota);
                    }
                }

                await prestamoRepository.SaveChangesAsync();
                return Ok(prestamo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}