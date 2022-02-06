using Domain.Entity;
using System.Collections.Generic;

namespace Infrastructure.Interface
{
    public interface ICategoriasRepository
    {
        IEnumerable<Categorias> GetCategoriasProductos();
    }
}
