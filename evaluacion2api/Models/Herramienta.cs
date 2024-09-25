using System.ComponentModel.DataAnnotations;

namespace evaluacion2api.Models
{
    public class Herramienta
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
