using Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IProductosApplication
    {
        Response<IEnumerable<ProductosDto>> GetProductos();
        Response<bool> Add(ProductosDto productosDto);
        Task<Response<bool>> UpdateAsync(ProductosDto productoDto);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<ProductosDto>> GetAsync(int id);


    }
}
