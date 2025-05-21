namespace Domain.Exceptions;

public class ProductNotFound:  NotFoundException
{
    public ProductNotFound(int id) : base($"Prodcut with id  {id} was not found")
    {
    }
}