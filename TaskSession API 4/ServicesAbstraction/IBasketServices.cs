using Shared;

namespace ServicesAbstraction;

public interface IBasketServices
{
    public Task<CustomerBasketDto?> GetBasketAync(string Id);
    public Task<CustomerBasketDto?> UpdateBasketAsync(CustomerBasketDto basket);
    public Task<bool> DeleteBasketAsync(string Id);
}