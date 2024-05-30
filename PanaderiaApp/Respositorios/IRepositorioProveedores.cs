using PanaderiaApp.Modelos;

namespace PanaderiaApp.Repositorios
{
    public interface IRepositorioProveedores
    {
        Task<List<Proveedor>> GetAll();
        Task<Proveedor?> Get(int id);

        Task<Proveedor> Add(Proveedor proveedor);
        Task Update(Proveedor proveedor);
        Task Delete(int id);
    }
}
