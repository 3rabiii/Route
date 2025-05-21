namespace Shared;

public record CustomerBasketDto
{
    public string Id { get; init; }
    public IEnumerable<ItemBasketDto> Items { get; init; }
}