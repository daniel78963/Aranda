using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;
using System.Collections.Generic;

namespace Domain.Core
{
    public class ProductosDomain : IProductosDomain
    {
        private readonly IProductosRepository productosRepository;
        private readonly ICategoriasRepository categoriasRepository;

        public ProductosDomain(IProductosRepository productosRepository, ICategoriasRepository categoriasRepository)
        {
            this.productosRepository = productosRepository;
            this.categoriasRepository = categoriasRepository;
        }

        public IEnumerable<Productos> GetProductos()
        {
            return productosRepository.GetAllProducts();
        }
    }
}
