using ECommerce.Application.Common;
using ECommerce.Application.DTOs.BasketDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Contracts
{
    public interface IBaskcetService
    {Task <Result<BasketDto>> GetBasketAsync (string id,CancellationToken ct=default);
    {Task<Result<BasketDto>> CreateOrUpdateBasket(BasketDto basket,TimeSpan?TLV=default ,CancellationToken ct = default);  
        Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken ct = default);

    }
}
