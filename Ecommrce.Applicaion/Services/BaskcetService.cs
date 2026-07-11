using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.Contracts;
using ECommerce.Application.DTOs.BasketDtos;
using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class BaskcetService : IBaskcetService

    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BaskcetService(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<Result<BasketDto>> CreateOrUpdateBasket(BasketDto basket, TimeSpan? TLV = null, CancellationToken ct = default)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(basket);
            var basketresult=await _basketRepository.CreateOrUpdateBasketAsync(customerBasket, TLV);
            return basketresult == null ? Result<BasketDto>.Fail(Erorr.Failure("Faild to create or Update")) : Result<BasketDto>.Ok(basket);
        }

        public async Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken ct = default)
        {
            var result=await _basketRepository.DeleteBasketAsync(id, ct);
            return result ? Result<bool>.Ok(true) : Result<bool>.Fail(Erorr.Failure("Faild to Delete Basket"));        }

        public async Task<Result<BasketDto>> GetBasketAsync(string id, CancellationToken ct = default)
        {
            var basket =await _basketRepository.GetBasketAsync(id, ct);
            return basket == null ? Result<BasketDto>.Fail(Erorr.Failure("failed to get basket"))
                : Result<BasketDto>.Ok(_mapper.Map<BasketDto>(basket));
 
                }
    }
}
