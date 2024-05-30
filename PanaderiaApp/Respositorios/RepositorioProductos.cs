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

        public async Task Update(Producto producto)
        {
            var inventarioActual = await _context.Productos.FindAsync(producto.Id);
            if (inventarioActual != null)
            {
                inventarioActual.Nombre = producto.Nombre;
                inventarioActual.Descripcion = producto.Descripcion;
                inventarioActual.Precio = producto.Precio;
                inventarioActual.Cantidad = producto.Cantidad;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Producto?> Get(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

    }
}