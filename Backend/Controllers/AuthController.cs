using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static readonly List<User> Users = new()
        {
            new User { Username = "admin", Password = "admin123", Role = Roles.Admin },
            new User { Username = "editor", Password = "editor123", Role = Roles.Editor },
            new User { Username = "viewer", Password = "viewer123", Role = Roles.Viewer }
        };

        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var user = Users.FirstOrDefault(u =>
                u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (user == null)
                return Unauthorized("Invalid usernme or password");

            var token = GenerateJwtToken(user);

            return Ok(new { token, role = user.Role });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
