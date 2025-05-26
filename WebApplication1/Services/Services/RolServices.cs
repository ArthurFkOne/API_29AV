using Azure.Core;
using Domain.DTO;
using Domain.Entities;
using Majo29AV.Context;
using Majo29AV.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace Majo29AV.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;
        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Rol>>> GetAll()
        {
            try
            {

                List<Rol> response = await _context.Roles.ToListAsync();

                return new Response<List<Rol>>(response, "Lista de Roles");

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Rol>> GetbyId(int id)
        {
            try
            {
                Rol rol = await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);

                return new Response<Rol>(rol, "Rol encontrado");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        public async Task<Response<Rol>> Create(RolRequest request)
        {
            try
            {
                Rol Rol1 = new Rol()
                {
                    Nombre = request.Nombre,
                    
                };

                _context.Roles.Add(Rol1);
                await _context.SaveChangesAsync();

                return new Response<Rol>(Rol1, "Rol Creado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
        public async Task<Response<Rol>> Delete(int id)
        {
            try
            {
                try
                {
                    Rol Rol3 = await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);

                    _context.Roles.Remove(Rol3);
                    await _context.SaveChangesAsync();

                    return new Response<Rol>(Rol3, "Rol eliminado");

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
        public async Task<Response<Rol>> Update(RolRequest rol, int id)
        {
            try
            {
                try
                {
                    Rol rol2 = await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);


                    rol2.Nombre = rol.Nombre;
                    

                    await _context.SaveChangesAsync();

                    return new Response<Rol>(rol2, "Rol Actualizado");

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
    }
}
