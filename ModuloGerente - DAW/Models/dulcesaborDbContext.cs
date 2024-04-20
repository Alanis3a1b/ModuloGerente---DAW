using Microsoft.EntityFrameworkCore;

namespace ModuloGerente___DAW.Models
{
    public class dulcesaborDbContext : DbContext
    {
        public dulcesaborDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<detalles_pedidos> detalles_pedidos { get; set; }
        public DbSet<comentarios> comentarios { get; set; }
        public DbSet<direcciones> direcciones { get; set; }
        public DbSet<pagos> pagos { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
    }
}
