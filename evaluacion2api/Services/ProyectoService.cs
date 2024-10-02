using Microsoft.EntityFrameworkCore;
using evaluacion2api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using evaluacion2api.Data;
using evaluacion2api.DTOS;

namespace evaluacion2api.Services
{
    public class ProyectoService
    {
        private readonly EjemploDbContext _dbContext;

        public ProyectoService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Método para crear proyecto
        public async Task<Proyecto> CreateProjectAsync(ProyectoDTO projectDTO)
        {
            var newProject = new Proyecto
            {
                Nombre = projectDTO.Nombre,
                Descripcion = projectDTO.Descripcion,
                HorasTotales = projectDTO.HorasTotales,
                Estado = "Pendiente",
                HorasTrabajadas = 0,
                FechaCreacion = DateTime.UtcNow
            };

            await _dbContext.Proyectos.AddAsync(newProject);
            await _dbContext.SaveChangesAsync();

            return newProject;
        }

        // Método para obtener los proyectos
        public async Task<List<Proyecto>> GetAllProjectsAsync()
        {
            return await _dbContext.Proyectos.ToListAsync();
        }

        // Método para obtener proyecto por ID
        public async Task<Proyecto> GetProjectByIdAsync(int projectId)
        {
            return await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.Id == projectId);
        }

        // Método para actualizar proyecto existente
        public async Task<bool> UpdateProjectAsync(int projectId, ProyectoDTO projectDTO)
        {
            var existingProject = await _dbContext.Proyectos.FindAsync(projectId);

            if (existingProject == null)
            {
                return false;
            }

            existingProject.Nombre = projectDTO.Nombre;
            existingProject.Descripcion = projectDTO.Descripcion;
            existingProject.HorasTotales = projectDTO.HorasTotales;

            _dbContext.Proyectos.Update(existingProject);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Método para eliminar proyecto
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var projectToDelete = await _dbContext.Proyectos.FindAsync(projectId);

            if (projectToDelete == null)
            {
                return false;
            }

            _dbContext.Proyectos.Remove(projectToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Método para actualizar el estado de proyecto
        public async Task<bool> UpdateProjectStatusAsync(int projectId, string newStatus)
        {
            var project = await _dbContext.Proyectos.FindAsync(projectId);

            if (project == null || !IsValidStatus(newStatus))
            {

                return false;
            }

            project.Estado = newStatus;
            _dbContext.Proyectos.Update(project);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Método para agregar horas trabajadas a proyecto
        public async Task<bool> AddWorkedHoursAsync(int projectId, int workedHours)
        {
            var project = await _dbContext.Proyectos.FindAsync(projectId);

            if (project == null || workedHours < 0)
            {
                return false;
            }

            project.HorasTrabajadas += workedHours;

            // Asegurar que las horas trabajadas no excedan las horas totales
            if (project.HorasTrabajadas > project.HorasTotales)
            {
                project.HorasTrabajadas = project.HorasTotales;
            }

            _dbContext.Proyectos.Update(project);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Método para validar el estado de proyecto
        private bool IsValidStatus(string status)
        {
            return status == "Pendiente" || status == "En progreso" || status == "Finalizado";
        }

        internal async Task<bool> IngresarProyecto(Proyecto proyecto)
        {
            throw new NotImplementedException();
        }

        internal async Task<Proyecto> ObtenerProyecto(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task<List<Proyecto>> ListaProyectos()
        {
            throw new NotImplementedException();
        }
    }
}