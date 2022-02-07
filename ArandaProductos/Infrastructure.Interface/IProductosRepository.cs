using Domain.Entity;
using System.Collections.Generic;

namespace Infrastructure.Interface
{
    public interface IProductosRepository
    {
        IEnumerable<Productos> GetAllProducts();
        Productos Get(int Id);
        void SaveProduct(Productos producto);
        void DeleteProduct(Productos producto);
        void UpdateProduct(Productos producto);
    }
}
