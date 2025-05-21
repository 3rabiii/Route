using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction;
using Shared;

namespace Presentation;
[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class BasketController(IServiceMangger serviceMangger):ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerBasketDto>> Get(string id)
    {
        var CustomerBasket = await serviceMangger.BasketServices.GetBasketAync(id);
        return Ok(CustomerBasket);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasketDto>> Post(CustomerBasketDto basket)
    {
        var result = await serviceMangger.BasketServices.UpdateBasketAsync(basket);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
       await serviceMangger.BasketServices.DeleteBasketAsync(id);
        return NoContent();
    }
}