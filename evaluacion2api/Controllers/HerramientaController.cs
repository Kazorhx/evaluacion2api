using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using evaluacion2api.Models;
using evaluacion2api.Services;
using evaluacion2api.DTOS;

namespace evaluacion2api.Controllers
{
    [ApiController]
    [Route("MiApiDeEjemplo/[controller]")]
    public class HerramientaController : Controller
    {
        private readonly HerramientaService _herramientaService;

        public HerramientaController(HerramientaService herramientaService)
        {
            _herramientaService = herramientaService;
        }

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
            return Ok(result);
        }

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
        public async Task<ActionResult> DeleteHerramienta(int id)
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