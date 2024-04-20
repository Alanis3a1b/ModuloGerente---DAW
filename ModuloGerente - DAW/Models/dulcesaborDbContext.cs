using Microsoft.EntityFrameworkCore;

namespace ModuloGerente___DAW.Models
{
    public class dulcesaborDbContext : DbContext
    {
        public dulcesaborDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
