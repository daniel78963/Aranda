using Application.Dto;
using System.Collections.Generic;
using Transversal.Common;

namespace Application.Interface
{
    public interface ICategoriasApplication
    {
        Response<IEnumerable<CategoriasDto>> GetCategoriasProductos();
    }
}
