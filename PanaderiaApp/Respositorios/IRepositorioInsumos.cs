using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public interface IRepositorioInsumos
    {
        Task<List<Insumo>> GetAll();
        Task<Insumo?> Get(int id);

        Task<Insumo> Add(Insumo insumo);
        Task Update(int id, Insumo insumo);
        Task Delete(int id);
    }
}
