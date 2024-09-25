﻿using System.ComponentModel.DataAnnotations.Schema;

namespace evaluacion2api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public ICollection<Tarea> Tareas { get; set; }

    }
}
