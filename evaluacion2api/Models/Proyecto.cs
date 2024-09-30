using System.ComponentModel.DataAnnotations;

namespace evaluacion2api.Models
{
    public class Proyecto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Estado { get; set; }

        public int HorasTrabajadas { get; set; }

        [Required]
        public int HorasTotales { get; set; }
        
        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}
