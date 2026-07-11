using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.DTOs.BasketDtos
{
    public class BasketDto
    {
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } 
    }
}
