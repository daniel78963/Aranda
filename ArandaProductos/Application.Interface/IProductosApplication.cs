using Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Parameters;

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
        Response<IEnumerable<ProductosDto>> GetProductsFilters(ProductsParameters parameters);
        Response<IEnumerable<ProductosDto>> GetProducts(string filters, string parameters);
        Task<Response<List<Error>>> ValidateObjetc(ProductosDto productosDto);


    }
}
