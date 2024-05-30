using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public interface IRepositorioProveedores
    {
        Task<List<Proveedor>> GetAll();
        Task<Proveedor?> Get(int id);

        Task<Proveedor> Add(Proveedor inventario);
        Task Update(Proveedor inventario);
        Task Delete(int id);
    }
}
