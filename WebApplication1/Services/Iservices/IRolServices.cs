using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Majo29AV.Services.Iservices
{
    public interface IRolServices
    {
        public Task<Response<List<Rol>>> GetAll();
        public Task<Response<Rol>> GetbyId(int id);
        public Task<Response<Rol>> Create(RolRequest request);
        public Task<Response<Rol>> Update(RolRequest request, int id);
        public Task<Response<Rol>> Delete(int id);

    }
}
