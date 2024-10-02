using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using evaluacion2api.Models;
using evaluacion2api.Responses;
using evaluacion2api.Services;
using evaluacion2api.Data;

namespace evaluacion2api.Controllers
{
    [ApiController]
    [Route("MiApiDeEjemplo/[controller]")]
    public class ProyectoController : Controller
    {
        private readonly ProyectoService _proyectoService;

        public ProyectoController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EjemploDbContext>();
            _proyectoService = new ProyectoService(context);
        }

        [HttpGet("obtener-proyectos")]
        public async Task<ActionResult<ProyectosResponse>> GetProyectos()
        {
            var proyectos = await _proyectoService.ListaProyectos();

            var response = new ProyectosResponse
            {
                Data = proyectos,
                Code = 200,
                Message = "Proyectos obtenidos correctamente"
            };

            return Ok(response);
        }

        [HttpGet("obtener-proyecto/{id}")]
        public async Task<ActionResult<ProyectoResponse>> GetProyecto(int id)
        {
            var proyecto = await _proyectoService.ObtenerProyecto(id);

            if (proyecto == null)
            {
                return NotFound(new ProyectoResponse
                {
                    Data = null,
                    Code = 404,
                    Message = "Proyecto no encontrado"
                });
            }

            var response = new ProyectoResponse
            {
                Data = proyecto,
                Code = 200,
                Message = "Proyecto obtenido correctamente"
            };

            return Ok(response);
        }

        [HttpPost("ingresar-proyecto")]
        public async Task<ActionResult<NuevoProyectoResponse>> PostProyecto([FromBody] Proyecto proyecto)
        {
            var ingreso = await _proyectoService.IngresarProyecto(proyecto);

            var response = new NuevoProyectoResponse
            {
                Data = ingreso,
                Code = ingreso ? 201 : 400,
                Message = ingreso ? "Proyecto ingresado correctamente" : "Error al ingresar el proyecto"
            };

            return Ok(response);
        }
    }
}
