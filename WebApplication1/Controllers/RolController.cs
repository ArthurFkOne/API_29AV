using Domain.DTO;
using Domain.Entities;
using Majo29AV.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Majo29AV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;

        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _rolServices.GetAll();

            return Ok(response);

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _rolServices.GetbyId(id);

            return Ok(response);

        }
        
        [HttpPost]
        public async Task<IActionResult> Create(RolRequest request)
        {
            var response = await _rolServices.Create(request);

            return Ok(response);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _rolServices.Delete(id);

            return Ok(response);
        }
       
        [HttpPut]
        public async Task<IActionResult> Update(RolRequest request, int id)
        {
            var response = await _rolServices.Update(request, id);

            return Ok(response);
        }



    }
}
