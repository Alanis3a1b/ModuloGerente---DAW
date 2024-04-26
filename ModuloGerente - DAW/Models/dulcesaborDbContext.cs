using Microsoft.EntityFrameworkCore;

namespace ModuloGerente___DAW.Models
{
    public class dulcesaborDbContext : DbContext
    {
        public dulcesaborDbContext(DbContextOptions options) : base(options)
        {

        }

        //Tablas añadidas por Diego
        public DbSet<comida> comida {  get; set; }
        public DbSet<detalle_de_pedido> detalle_De_Pedidos { get; set; }
        public DbSet<pedido> pedido { get; set; }

        //Tablas pedidos en linea
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<detalles_pedidos> detalles_pedidos { get; set; }
        public DbSet<comentarios> comentarios { get; set; }
        public DbSet<direcciones> direcciones { get; set; }
        public DbSet<pagos> pagos { get; set; }
        public DbSet<usuarios> usuarios { get; set; }

        //Tablas pedidos en restaurante
        public DbSet<cargos> cargos { get; set; }
        public DbSet<categorias> categorias { get; set; }
        public DbSet<combos> combos { get; set; }
        public DbSet<cuenta> cuenta { get; set; }
        public DbSet<detalle_fac> detalle_fac { get; set; }
        public DbSet<Detalle_pedidos> Detalles_pedidos { get; set; }
        public DbSet<empleados> empleados { get; set; }
        public DbSet<encabezado_fac> encabezado_fac { get; set; }
        public DbSet<estados> estados { get; set; }
        public DbSet<items_combo> items_combo { get; set; }
        public DbSet<items_menu> items_menu { get; set; }
        public DbSet<items_promo> items_promo { get; set; }
        public DbSet<mesas> mesas { get; set; }
        public DbSet<promociones> promociones { get; set; }






    }
}
