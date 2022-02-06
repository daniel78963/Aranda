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
    }
}
