using Assesment_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assesment_CRUD.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            var userName = "erick.torres@unosquare.com";
            var password = "admin123";
            if (login.Username == userName && login.Password == password)
            {
                var claims = new[]
           {
                new Claim(ClaimTypes.Name, login.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("k08sUhxw4rgri8rOaqhHJPlkyQaDHneK"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:7220/",
                    audience: "https://localhost:7220/",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    response="success"
                });
            }
            else
            {
                return Ok(new
                {
                    token = "null",
                });

            }
            
        }

            private string GenerateJwtToken()
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("k08sUhxw4rgri8rOaqhHJPlkyQaDHneK");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            
        }
    }
}


