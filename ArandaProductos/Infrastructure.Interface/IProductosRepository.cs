using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IProductosRepository
    {
        IEnumerable<Productos> GetAllProducts();
        Task<Productos> GetAsync(int id);
        void Add(Productos producto);
        Task<bool> DeleteAsync(Productos producto);
        Task<bool> UpdateAsync(Productos producto);
    }
}
