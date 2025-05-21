namespace ServicesAbstraction;

public interface IServiceMangger
{
    IProductServices ProductServices { get; }
    IBasketServices BasketServices { get; }
    IAuthnticationServices AuthnticationServices { get; }
}