using Microsoft.AspNetCore.Mvc;
using Proyecto_Integrador_Prestamos.Models;
using Proyecto_Integrador_Prestamos.Repositories;

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : ControllerBase
    {
        private readonly IPreciosRepository precioRepository;
        public PrecioController(IPreciosRepository precioRepository)
        {
            this.precioRepository = precioRepository;
        }
        [HttpGet]
        [Route("GetPrecio")]
        public async Task<ActionResult<IEnumerable<Precio>>> GetJefePrestamista()
        {
            return StatusCode(StatusCodes.Status200OK, await precioRepository.GetPrecio());
        }
        [HttpPost]
        [Route("CrearPrecio")]
        public async Task<ActionResult<Precio>> CreatePrecio(Precio precio)
        {
            return StatusCode(StatusCodes.Status201Created, await precioRepository.CreatePrecio(precio));

        }
    }
}
