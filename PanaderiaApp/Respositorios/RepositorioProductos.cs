using Microsoft.EntityFrameworkCore;
using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly PanaderiaDBContext _context;
        private readonly RepositorioProductos _repositorioInventario;

        public RepositorioProductos(PanaderiaDBContext context, RepositorioProductos repositorioInventario)
        {
            _context = context;
            _repositorioInventario = repositorioInventario;
        }

        public async Task<Producto> Add(Producto inventario)
        {
            _context.Productos.Add(inventario);
            await _context.SaveChangesAsync();
            return inventario;
        }

        public async Task Delete(int id)
        {
            var inventario = await _context.Productos.FindAsync(id);
            if (inventario != null)
            {
                _context.Productos.Remove(inventario);
                await _context.SaveChangesAsync();
            }
            await _repositorioInventario.Delete(id);
        }

        public async Task Update(Producto inventario)
        {
            var inventarioActual = await _context.Productos.FindAsync(inventario.Id);
            if (inventarioActual != null)
            {
                inventarioActual.Nombre = inventario.Nombre;
                inventarioActual.Descripcion = inventario.Descripcion;
                inventarioActual.Precio = inventario.Precio;
                inventarioActual.Cantidad = inventario.Cantidad;
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