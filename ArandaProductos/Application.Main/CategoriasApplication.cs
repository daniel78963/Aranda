using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using Transversal.Common;

namespace Application.Main
{
    public class CategoriasApplication : ICategoriasApplication
    {
        private readonly ICategoriasDomain categoriasDomain;
        private readonly IMapper mapper;

        public CategoriasApplication(ICategoriasDomain categoriasDomain, IMapper mapper)
        {
            this.categoriasDomain = categoriasDomain;
            this.mapper = mapper;
        }

        public Response<IEnumerable<CategoriasDto>> GetCategoriasProductos()
        {
            var response = new Response<IEnumerable<CategoriasDto>>();
            try
            {
                var categorias = categoriasDomain.GetCategoriasProductos();
                response.Data = mapper.Map<IEnumerable<CategoriasDto>>(categorias);
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
