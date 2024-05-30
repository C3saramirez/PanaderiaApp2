using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public interface IRepositorioInsumos
    {
        Task<List<Insumo>> GetAll();
        Task<Insumo?> Get(int id);

        Task<Insumo> Add(Insumo inventario);
        Task Update(Insumo inventario);
        Task Delete(int id);
    }
}
