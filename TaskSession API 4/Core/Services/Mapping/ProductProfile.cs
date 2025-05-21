using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.Mapping;

public class ProductProfile: Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResultDto>()
            .ForMember(p => p.BrandName, p => p.MapFrom(n => n.Brand.Name))
            .ForMember(p => p.TypeName, p => p.MapFrom(t => t.Type.Name))
            .ForMember(p => p.PictureUrl, p => p.MapFrom<PictureUrlResolver>());
        CreateMap<ProductBrand, BrandResultDto>();
        CreateMap<ProductType, ProductTypeResultDto>();
    }
}