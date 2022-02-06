using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;
using System.Collections.Generic;

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
    }
}
