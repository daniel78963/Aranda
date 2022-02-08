using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public Productos Get(int id)
        {
            //return await dataContext.Set<Productos>()
            //  .AsNoTracking()
            //  .Include(p=>p.Categorias)
            //  .FirstOrDefaultAsync(e => e.ProductoId == id);
            //return await dataContext.Productos.Include(c => c.Categorias).FirstOrDefaultAsync(e => e.ProductoId == id );
            //return await dataContext.Productos.Include("Productos.Categorias").FirstOrDefaultAsync(e => e.ProductoId == id);

            //IEnumerable<Productos> pds = this.dataContext.Productos
            //     .Include(o => o.Categorias)
            //      .Where(o => o.ProductoId == id);

            //return await dataContext.Productos.Include(c => c.Categorias).FirstOrDefaultAsync(e => e.ProductoId == id);
            return this.dataContext.Productos.Include(o => o.Categorias).FirstOrDefault(e => e.ProductoId == id);
        }

        public void Add(Productos producto)
        {
            dataContext.Productos.Add(producto);
            //dataContext.Entry(producto.Categorias).State = EntityState.Detached;
            dataContext.SaveChanges();
        }

        public void AddValidate(Productos producto)
        {
            //try
            {
                dataContext.Productos.Add(producto);
                //dataContext.Entry(producto.Categorias).State = EntityState.Detached;
                dataContext.SaveChanges();
            }
            //catch (System.Exception ex)
            //{
            //    int p = 0;
            //    //Sa 
            //    //throw;
            //} 
        }

        public async Task<bool> AddAsync(Productos producto)
        {
            dataContext.Productos.Add(producto);
            return await SaveAllAsync();
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
