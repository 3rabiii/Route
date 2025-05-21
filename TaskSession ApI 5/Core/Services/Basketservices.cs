using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using ServicesAbstraction;
using Shared;

namespace Services;

public class Basketservices(IBasketRepository _basketRepository,IMapper _mapper): IBasketServices
{
    public async Task<CustomerBasketDto?> GetBasketAync(string Id)
    {
        var CusomterBasket = await _basketRepository.GetBasketAsync(Id);
        return CusomterBasket is not null?_mapper.Map<CustomerBasketDto>(CusomterBasket):throw new BasketNotFound(Id);
    }

    public async Task<CustomerBasketDto?> UpdateBasketAsync(CustomerBasketDto basket)
    {
        var CustomerBasket= await _basketRepository.UpdateBasketAsync(_mapper.Map<CustomerBasket>(basket));
        return CustomerBasket is not null? _mapper.Map<CustomerBasketDto>(CustomerBasket):throw new Exception();
    }

    public async Task<bool> DeleteBasketAsync(string Id) 
        => await _basketRepository.DeleteBasketAsync(Id);
}