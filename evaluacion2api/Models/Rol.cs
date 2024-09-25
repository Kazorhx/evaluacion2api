using System.ComponentModel.DataAnnotations;

namespace evaluacion2api.Models
{
    public class Rol
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
