using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using PagedList.Core; 
using System.Collections.Generic;
using Transversal.Common.Parameters;

namespace Infrastructure.Repository
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly DataContext dataContext;
        private readonly ISortHelper<Categorias> sortHelper;

        public CategoriasRepository(DataContext dataContext, ISortHelper<Categorias> sortHelper)
        {
            this.dataContext = dataContext;
            this.sortHelper = sortHelper;
        }

        public IEnumerable<Categorias> GetCategoriasProductos()
        {
            return dataContext.Categorias;
        }

        public IEnumerable<Categorias> GetCategorias(string parameters)
        {
            var cateogrias = dataContext.Categorias;
            return sortHelper.ApplySort(cateogrias, parameters);
        }

        public PagedList<Categorias> GetCategories(CategoriesParameters parameters)
        {
            var cateogrias = dataContext.Categorias;
            var sorted = sortHelper.ApplySort(cateogrias, parameters.OrderBy);
            return null;
        }
    }
}
