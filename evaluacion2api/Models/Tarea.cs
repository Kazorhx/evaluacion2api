using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evaluacion2api.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        [RegularExpression("Pendiente|En progreso|Finalizado", ErrorMessage = "El estado debe ser 'Pendiente', 'En progreso' o 'Finalizado'.")]
        public string Estado { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Las horas deben ser al menos 1.")]
        public int Horas { get; set; }

        [Required]
        [RegularExpression("Hardware|Redes", ErrorMessage = "El área debe ser 'Hardware' o 'Redes'.")]
        public string Area { get; set; }

        //Llaves foraneas 
        [Required]
        [ForeignKey("Proyecto")]
        public string ProyectoId { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }

        [Required]
        public string SetHerramientas { get; set; }
    }
}
