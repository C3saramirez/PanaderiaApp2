using Microsoft.EntityFrameworkCore;
using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly PanaderiaDBContext _context;
        private readonly RepositorioProveedores _repositorioProveedores;

        public RepositorioProveedores(PanaderiaDBContext context, RepositorioProveedores repositorioProveedores)
        {
            _context = context;
            _repositorioProveedores = repositorioProveedores;
        }

        public async Task<Proveedor> Add(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        public async Task Delete(int id)
        {
            var inventario = await _context.Proveedores.FindAsync(id);
            if (inventario != null)
            {
                _context.Proveedores.Remove(inventario);
                await _context.SaveChangesAsync();
            }
            await _repositorioProveedores.Delete(id);
        }

        public async Task Update(int id, Proveedor proveedor)
        {
            var proveedorActual = await _context.Proveedores.FindAsync(id);
            if (proveedorActual != null)
            {
                proveedorActual.Nombre = proveedor.Nombre;
                proveedorActual.Direccion = proveedor.Direccion;
                proveedorActual.Telefono = proveedor.Telefono;
                proveedorActual.Correo = proveedor.Correo;
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