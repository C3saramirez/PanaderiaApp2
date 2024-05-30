using Microsoft.EntityFrameworkCore;

namespace PanaderiaApp.Modelos
{
    public class PanaderiaDBContext : DbContext
    {
        public PanaderiaDBContext(DbContextOptions<PanaderiaDBContext> options) : base(options)
        { }

        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
