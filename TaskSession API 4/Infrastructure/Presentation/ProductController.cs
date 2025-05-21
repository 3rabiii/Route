using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction;
using Shared;

namespace Presentation;
[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class ProductController(IServiceMangger _serviceMangger): ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ProductResultDto>> GetAllProducts([FromQuery]ProductParametersSpecification parametersSpecification)
    {
        var products = await _serviceMangger.ProductServices.GetAllProductsAsync(parametersSpecification);
        return Ok(products);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<BrandResultDto>> GetAllBrands()
    {
        var brands = await _serviceMangger.ProductServices.GetAllBrandsAsync();
        return Ok(brands);
    }
    [HttpGet("types")]
    public async Task<ActionResult<ProductTypeResultDto>> GetAllTypes()
    {
        var types = await _serviceMangger.ProductServices.GetAllProductTypesAsync();
        return Ok(types);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResultDto>> GetProduct(int id)
    {
        var product = await _serviceMangger.ProductServices.GetProductByIdAsync(id);
        return Ok(product);
    }
    
    
    
}