using Microsoft.EntityFrameworkCore;
using evaluacion2api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using evaluacion2api.Data;

namespace evaluacion2api.Services
{
    public class UsuarioService
    {
        private readonly EjemploDbContext _dbContext;

        public UsuarioService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Método para crear un usuario
        public async Task<Usuario> CreateUserAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        // Método para obtener todos los usuarios
        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        // Método para obtener un usuario por ID
        public async Task<Usuario> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == userId);
        }

        // Método para actualizar un usuario existente
        public async Task<bool> UpdateUserAsync(int userId, Usuario usuario)
        {
            var existingUser = await _dbContext.Usuarios.FindAsync(userId);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.Nombre = usuario.Nombre;
            existingUser.Apellido = usuario.Apellido;
            existingUser.Email = usuario.Email;
            existingUser.Password = usuario.Password;
            existingUser.RolId = usuario.RolId;

            _dbContext.Usuarios.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Método para eliminar un usuario
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userToDelete = await _dbContext.Usuarios.FindAsync(userId);

            if (userToDelete == null)
            {
                return false;
            }

            _dbContext.Usuarios.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
