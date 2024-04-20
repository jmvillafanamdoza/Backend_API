using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly AppDBContext _appDBContext;
        public UserController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            var user = await _appDBContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password == userObj.Password);
            if (user == null)
            {
                return NotFound(new {Message = "User Not Found!"});
            }

            return Ok(new
            {
                Message = "Login Success!"
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            await _appDBContext.Users.AddAsync(userObj);
            await _appDBContext.SaveChangesAsync();
            return Ok(new 
            {
                Message = "User Registered!"
            });
             
        }

    }
}
