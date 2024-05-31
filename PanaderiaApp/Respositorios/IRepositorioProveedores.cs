using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public interface IRepositorioProveedores
    {
        Task<List<Proveedor>> GetAll();
        Task<Proveedor?> Get(int id);

        Task<Proveedor> Add(Proveedor proveedor);
        Task Update(int id, Proveedor proveedor);
        Task Delete(int id);
    }
}
