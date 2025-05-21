using Shared;

namespace ServicesAbstraction;

public interface IProductServices
{
    Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductParametersSpecification parametersSpecification);
    Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
    Task<IEnumerable<ProductTypeResultDto>> GetAllProductTypesAsync();
    Task<ProductResultDto> GetProductByIdAsync(int id);
}