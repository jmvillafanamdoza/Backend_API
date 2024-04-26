using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Context
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options) 
        {
            
        }
        public DbSet<Inversionista> Inversionistas { get; set; }
        public DbSet<JefePrestamista> JefesPrestamistas { get; set; }
        public DbSet<Prestamista> Prestamistas { get; set; }
        public DbSet<Prestatario> Prestatarios { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Sede> Sedes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Inversionista>().ToTable("Inversionistas");
            modelBuilder.Entity<JefePrestamista>().ToTable("JefesPrestamistas");
            modelBuilder.Entity<Prestamista>().ToTable("Prestamistas");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo");
            modelBuilder.Entity<Prestatario>().ToTable("Prestatario");
            modelBuilder.Entity<Sede>().ToTable("Sede");

        }
    }
}
