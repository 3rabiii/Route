using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ServicesAbstraction;
using Shared;

namespace Services;

public class ServiceMangger : IServiceMangger
{
    private readonly Lazy<IProductServices> _productSercie;
    private readonly Lazy<IBasketServices> _basketSercie;
    private readonly Lazy<IAuthnticationServices> _authnticationSercie;
    public ServiceMangger(IUnitOfWork unitOfWork,IMapper mapper,IBasketRepository basketRepository,UserManager<User>  userManager,IOptions<JwtOptions>jwtOptions)
    {
        _productSercie = new Lazy<IProductServices>(() => new ProductServices(unitOfWork, mapper));
        _basketSercie = new Lazy<IBasketServices>(() => new Basketservices(basketRepository, mapper));
        _authnticationSercie = new Lazy<IAuthnticationServices>(()=>new AuthenticationServices(userManager,jwtOptions));
    }

    public IProductServices ProductServices => _productSercie.Value;
    public IBasketServices BasketServices => _basketSercie.Value;
    public IAuthnticationServices AuthnticationServices => _authnticationSercie.Value;
}