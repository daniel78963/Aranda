using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transversal.Common;

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

        public Productos Get(int Id)
        {
            return productosRepository.Get(Id);
        }

        public void Add(Productos producto)
        {
            productosRepository.Add(producto);
        }

        public void AddValidation(Productos producto)
        {
            productosRepository.AddValidate(producto);
        }

        public async Task<Response<bool>> AddAsync(Productos producto)
        {
            var response = new Response<bool>();
            try
            {
                bool valid = await productosRepository.AddAsync(producto);
                if (valid)
                {
                    response.IsSuccess = true;
                    response.StatusCode = 200;
                    response.Code = "1200";
                    response.Message = "Registro Exitoso";
                }
            }
            catch (DbUpdateException ex)
            {
                response.StatusCode = 400;
                if (ex.InnerException.Message.Contains("FOREIGN") && ex.InnerException.Message.Contains("Categorias"))
                {
                    response.Code = "1420";
                    response.Message = "La Categoria no es valida";
                    return response;
                }
                response.Code = "1430";
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Code = "1450";
                response.Message = "Error guardando";
            }
            return response;
        }

        public async Task<bool> UpdateAsync(Productos producto)
        {
            return await productosRepository.UpdateAsync(producto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = productosRepository.Get(id);
            return await productosRepository.DeleteAsync(producto);
        }

    }
}
