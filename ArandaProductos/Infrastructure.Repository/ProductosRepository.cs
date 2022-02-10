using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common.Parameters;

namespace Infrastructure.Repository
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly DataContext dataContext;
        private readonly ISortHelper<Productos> sortHelper;

        public ProductosRepository(DataContext dataContext, ISortHelper<Productos> sortHelper)
        {
            this.dataContext = dataContext;
            this.sortHelper = sortHelper;
        }

        public IEnumerable<Productos> GetAllProducts()
        {
            return dataContext.Productos.Include(c => c.Categorias);
        }

        public Productos Get(int id)
        {
            return this.dataContext.Productos.Include(o => o.Categorias).FirstOrDefault(e => e.ProductoId == id);
        }

        public IEnumerable<Productos> GetProducts(string parameters)
        {
            var productos = dataContext.Productos;
            return sortHelper.ApplySort(productos, parameters);
        }

        public IEnumerable<Productos> GetProducts(string filters, string parameters)
        {
            var productos = dataContext.Productos;
            return sortHelper.ApplySort(productos, parameters);
        }

        public IEnumerable<Productos> GetProductsFilters(ProductsParameters parameters)
        {
            var productos = dataContext.Productos.AsQueryable();

            var orderQueryBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(parameters.Nombre) && !string.IsNullOrEmpty(parameters.Descripcion) && !string.IsNullOrEmpty(parameters.Categoria))
            {
                productos = dataContext.Productos.Include(o => o.Categorias)
                            .Where(p => p.Nombre.Contains(parameters.Nombre)
                            && p.Descripcion.Contains(parameters.Descripcion)
                            && p.Categorias.NombreCategoria.Contains(parameters.Categoria));
            }
            else if (!string.IsNullOrEmpty(parameters.Nombre) && !string.IsNullOrEmpty(parameters.Descripcion))
            {
                productos = dataContext.Productos.Include(o => o.Categorias)
                            .Where(p => p.Nombre.Contains(parameters.Nombre)
                            && p.Descripcion.Contains(parameters.Descripcion));
            }
            else if (!string.IsNullOrEmpty(parameters.Nombre) && !string.IsNullOrEmpty(parameters.Categoria))
            {
                productos = dataContext.Productos.Include(o => o.Categorias)
                            .Where(p => p.Nombre.Contains(parameters.Nombre)
                            && p.Categorias.NombreCategoria.Contains(parameters.Categoria));
            }
            else if (!string.IsNullOrEmpty(parameters.Nombre))
            {
                productos = dataContext.Productos.Include(o => o.Categorias).Where(p => p.Nombre.Contains(parameters.Nombre));
            }
            else if (!string.IsNullOrEmpty(parameters.Descripcion))
            {
                productos = dataContext.Productos.Include(o => o.Categorias).Where(p => p.Descripcion.Contains(parameters.Descripcion));
            }
            else if (!string.IsNullOrEmpty(parameters.Categoria))
            {
                productos = dataContext.Productos.Include(o => o.Categorias).Where(p => p.Categorias.NombreCategoria.Contains(parameters.Categoria));
            }

            return sortHelper.ApplySort(productos, parameters.OrderBy);
        }

        public void Add(Productos producto)
        {
            dataContext.Productos.Add(producto);
            dataContext.SaveChanges();
        }

        public void AddValidate(Productos producto)
        {
            dataContext.Productos.Add(producto);
            dataContext.SaveChanges();
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
