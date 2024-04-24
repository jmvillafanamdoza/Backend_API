using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Helpers;
using Proyecto_Integrador_Prestamos.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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

            var user = await _appDBContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName); //&& x.Password == userObj.Password



            if (user == null)
            {
                return NotFound(new {Message = "User Not Found!"});
            }
            if(!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }

            user.Token = CreateJWToken(user);

            return Ok(new
            {
                Token = user.Token,
                Message = "Login Success!"
            });;

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            //Check Username

            if(await CheckUserNAmeExistAsync(userObj.UserName))
            {
                return BadRequest(new {Message = "Username Already Exist!"});
            }

            //Check Email

            if (await CheckEmailNAmeExistAsync(userObj.Email))
            {
                return BadRequest(new { Message = "Email Already Exist!" });
            }

            //Check Dni

            if (await CheckDniExistAsync(userObj.Dni))
            {
                return BadRequest(new { Message = "Dni Already Exist!" });
            }

            //check Password Strength
            var pass = CheckPasswordStrength(userObj.Password);
            if(!string.IsNullOrEmpty(pass))
            {
                return BadRequest(new  {Message = pass});
            }

            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";
            await _appDBContext.Users.AddAsync(userObj);
            await _appDBContext.SaveChangesAsync();
            return Ok(new 
            {
                Message = "User Registered!"
            });
             
        }

        //fin del register method


        private async Task<bool> CheckUserNAmeExistAsync(string username)
        {
            return await _appDBContext.Users.AnyAsync(x => x.UserName == username);
        }

        private async Task<bool> CheckEmailNAmeExistAsync(string email)
        {
            return await _appDBContext.Users.AnyAsync(x => x.Email == email);
        }

        private async Task<bool> CheckDniExistAsync(string dni)
        {
            return await _appDBContext.Users.AnyAsync(x => x.Dni == dni);
        }

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder(); 
            if (password.Length < 8 ) 
            { 
                sb.Append("El password tiene que tener mínimo 8 caracteres" + Environment.NewLine);
            }
            if(!(Regex.IsMatch(password,"[a-z]") && Regex.IsMatch(password,"[A-Z]") && Regex.IsMatch(password,"[0-9]")))
            {
                sb.Append("Password tiene que contener caracteres alfanuméricos" + Environment.NewLine);
            }
            if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.]"))
            {
                sb.Append("Password tiene que contener especial caracteres" + Environment.NewLine);
            }
            return sb.ToString();
        }

        private string  CreateJWToken(User usertoken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key             = Encoding.ASCII.GetBytes("beryberysecret.....");
            var identity        = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, usertoken.Role),
                new Claim(ClaimTypes.Name,$"{usertoken.FirstName} {usertoken.LastName}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                NotBefore = DateTime.UtcNow, // Ensure that 'NotBefore' is set to the current UTC time
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _appDBContext.Users.ToListAsync());
        }

    }
}
