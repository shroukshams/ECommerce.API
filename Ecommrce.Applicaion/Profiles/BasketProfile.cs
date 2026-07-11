using AutoMapper;
using ECommerce.Application.DTOs.BasketDtos;
using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();
            
            CreateMap<BasketItems, BasketItemDto>().ReverseMap();
        }
    }
    }

