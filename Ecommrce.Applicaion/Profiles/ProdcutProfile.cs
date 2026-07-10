using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domin.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Profiles
{
    public class ProdcutProfile:Profile
    {
        public ProdcutProfile()
        {

            CreateMap<Product, ProductDto>()
       .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
       .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));
            
            CreateMap<ProductBrand, BrandDto>().ReverseMap();
            CreateMap<ProductType, TypeDto>().ReverseMap();
        }
    }
}
