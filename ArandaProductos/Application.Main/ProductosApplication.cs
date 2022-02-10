using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Response<bool> Add(ProductosDto productosDto)
        {
            var response = new Response<bool>();
            try
            {
                var producto = mapper.Map<Productos>(productosDto);
                productosDomain.Add(producto);
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

        public Response<bool> AddValidation(ProductosDto productosDto)
        {
            var response = new Response<bool>();
            try
            {
                var producto = mapper.Map<Productos>(productosDto);
                productosDomain.AddValidation(producto);
                //response.Data
                response.IsSuccess = true;
                response.StatusCode = 200;
                response.Code = "200";
                response.Message = "Registro Exitoso";
            }
            catch (DbUpdateException ex)
            {
                response.StatusCode = 400;
                response.Code = "400";
                if (ex.InnerException.Message.Contains("FOREIGN") && ex.InnerException.Message.Contains("Categorias"))
                {
                    response.Message = "La Categoria no es valida";
                    return response;
                }
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Code = "400";
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> AddAsync(ProductosDto productosDto)
        {
            bool valid = await Validate(productosDto);
            if (!valid)
            {
                var response = new Response<bool>();
                response.StatusCode = 400;
                response.Code = "1430";
                response.Message = "Campos invalidos";
                return response;
            }

            try
            {
                var producto = mapper.Map<Productos>(productosDto);
                return await productosDomain.AddAsync(producto);
            }
            catch (Exception ex)
            {
                var response = new Response<bool>();
                response.StatusCode = 400;
                response.Code = "400";
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<Response<bool>> UpdateAsync(ProductosDto productoDto)
        {
            var response = new Response<bool>();
            try
            {
                var producto = mapper.Map<Productos>(productoDto);
                response.Data = await productosDomain.UpdateAsync(producto);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await productosDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<ProductosDto> Get(int id)
        {
            var respose = new Response<ProductosDto>();
            try
            {
                var producto = productosDomain.Get(id);
                respose.Data = mapper.Map<ProductosDto>(producto);
                if (respose.Data != null)
                {
                    respose.IsSuccess = true;
                    respose.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                respose.Message = e.Message;
            }
            return respose;
        }

        public Response<IEnumerable<ProductosDto>> GetProducts(string parameters)
        {
            var response = new Response<IEnumerable<ProductosDto>>();
            try
            {
                var productos = productosDomain.GetProducts(parameters);
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

        private async Task<bool> Validate(ProductosDto productosDto)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(productosDto.Nombre))
                valid = false;

            return valid;
        }

        public async Task<Response<List<Error>>> ValidateObjetc(ProductosDto productosDto)
        {
            Response<List<Error>> response = new Response<List<Error>>();
            List<Error> errores = new List<Error>();

            if (string.IsNullOrEmpty(productosDto.Nombre))
            {
                response.IsSuccess = false;
                Error error = new Error()
                {
                    Code = "1410",
                    Message = "El campo Nombre es obligatorio"
                };
                errores.Add(error);
            }

            if (string.IsNullOrEmpty(productosDto.Descripcion))
            {
                response.IsSuccess = false;
                Error error = new Error()
                {
                    Code = "1411",
                    Message = "El campo Descripción es obligatorio"
                };
                errores.Add(error);
            }

            if (productosDto.Nombre != null && productosDto.Nombre.Length < 2)
            {
                Error error = new Error()
                {
                    Code = "1416",
                    Message = "El campo Nombre no es valido"
                };
                errores.Add(error);
            }

            if (errores.Count > 1)
            {
                response.IsSuccess = false;
                response.StatusCode = 400;
                response.Message = "Multiples errores";
                response.Code = "1440";
                response.Data = errores;
                return response;
            }

            if (errores.Any())
            { 
                response.IsSuccess = false;
                response.StatusCode = 400;
                response.Message = errores.FirstOrDefault().Message;
                response.Code = errores.FirstOrDefault().Code;
                return response;
            }

            response.IsSuccess = true;
            return response;
        }

    }
}
