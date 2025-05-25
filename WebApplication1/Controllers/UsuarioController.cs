using Domain.DTO;
using Domain.Entities;
using Majo29AV.Services.Iservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Majo29AV.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarioServices.GetAll();

            return Ok(response);

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _usuarioServices.GetbyId(id);

            return Ok(response);

        }
        
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioRequest request)
        {
            var response = await _usuarioServices.Create(request);

            return Ok(response);
        }




    }
}
