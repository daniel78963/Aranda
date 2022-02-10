using Application.Dto;
using PagedList.Core;
using System.Collections.Generic;
using Transversal.Common;
using Transversal.Common.Parameters;

namespace Application.Interface
{
    public interface ICategoriasApplication
    {
        Response<IEnumerable<CategoriasDto>> GetCategoriasProductos();
        Response<IEnumerable<CategoriasDto>> GetCategorias(string parameters);
        PagedList<CategoriasDto> GetCategories(CategoriesParameters parameters);
    }
}
