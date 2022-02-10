using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using PagedList.Core;
//using PagedList;
//using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
            var cateogriasOrdered = dataContext.Categorias.OrderBy("NombreCategoria descending");
            List<Categorias> categoriasEnded = cateogriasOrdered.ToList();
            var sorted = sortHelper.ApplySort(cateogrias, parameters);
            List<Categorias> categoriasEndedShort = sorted.ToList();

        //    PagedList<Categorias>.ToPagedList(sortedOwners,
        //ownerParameters.PageNumber,
        //ownerParameters.PageSize);


            //return dataContext.Categorias;
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
