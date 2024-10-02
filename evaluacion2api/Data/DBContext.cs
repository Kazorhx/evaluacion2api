using evaluacion2api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace evaluacion2api.Data
{

    public class EjemploDbContext : DbContext
    {
        public EjemploDbContext(DbContextOptions<EjemploDbContext> options) : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos iniciales para Roles
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Nombre = "Administrador"
            });

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 2,
                Nombre = "Empleado"
            });


            // Datos iniciales para Usuarios
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nombre = "Juan ",
                Apellido = "Camacaro",
                Email = "juan@juan.cl",
                Password = "1234",
                RolId = 1
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 2,
                Nombre = "Jesus",
                Apellido = "Camacaro",
                Email = "jesus@jesus.cl",
                Password = "1234",
                RolId = 2
            });

        }

    }

}
