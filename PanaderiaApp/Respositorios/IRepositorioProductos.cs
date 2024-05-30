using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public interface IRepositorioProductos
    {
        Task<List<Producto>> GetAll();
        Task<Producto?> Get(int id);

        Task<Producto> Add(Producto inventario);
        Task Update(Producto inventario);
        Task Delete(int id);
    }
}
