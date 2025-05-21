using Domain.Contracts;
using Domain.Entities;
using Shared;

namespace Services.Specifications;

public class ProductWithBrandAndTypeSpecification: Specifications<Product>
{
    public ProductWithBrandAndTypeSpecification(int id):base(product =>product.Id == id )
    {
        AddInclude(product =>product.Brand );
        AddInclude(product =>product.Type);
    }

    public ProductWithBrandAndTypeSpecification(ProductParametersSpecification parametersSpecification)
        :base(product=>(!parametersSpecification.BrandId.HasValue||parametersSpecification.BrandId==product.BrandId)
                       &&(!parametersSpecification.TypeId.HasValue||parametersSpecification.TypeId==product.TypeId)
        &&(string.IsNullOrWhiteSpace(parametersSpecification.Search)||product.Name.ToLower().Contains(parametersSpecification.Search.ToLower())))
    {
        AddInclude(product =>product.Brand );
        AddInclude(product =>product.Type);
        if (parametersSpecification.Sort is not null)
        {
            switch (parametersSpecification.Sort)
            {
                case ProductSortOptions.PriceAsc:
                    SetOrderyBy(price=>price.Price);
                    break;
                case ProductSortOptions.PriceDesc:
                    SetOrderByDescending(price=>price.Price);
                    break;
                case ProductSortOptions.NameAsc:
                    SetOrderyBy(name=>name.Name);
                    break;
              default:
                    SetOrderByDescending(name=>name.Name);
                    break;
            }
        }
        ApplyPagination(parametersSpecification.PageIndex,parametersSpecification.PageSize);
    }
}