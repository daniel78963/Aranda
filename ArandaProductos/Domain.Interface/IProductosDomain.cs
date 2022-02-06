using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Interface
{
    public interface IProductosDomain
    {
        IEnumerable<Productos> GetProductos();
    }
}
