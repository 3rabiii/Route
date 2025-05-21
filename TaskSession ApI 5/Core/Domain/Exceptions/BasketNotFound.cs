namespace Domain.Exceptions;

public sealed class BasketNotFound:NotFoundException
{
    public BasketNotFound(string Id) : base($"The  basket with id: {Id} was not found")
    {
    }
}