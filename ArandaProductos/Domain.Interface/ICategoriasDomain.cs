using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Interface
{
    public interface ICategoriasDomain
    {
        IEnumerable<Categorias> GetCategoriasProductos();
    }
}
