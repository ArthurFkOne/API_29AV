using Azure.Core;
using Domain.DTO;
using Domain.Entities;
using Majo29AV.Context;
using Majo29AV.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace Majo29AV.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> GetAll()
        {
            try
            {

                List<Usuario> response = await _context.Usuarios.Include(x=>x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response, "Lista de Usuarios");

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetbyId(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.Include(x => x.Roles).FirstOrDefaultAsync(x => x.PkUsuario == id);

                return new Response<Usuario>(usuario, "Usuario encontrado");

            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Usuario>> Create(UsuarioRequest request)
        {
            try
            {
                Usuario usuario1 = new Usuario()
                {
                    Nombre = request.Nombre,
                    Password = request.Password,
                    UserName = request.UserName,
                    FkRol = request.FkRol,
                };

                _context.Usuarios.Add(usuario1);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario1, "Usuario Creado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
        public async Task<Response<Usuario>> Delete(int id)
        {
            try
            {
                try
                {
                    Usuario usuario3 = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);

                    _context.Usuarios.Remove(usuario3);
                    await _context.SaveChangesAsync();

                    return new Response<Usuario>(usuario3, "Usuario eliminado");

                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrio un error " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
        public async Task<Response<Usuario>> Update(UsuarioRequest user, int id)
        {
            try
            {
                try
                {
                    Usuario usuario2 = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);


                    usuario2.Nombre = user.Nombre;
                    usuario2.Password = user.Password;
                    usuario2.UserName = user.UserName;
                    usuario2.FkRol = user.FkRol;
                    
                    await _context.SaveChangesAsync();

                    return new Response<Usuario>(usuario2, "Usuario Actualizado");

                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrio un error " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }

        public UsuarioRequest? ValidarUsuario(UsuarioRequest request)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.UserName == request.UserName && u.Password == request.Password);

            if (usuario == null)
                return null;

            return new UsuarioRequest
            {
                Nombre = usuario.Nombre,
                UserName = usuario.UserName,
                Password = usuario.Password,
                FkRol = usuario.FkRol
            };
        }

    }
}
