using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transversal.Common.Parameters;

namespace Infrastructure.Interface
{
    public interface IProductosRepository
    {
        IEnumerable<Productos> GetAllProducts();
        Productos Get(int id);
        IEnumerable<Productos> GetProducts(string parameters);
        IEnumerable<Productos> GetProducts(string filters, string parameters);
        IEnumerable<Productos> GetProductsFilters(ProductsParameters parameters);
        void Add(Productos producto);
        void AddValidate(Productos producto);
        Task<bool> AddAsync(Productos producto);
        Task<bool> DeleteAsync(Productos producto);
        Task<bool> UpdateAsync(Productos producto);
    }
}
