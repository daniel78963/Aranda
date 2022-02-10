using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Parameters;

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
        IEnumerable<Productos> GetProducts(string filters, string parameters);
        IEnumerable<Productos> GetProductsFilters(ProductsParameters parameters);
    }
}
