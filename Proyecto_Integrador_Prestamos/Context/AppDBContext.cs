using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Context
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Prestatario> Prestatarios { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo");
            modelBuilder.Entity<Prestatario>().ToTable("Prestatario");
        }
    }
}
