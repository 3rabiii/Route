using System.ComponentModel.DataAnnotations;

namespace Shared;

public record ItemBasketDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    [Range(1, 100)]
    public int Quantity { get; init; }
    public string PictureUrl { get; init; }
    [Range(1, double.MaxValue)]
    public decimal Price { get; init; }
    public string Brand { get; init; }
    public string Category { get; init; }
}