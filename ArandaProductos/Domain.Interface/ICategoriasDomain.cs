using Domain.Entity;
using PagedList.Core;
using System.Collections.Generic;
using Transversal.Common.Parameters;

namespace Domain.Interface
{
    public interface ICategoriasDomain
    {
        IEnumerable<Categorias> GetCategoriasProductos();
        IEnumerable<Categorias> GetCategorias(string parameters);
        PagedList<Categorias> GetCategories(CategoriesParameters parameters);
    }
}
