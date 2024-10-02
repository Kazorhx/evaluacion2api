using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using evaluacion2api.Responses;
using evaluacion2api.Data;
using evaluacion2api.Models;
using evaluacion2api.Services;
using evaluacion2api.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace evaluacion2api.Controllers
{
    [ApiController]
    [Route("MiApiDeEjemplo/[controller]")]
    public class HerramientaController : ControllerBase
    {
        private readonly HerramientaService _herramientaService;

        public HerramientaController(HerramientaService herramientaService)
        {
            _herramientaService = herramientaService;
        }

        // Crear herramienta
        [HttpPost("crear-herramienta")]
        public async Task<ActionResult<Herramienta>> CreateHerramienta([FromBody] HerramientaDTO herramientaDTO)
        {
            var newHerramienta = new Herramienta
            {
                Nombre = herramientaDTO.Nombre,
                Marca = herramientaDTO.Marca,
                Cantidad = herramientaDTO.Cantidad,
                FechaAdquisicion = herramientaDTO.FechaAdquisicion
            };

            var result = await _herramientaService.CreateHerramientaAsync(newHerramienta);
            return CreatedAtAction(nameof(GetHerramientaById), new { id = result.Id }, result);
        }

        // Obtener todas las herramientas
        [HttpGet("obtener-herramientas")]
        public async Task<ActionResult<List<Herramienta>>> GetAllHerramientas()
        {
            var herramientas = await _herramientaService.GetAllHerramientasAsync();
            return Ok(herramientas);
        }

        [HttpGet("obtener-herramienta/{id}")]
        public async Task<ActionResult<Herramienta>> GetHerramientaById(int id)
        {
            var herramienta = await _herramientaService.GetHerramientaByIdAsync(id);

            if (herramienta == null)
            {
                return NotFound();
            }

            return Ok(herramienta);
        }

        [HttpPut("actualizar-herramienta/{id}")]
        public async Task<ActionResult> UpdateHerramienta(int id, [FromBody] HerramientaDTO herramientaDTO)
        {
            var herramienta = new Herramienta
            {
                Nombre = herramientaDTO.Nombre,
                Marca = herramientaDTO.Marca,
                Cantidad = herramientaDTO.Cantidad,
                FechaAdquisicion = herramientaDTO.FechaAdquisicion
            };

            var result = await _herramientaService.UpdateHerramientaAsync(id, herramienta);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Herramienta actualizada correctamente");
        }

        [HttpDelete("eliminar-herramienta/{id}")]
        public async Task<ActionResult<bool>> DeleteHerramienta(int id)
        {
            var result = await _herramientaService.DeleteHerramientaAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Herramienta eliminada correctamente");
        }
    }
}
