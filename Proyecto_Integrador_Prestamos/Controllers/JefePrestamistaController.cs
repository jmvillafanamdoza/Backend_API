using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JefePrestamistaController : ControllerBase
    {
        public readonly AppDBContext _appDBContext;
        public JefePrestamistaController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<JefePrestamista>> GetAllUsers()
        {
            return Ok(await _appDBContext.JefesPrestamistas.ToListAsync());
        }

    }
}
