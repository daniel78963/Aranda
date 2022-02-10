using Domain.Entity;
using PagedList.Core;
using System.Collections.Generic;
using Transversal.Common.Parameters;

namespace Infrastructure.Interface
{
    public interface ICategoriasRepository
    {
        IEnumerable<Categorias> GetCategoriasProductos(); 
        IEnumerable<Categorias> GetCategorias(string parameters);
        PagedList<Categorias> GetCategories(CategoriesParameters parameters);


    }
}
