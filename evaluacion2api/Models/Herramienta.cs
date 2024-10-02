using System.ComponentModel.DataAnnotations;

namespace evaluacion2api.Models
{
    public class Herramienta
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Marca { get; set; }
        public string Cantidad { get; set; }
        public int FechaAdquisicion { get; set; }
    }
}
