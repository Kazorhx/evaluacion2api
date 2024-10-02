using Microsoft.EntityFrameworkCore;
using evaluacion2api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using evaluacion2api.Data;

namespace evaluacion2api.Services
{
    public class HerramientaService
    {
        private readonly EjemploDbContext _dbContext;

        public HerramientaService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Método para crear una herramienta
        public async Task<Herramienta> CreateHerramientaAsync(Herramienta herramienta)
        {
            if (string.IsNullOrWhiteSpace(herramienta.Nombre))
            {
                throw new ArgumentException("El nombre de la herramienta es obligatorio.");
            }

            _dbContext.Herramientas.Add(herramienta);
            await _dbContext.SaveChangesAsync();

            return herramienta;
        }

        // Método para obtener todas las herramientas
        public async Task<List<Herramienta>> GetAllHerramientasAsync()
        {
            return await _dbContext.Herramientas.ToListAsync();
        }

        // Método para obtener una herramienta por ID
        public async Task<Herramienta> GetHerramientaByIdAsync(int id)
        {
            return await _dbContext.Herramientas.FirstOrDefaultAsync(h => h.Id == id);
        }

        // Método para eliminar una herramienta
        public async Task<bool> DeleteHerramientaAsync(int id)
        {
            var HerramientaEliminar = await _dbContext.Herramientas.FindAsync(id);

            if (HerramientaEliminar != null)
            {
                _dbContext.Herramientas.Remove(HerramientaEliminar);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        // Método para actualizar una herramienta (agregado)
        public async Task<bool> UpdateHerramientaAsync(int id, Herramienta herramienta)
        {
            var Herramientaactualizar = await _dbContext.Herramientas.FindAsync(id);
            if (Herramientaactualizar == null) return false;

            Herramientaactualizar.Nombre = herramienta.Nombre;
            Herramientaactualizar.Marca = herramienta.Marca;
            Herramientaactualizar.Cantidad = herramienta.Cantidad;
            Herramientaactualizar.FechaAdquisicion = herramienta.FechaAdquisicion;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
