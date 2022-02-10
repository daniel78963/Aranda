using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transversal.Common;

namespace Domain.Interface
{
    public interface IProductosDomain
    {
        IEnumerable<Productos> GetProductos();
        void Add(Productos producto);
        void AddValidation(Productos producto);
        Task<Response<bool>> AddAsync(Productos producto);
        Task<bool> UpdateAsync(Productos producto);
        Task<bool> DeleteAsync(int id);
        Productos Get(int Id); 
        IEnumerable<Productos> GetProducts(string parameters);
    }
}
