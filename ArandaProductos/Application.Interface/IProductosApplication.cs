using Application.Dto;
using System.Collections.Generic;
using Transversal.Common;

namespace Application.Interface
{
    public interface IProductosApplication
    {
        Response<IEnumerable<ProductosDto>> GetProductos();
    }
}
