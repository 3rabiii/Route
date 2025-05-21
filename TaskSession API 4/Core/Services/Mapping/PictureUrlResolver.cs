using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shared;

namespace Services.Mapping;

public class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product,ProductResultDto,string>
{
    public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.PictureUrl)) return string.Empty;
        return $"{_configuration["BaseUrl"]}{source.PictureUrl}";
    }
}