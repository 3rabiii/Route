using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.ProductDtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController(IServiceManager serviceManager) : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProducts()
        {
            var products = await serviceManager.ProductServices.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
        {
            var types = await serviceManager.ProductServices.GetAllTypesAsync();
            return Ok(types);
        }

        [HttpGet]
        public async Task<ActionResult<ProductResultDto>> GetProduct(int id)
        {
            var product = await serviceManager.ProductServices.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
        {
            var brands = await serviceManager.ProductServices.GetAllBrandsAsync();
            return Ok(brands);
        }

    }
}
