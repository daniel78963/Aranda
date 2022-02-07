using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProductosDomain
    {
        IEnumerable<Productos> GetProductos();
        void Add(Productos producto);
        Task<bool> UpdateAsync(Productos producto);
        Task<bool> DeleteAsync(int id);
        Task<Productos> GetAsync(int Id);
    }
}
