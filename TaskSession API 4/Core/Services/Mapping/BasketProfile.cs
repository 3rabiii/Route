using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.Mapping;

public class BasketProfile:Profile
{
    public BasketProfile()
    {
        CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
        CreateMap<ItemBasket, ItemBasketDto>().ReverseMap();
    }
}