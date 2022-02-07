using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly DataContext dataContext;

        public ProductosRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Productos> GetAllProducts()
        {
            return dataContext.Productos.Include(c => c.Categorias);
        }

        public async Task<Productos> GetAsync(int id)
        {
            return await dataContext.Set<Productos>()
              .AsNoTracking()
              .FirstOrDefaultAsync(e => e.ProductoId == id);
        }

        public void Add(Productos producto)
        {
            dataContext.Productos.Add(producto);
            //dataContext.Entry(producto.Categorias).State = EntityState.Detached;
            dataContext.SaveChanges();
        }

        public async Task<bool> DeleteAsync(Productos producto)
        {
            dataContext.Productos.Remove(producto);
            return await SaveAllAsync();
        }

        public async Task<bool> UpdateAsync(Productos producto)
        {
            dataContext.Productos.Update(producto);
            return await SaveAllAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
