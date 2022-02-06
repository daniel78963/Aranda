using Application.Dto;
using AutoMapper;
using Domain.Entity;

namespace Transversal.Common.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Productos, ProductosDto>().ReverseMap();
            CreateMap<Categorias, CategoriasDto>().ReverseMap();
        }
    }
}
