using evaluacion2api.Services;
using evaluacion2api.DTOS;
using evaluacion2api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace evaluacion2api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaService _tareaService;

        public TareaController(TareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // Método para crear una nueva tarea
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TareaDTO tareaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTask = await _tareaService.CreateTaskAsync(tareaDTO);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        // Método para obtener todas las tareas
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _tareaService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // Método para obtener una tarea por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _tareaService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // Método para actualizar una tarea existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TareaDTO tareaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _tareaService.UpdateTaskAsync(id, tareaDTO);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Método para eliminar una tarea
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _tareaService.DeleteTaskAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
