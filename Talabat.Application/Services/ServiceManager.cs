using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.Application.Abstraction.Services;
using Talabat.Domain.Contracts.Persitstence;

namespace Talabat.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;

        public ServiceManager(Func<IProductService> ProductFactory ,Func<IBasketService> BasketFactory)
        {
            //_productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
            _productService = new Lazy<IProductService>(ProductFactory);
            _basketService = new Lazy<IBasketService> (BasketFactory);
        }


        //public IProductService ProductService => _productService.Value;
        public IProductService ProductService => _productService.Value;
        public IBasketService BasketService => _basketService.Value;
    }
}
