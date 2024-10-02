using Microsoft.AspNetCore.Mvc;
using evaluacion2api.Models;
using evaluacion2api.Services;
using evaluacion2api.DTOS;

namespace evaluacion2api.Controllers
{
    [ApiController]
    [Route("MiApiDeEjemplo/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("crear-usuario")]
        public async Task<ActionResult<Usuario>> CreateUser([FromBody] UsuarioDTO usuarioDTO)
        {
            var newUser = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                RolId = usuarioDTO.RolId
            };

            var result = await _usuarioService.CreateUserAsync(newUser);
            return Ok(result);
        }

        [HttpGet("obtener-usuarios")]
        public async Task<ActionResult<List<Usuario>>> GetAllUsers()
        {
            var usuarios = await _usuarioService.GetAllUsersAsync();
            return Ok(usuarios);
        }

        [HttpGet("obtener-usuario/{id}")]
        public async Task<ActionResult<Usuario>> GetUserById(int id)
        {
            var usuario = await _usuarioService.GetUserByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPut("actualizar-usuario/{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                RolId = usuarioDTO.RolId
            };

            var result = await _usuarioService.UpdateUserAsync(id, usuario);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Usuario actualizado correctamente");
        }

        [HttpDelete("eliminar-usuario/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _usuarioService.DeleteUserAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Usuario eliminado correctamente");
        }
    }
}
