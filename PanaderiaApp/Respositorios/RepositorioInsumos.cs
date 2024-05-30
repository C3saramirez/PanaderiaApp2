using Microsoft.EntityFrameworkCore;
using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public class RepositorioInsumos : IRepositorioInsumos
    {
        private readonly PanaderiaDBContext _context;
        private readonly RepositorioInsumos _repositorioInsumos;

        public RepositorioInsumos(PanaderiaDBContext context, RepositorioInsumos repositorioInsumos)
        {
            _context = context;
            _repositorioInsumos = repositorioInsumos;
        }

        public async Task<Insumo> Add(Insumo insumo)
        {
            _context.Insumos.Add(insumo);
            await _context.SaveChangesAsync();
            return insumo;
        }

        public async Task Delete(int id)
        {
            var insumo = await _context.Insumos.FindAsync(id);
            if (insumo != null)
            {
                _context.Insumos.Remove(insumo);
                await _context.SaveChangesAsync();
            }
            await _repositorioInsumos.Delete(id);
        }

        public async Task Update(Insumo insumo)
        {
            var inventarioActual = await _context.Insumos.FindAsync(insumo.Id);
            if (inventarioActual != null)
            {
                inventarioActual.Nombre = insumo.Nombre;
                inventarioActual.Descripcion = insumo.Descripcion;
                inventarioActual.Precio = insumo.Precio;
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