using Microsoft.EntityFrameworkCore;
using evaluacion2api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using evaluacion2api.Data;
using evaluacion2api.DTOS;

namespace evaluacion2api.Services
{
    public class TareaService
    {
        private readonly EjemploDbContext _dbContext;

        public TareaService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Método para crear una tarea
        public async Task<Tarea> CreateTaskAsync(TareaDTO tareaDTO)
        {
            var newTask = new Tarea
            {
                FechaInicio = tareaDTO.FechaInicio,
                Estado = tareaDTO.Estado,
                Horas = tareaDTO.Horas,
                Area = tareaDTO.Area,
                ProyectoId = tareaDTO.ProyectoId,
                UsuarioId = tareaDTO.UsuarioId,
                SetHerramientas = tareaDTO.SetHerramientas
            };

            await _dbContext.Tareas.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();

            return newTask;
        }

        // Método para obtener todas las tareas
        public async Task<List<Tarea>> GetAllTasksAsync()
        {
            return await _dbContext.Tareas.ToListAsync();
        }

        // Método para obtener una tarea por ID
        public async Task<Tarea> GetTaskByIdAsync(int taskId)
        {
            return await _dbContext.Tareas.FirstOrDefaultAsync(t => t.Id == taskId);
        }

        // Método para actualizar una tarea existente
        public async Task<bool> UpdateTaskAsync(int taskId, TareaDTO tareaDTO)
        {
            var existingTask = await _dbContext.Tareas.FindAsync(taskId);

            if (existingTask == null)
            {
                return false;
            }

            existingTask.FechaInicio = tareaDTO.FechaInicio;
            existingTask.Estado = tareaDTO.Estado;
            existingTask.Horas = tareaDTO.Horas;
            existingTask.Area = tareaDTO.Area;
            existingTask.ProyectoId = tareaDTO.ProyectoId;
            existingTask.UsuarioId = tareaDTO.UsuarioId;
            existingTask.SetHerramientas = tareaDTO.SetHerramientas;

            _dbContext.Tareas.Update(existingTask);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Método para eliminar una tarea
        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var taskToDelete = await _dbContext.Tareas.FindAsync(taskId);

            if (taskToDelete == null)
            {
                return false;
            }

            _dbContext.Tareas.Remove(taskToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
