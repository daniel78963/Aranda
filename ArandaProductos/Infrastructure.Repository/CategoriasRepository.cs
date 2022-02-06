using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly DataContext dataContext;

        public CategoriasRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Categorias> GetCategoriasProductos()
        {
            return dataContext.Categorias;
        }
    }
}
