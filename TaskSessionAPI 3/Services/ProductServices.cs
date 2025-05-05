using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstractions;
using Services.Specifications;
using Shared;
using Shared.ProductDtos;

namespace Services
{
    public class ProductServices(IUnitOfWork unitOfWork, IMapper mapper) : IProductServices
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        //public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var mappedBrands = mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return mappedBrands;
        }

        public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParams specification)
        {
            var specs = new ProductwithFilterSpecification(specification);
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(specs);
            var countSpecs = new ProductCountSpecification(specification);
            var totalCount = await unitOfWork.GetRepository<Product, int>().CountAsync(countSpecs);
            var mappedProducts = mapper.Map<IEnumerable<ProductResultDto>>(products);
            return new PaginatedResult<ProductResultDto>(specification.pageIndex, specification.PageSize, totalCount, mappedProducts);
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var mappedTypes = mapper.Map<IEnumerable<TypeResultDto>>(types);
            return mappedTypes;
        }

        public async Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            var specs = new ProductwithFilterSpecification(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(specs);
            var mappedProduct = mapper.Map<ProductResultDto>(product);
            return mappedProduct;
        }
    }
}
