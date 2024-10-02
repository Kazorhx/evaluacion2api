using evaluacion2api.Models;
using Microsoft.EntityFrameworkCore;
using evaluacion2api.Data;

namespace evaluacion2api.Services
{
    public class RolesService
    {
        private readonly EjemploDbContext _dbcontext;

        public RolesService(EjemploDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Rol> ObtenerRoles(int id)
        {
            Rol rol = await _dbcontext.Roles.FindAsync(id);
            return rol;
        }

    }
}
