using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;
using PagedList.Core;
using System.Collections.Generic;
using System.Linq;
using Transversal.Common.Parameters;

namespace Domain.Core
{
    public class CategoriasDomain : ICategoriasDomain
    {
        private readonly ICategoriasRepository categoriasRepository;

        public CategoriasDomain(ICategoriasRepository categoriasRepository)
        {
            this.categoriasRepository = categoriasRepository;
        }

        public IEnumerable<Categorias> GetCategoriasProductos()
        {
            return categoriasRepository.GetCategoriasProductos();
        }

        public IEnumerable<Categorias> GetCategorias(string parameters)
        {
            //return categoriasRepository.GetCategorias(orderBy);
            var categorias = categoriasRepository.GetCategorias(parameters);
            List<Categorias> categorias1 = categorias.ToList();
            return categorias;
        }

        public PagedList<Categorias> GetCategories(CategoriesParameters parameters)
        {
            return categoriasRepository.GetCategories(parameters);
        }
    }
}
