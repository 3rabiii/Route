using Domain.Contracts;
using Domain.Entities;
using Shared;

namespace Services.Specifications;

public class ProductsCountSpecifications : Specifications<Product>
{
    public ProductsCountSpecifications(ProductParametersSpecification parametersSpecification)
        :base(product=>(!parametersSpecification.BrandId.HasValue||parametersSpecification.BrandId==product.BrandId) 
                       &&(!parametersSpecification.TypeId.HasValue||parametersSpecification.TypeId==product.TypeId)
            &&(string.IsNullOrWhiteSpace(parametersSpecification.Search)||product.Name.ToLower().Contains(parametersSpecification.Search.ToLower())))
    {
    }
}