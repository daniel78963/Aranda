using Application.Dto;
using Application.Interface;
using AutoMapper;
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
    }
}
