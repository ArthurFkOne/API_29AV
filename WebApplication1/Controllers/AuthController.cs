using Domain.DTO;
using Majo29AV.Services.Iservices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Majo29AV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioService;
        private readonly IConfiguration _config;

        public AuthController(IUsuarioServices usuarioService, IConfiguration config)
        {
            _usuarioService = usuarioService;
            _config = config;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var usuarioValido = _usuarioService.ValidarUsuario(request);

                if (usuarioValido == null)
                    return Unauthorized("Credenciales inválidas");

                var claims = new[]
                {
            new Claim(ClaimTypes.Name, request.UserName)
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}

