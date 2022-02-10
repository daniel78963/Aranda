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
        Response<bool> AddValidation(ProductosDto productosDto);
        Task<Response<bool>> AddAsync(ProductosDto productoDto);
        Task<Response<bool>> UpdateAsync(ProductosDto productoDto);
        Task<Response<bool>> DeleteAsync(int id);
        Response<ProductosDto> Get(int id);
        Response<IEnumerable<ProductosDto>> GetProducts(string parameters);
        Task<Response<List<Error>>> ValidateObjetc(ProductosDto productosDto);


    }
}
