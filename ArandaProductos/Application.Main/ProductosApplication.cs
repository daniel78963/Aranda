using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using Transversal.Common;

namespace Application.Main
{
    public class ProductosApplication : IProductosApplication
    {
        private readonly IProductosDomain productosDomain;
        private readonly IMapper mapper;

        public ProductosApplication(IProductosDomain productosDomain, IMapper mapper)
        {
            this.productosDomain = productosDomain;
            this.mapper = mapper;
        }

        public Response<IEnumerable<ProductosDto>> GetProductos()
        {
            var response = new Response<IEnumerable<ProductosDto>>();
            try
            {
                var productos = productosDomain.GetProductos();
                response.Data = mapper.Map<IEnumerable<ProductosDto>>(productos);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Guardar(ProductosDto productosDto)
        {
            var response = new Response<bool>();
            try
            {
                var producto = mapper.Map<Productos>(productosDto);
                productosDomain.SaveProduct(producto);
                //response.Data
                response.IsSuccess = true;
                response.Message = "Registro Exitoso";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
