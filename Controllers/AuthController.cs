using Microsoft.AspNetCore.Mvc;
using AxioSera.Orchestration.Api.Data;
using AxioSera.Orchestration.Api.Dtos;
using AxioSera.Orchestration.Api.Models;
using AxioSera.Orchestration.Api.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace AxioSera.Orchestration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IJwtService _jwt;
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;
         
        public AuthController(IConfiguration config, IAuthService auth, IJwtService jwt, AppDbContext db)
        {
            _auth = auth;
            _jwt = jwt;
            _db = db;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            // Dummy validation (replace with DB check)
            if (login.Username == "admin" && login.Password == "password")
            {
                var token = GenerateJwtToken(login.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            return Ok("This is protected data, only visible with a valid JWT token.");
        }

        [Authorize]
        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            return Ok(_db.Users.ToList());
        }
        [Authorize]
        [HttpGet("getuser/{id}")]
        public IActionResult GetUsers(int id)
        {
          return  Ok(_db.Users.Find(id));
        }

        [AllowAnonymous]
        [HttpPost("users")]
        public IActionResult CreateUser([FromBody] UserDto dto)
        {
            var created = _auth.CreateUser(dto.Username, dto.Password, dto.RoleName ?? "User");
            return Ok(created);
        }
    }
}
