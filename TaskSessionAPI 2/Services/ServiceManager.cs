using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductServices> _productServices;
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productServices = new Lazy<IProductServices>(() => new ProductServices(unitOfWork, mapper));
        }
        public IProductServices ProductServices => _productServices.Value;
    }
}
