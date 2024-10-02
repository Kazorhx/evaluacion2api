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
        public async Task<Herramienta> CreateToolAsync(string toolName)
        {
            var newTool = new Herramienta
            {
                Nombre = toolName
            };

            await _dbContext.Herramientas.AddAsync(newTool);
            await _dbContext.SaveChangesAsync();

            return newTool;
        }

        // Método para obtener todas las herramientas
        public async Task<List<Herramienta>> GetAllToolsAsync()
        {
            return await _dbContext.Herramientas.ToListAsync();
        }

        // Método para obtener una herramienta por ID
        public async Task<Herramienta> GetToolByIdAsync(int toolId)
        {
            return await _dbContext.Herramientas.FirstOrDefaultAsync(h => h.Id == toolId);
        }

        // Método para eliminar una herramienta
        public async Task<bool> DeleteToolAsync(int toolId)
        {
            var toolToDelete = await _dbContext.Herramientas.FindAsync(toolId);

            if (toolToDelete == null)
            {
                return false;
            }

            _dbContext.Herramientas.Remove(toolToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
