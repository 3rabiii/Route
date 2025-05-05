using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.ProductDtos;

namespace Services.Abstractions
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductResultDto>> GetAllProductsAsync();
        Task<ProductResultDto> GetProductByIdAsync(int id);
        Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
        Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();

    }
}
