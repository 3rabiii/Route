using Domain.Contracts;
using Domain.Entities;
using Shared.ProductDtos;

namespace Services.Specifications
{
    public class ProductwithFilterSpecification : Specification<Product> 
    {
        public ProductwithFilterSpecification(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
        public ProductwithFilterSpecification(ProductSpecificationParams specs)
            : base(product => (!specs.BrandId.HasValue || product.BrandId == specs.BrandId) &&
                              (!specs.TypeId.HasValue || product.TypeId == specs.TypeId) &&
                              (string.IsNullOrWhiteSpace(specs.Search) || product.Name.ToLower().Contains(specs.Search.ToLower().Trim())))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);

            ApplyPagination(specs.pageIndex, specs.PageSize);
            if (specs.Sort is not null)
            {
                switch (specs.Sort)
                {
                    case SortingOptions.NameAsc:
                        SetOrderBy(product => product.Name);
                        break;
                    case SortingOptions.NameDesc:
                        SetOrderByDecsending(product => product.Name);
                            break;
                    case SortingOptions.PriceAsc:
                        SetOrderBy(product => product.Price);
                            break;
                    case SortingOptions.PriceDesc:
                        SetOrderByDecsending(product => product.Price);
                            break;
                    default:
                        SetOrderBy(product => product.Name);
                        break;
                }
            }
        }
    }
}
