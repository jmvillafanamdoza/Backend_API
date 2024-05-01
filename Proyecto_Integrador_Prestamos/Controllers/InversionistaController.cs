using Microsoft.AspNetCore.Mvc;
using Proyecto_Integrador_Prestamos.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InversionistaController : ControllerBase
    {
        public readonly AppDBContext _appDBContext;

        public InversionistaController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

    }
}
