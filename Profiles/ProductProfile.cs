using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using pedido_plus_backend.Dtos.Product;
using pedido_plus_backend.Models;

namespace pedido_plus_backend.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name).ToList()));
            CreateMap<CreateProductDto, Product>();
        }
    }
}