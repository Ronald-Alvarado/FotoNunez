using Entidades;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source= ./Data/FotoNunes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { UsuarioId = 1, Nombres = "Administrador", NombreUsuario = "admin", Contrasena = "admin", Email = "Example@Fulano.com" });
        }
    }
}
