using Microsoft.EntityFrameworkCore;
using evaluacion2api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using evaluacion2api.Data;

namespace evaluacion2api.Services
{
    public class ProyectoService
    {
        private readonly EjemploDbContext context;

        public ProyectoService(EjemploDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Proyecto>> ListaProyectos()
        {
            return await context.Proyectos.ToListAsync();
        }

        public async Task<Proyecto> ObtenerProyecto(int id)
        {
            return await context.Proyectos.FindAsync(id);
        }

        public async Task<bool> IngresarProyecto(Proyecto proyecto)
        {
            try
            {
                proyecto.FechaCreacion = DateTime.Now; // Asigna la fecha de creación automáticamente

                context.Proyectos.Add(proyecto);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes registrar el error si lo deseas)
                return false;
            }
        }
    }
}
