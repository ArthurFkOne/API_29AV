using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Majo29AV.Services.Iservices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> GetAll();
        public Task<Response<Usuario>> GetbyId(int id);
        public Task<Response<Usuario>> Create(UsuarioRequest request);
        public Task<Response<Usuario>> Update(UsuarioRequest request, int id);
        public Task<Response<Usuario>> Delete(int id);

    }
}
