using System.Security.AccessControl;

namespace Shared;

public class ProductParametersSpecification
{
    private const int MaxPageSize = 10;
    private const int DefaultPageSize = 5;
    public ProductSortOptions? Sort {get;set;}
    public int? BrandId{get;set;}
    public int? TypeId{get;set;}
    public int PageIndex { get; set; } = 1;
    private int _pageSize=DefaultPageSize;
    public string? Search {get;set;}

    public int PageSize
    {
        get { return _pageSize; }
        set
        {
            _pageSize=value>MaxPageSize?MaxPageSize:value;
        }
    }

}

public enum ProductSortOptions
{
    PriceAsc,
    PriceDesc,
    NameAsc,
    NameDesc
}