using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly DataContext _dataContext;

        public ProductosRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Productos> GetAllProducts()
        {
            return _dataContext.Productos.Include(c => c.Categorias);
        }

        public Productos Get(int Id)
        {
            return _dataContext.Productos.Find(Id);
        }

        public void SaveProduct(Productos producto)
        {
            _dataContext.Productos.Add(producto);
            //_dataContext.Entry(producto.Categorias).State = EntityState.Detached;
            _dataContext.SaveChanges();
        }

        public void DeleteProduct(Productos producto)
        {
            _dataContext.Productos.Remove(producto);
        }

        public void UpdateProduct(Productos producto)
        {
            _dataContext.Productos.Update(producto);
        }
    }
}
