using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<Productos> GetAsync(int Id)
        {
            return await productosRepository.GetAsync(Id);
        }

        public void Add(Productos producto)
        {
            productosRepository.Add(producto);
        }

        public async Task<bool> UpdateAsync(Productos producto)
        {
            return await productosRepository.UpdateAsync(producto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await productosRepository.GetAsync(id);
            return await productosRepository.DeleteAsync(producto);
        }

    }
}
