using Microsoft.EntityFrameworkCore;
using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public class RepositorioInsumos : IRepositorioInsumos
    {
        private readonly PanaderiaDBContext _context;
        private readonly RepositorioInsumos _repositorioInventario;

        public RepositorioInsumos(PanaderiaDBContext context, RepositorioInsumos repositorioInventario)
        {
            _context = context;
            _repositorioInventario = repositorioInventario;
        }

        public async Task<Insumo> Add(Insumo inventario)
        {
            _context.Insumos.Add(inventario);
            await _context.SaveChangesAsync();
            return inventario;
        }

        public async Task Delete(int id)
        {
            var inventario = await _context.Insumos.FindAsync(id);
            if (inventario != null)
            {
                _context.Insumos.Remove(inventario);
                await _context.SaveChangesAsync();
            }
            await _repositorioInventario.Delete(id);
        }

        public async Task Update(Insumo inventario)
        {
            var inventarioActual = await _context.Insumos.FindAsync(inventario.Id);
            if (inventarioActual != null)
            {
                inventarioActual.Nombre = inventario.Nombre;
                inventarioActual.Descripcion = inventario.Descripcion;
                inventarioActual.Precio = inventario.Precio;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Insumo?> Get(int id)
        {
            return await _context.Insumos.FindAsync(id);
        }

        public async Task<List<Insumo>> GetAll()
        {
            return await _context.Insumos.ToListAsync();
        }

    }
}