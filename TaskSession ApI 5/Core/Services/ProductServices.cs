using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Services.Specifications;
using ServicesAbstraction;
using Shared;

namespace Services;
public class ProductServices(IUnitOfWork _unitOfWork,IMapper _mapper): IProductServices
{
    public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductParametersSpecification parametersSpecification)
    {
        var poducts = await _unitOfWork.GetRepository<Product, int>()
            .GetAllAsync(new ProductWithBrandAndTypeSpecification(parametersSpecification));
        var totalProductsCount = await _unitOfWork.GetRepository<Product, int>()
            .CountAsync(new ProductsCountSpecifications(parametersSpecification));
        var result1 = _mapper.Map<IEnumerable<ProductResultDto>>(poducts);
        var result2 = new PaginatedResult<ProductResultDto>(
            //parametersSpecification.PageSize,
            result1.Count(),
            parametersSpecification.PageIndex,
           totalProductsCount,
            result1
        );
        return result2;
    }
 
    public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
    {
        var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
        var result= _mapper.Map<IEnumerable<BrandResultDto>>(brands);
        return result;
    }

    public async Task<IEnumerable<ProductTypeResultDto>> GetAllProductTypesAsync()
    {
        var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
        var result = _mapper.Map<IEnumerable<ProductTypeResultDto>>(types);
        return result;
    }

    public async Task<ProductResultDto> GetProductByIdAsync(int id)
    {
        var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(new ProductWithBrandAndTypeSpecification(id));
        return product is null ? throw new ProductNotFound(id): _mapper.Map<ProductResultDto>(product);
    }
}