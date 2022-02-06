using Domain.Entity;
using System.Collections.Generic;

namespace Infrastructure.Interface
{
    public interface IProductosRepository
    {
        IEnumerable<Productos> GetAllProducts();
    }
}
