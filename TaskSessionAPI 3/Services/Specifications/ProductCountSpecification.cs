using Domain.Contracts;
using Domain.Entities;
using Shared.ProductDtos;

namespace Services.Specifications
{
    public class ProductCountSpecification : Specification<Product>
    {
        public ProductCountSpecification(ProductSpecificationParams specs)
           : base(product => (!specs.BrandId.HasValue || product.BrandId == specs.BrandId) &&
                             (!specs.TypeId.HasValue || product.TypeId == specs.TypeId) &&
                             (string.IsNullOrWhiteSpace(specs.Search) || product.Name.ToLower().Contains(specs.Search.ToLower().Trim())))
        {

        }
    }
}
