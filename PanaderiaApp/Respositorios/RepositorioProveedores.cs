using Microsoft.EntityFrameworkCore;
using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly PanaderiaDBContext _context;
        private readonly RepositorioProveedores _repositorioInventario;

        public RepositorioProveedores(PanaderiaDBContext context, RepositorioProveedores repositorioInventario)
        {
            _context = context;
            _repositorioInventario = repositorioInventario;
        }

        public async Task<Proveedor> Add(Proveedor inventario)
        {
            _context.Proveedores.Add(inventario);
            await _context.SaveChangesAsync();
            return inventario;
        }

        public async Task Delete(int id)
        {
            var inventario = await _context.Proveedores.FindAsync(id);
            if (inventario != null)
            {
                _context.Proveedores.Remove(inventario);
                await _context.SaveChangesAsync();
            }
            await _repositorioInventario.Delete(id);
        }

        public async Task Update(Proveedores inventario)
        {
            var inventarioActual = await _context.Proveedores.FindAsync(inventario.Id);
            if (inventarioActual != null)
            {
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Proveedor?> Get(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<List<Proveedor>> GetAll()
        {
            return await _context.Proveedores.ToListAsync();
        }

    }
}