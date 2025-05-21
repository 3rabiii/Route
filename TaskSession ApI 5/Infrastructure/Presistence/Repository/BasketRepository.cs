using System.Text.Json;
using Domain.Contracts;
using Domain.Entities;
using StackExchange.Redis;

namespace Presistence.Repository;

public class BasketRepository(IConnectionMultiplexer connectionMultiplexer) : IBasketRepository
{
    private readonly IDatabase _connectionMultiplexer = connectionMultiplexer.GetDatabase();

    public async Task<CustomerBasket?> GetBasketAsync(string id)
    {
        var value= await _connectionMultiplexer.StringGetAsync(id);
        if (value.IsNullOrEmpty) return null;
        return JsonSerializer.Deserialize<CustomerBasket>(value);
    }

    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket, TimeSpan? timeout = null)
    {
       var jsonValue= JsonSerializer.Serialize(basket);
       return await _connectionMultiplexer.StringSetAsync(basket.Id,jsonValue, timeout??TimeSpan.FromDays(10))
           ?await GetBasketAsync(basket.Id):null;
    }

    public Task<bool> DeleteBasketAsync(string id)
       => _connectionMultiplexer.KeyDeleteAsync(id);
    
}