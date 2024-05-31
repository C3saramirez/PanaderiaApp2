using Microsoft.EntityFrameworkCore;
using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly PanaderiaDBContext _context;
        private readonly RepositorioProductos _repositorioProductos;

        public RepositorioProductos(PanaderiaDBContext context, RepositorioProductos repositorioProductos)
        {
            _context = context;
            _repositorioProductos = repositorioProductos;
        }

        public async Task<Producto> Add(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            await _repositorioProductos.Delete(id);
        }

        public async Task Update(int id, Producto producto)
        {
            var productoActual = await _context.Productos.FindAsync(id);
            if (productoActual != null)
            {
                productoActual.Nombre = producto.Nombre;
                productoActual.Descripcion = producto.Descripcion;
                productoActual.Precio = producto.Precio;
                productoActual.Cantidad = producto.Cantidad;
                productoActual.Insumos = producto.Insumos;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Producto?> Get(int id)
        {
            return await _context.Productos.Include(p => p.Insumos).Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.Include(p => p.Insumos).ToListAsync();
        }

    }
}