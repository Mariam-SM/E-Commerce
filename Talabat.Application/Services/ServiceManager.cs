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
        private readonly Lazy<ICacheService> _cacheService;

        public ServiceManager(Func<IProductService> ProductFactory ,Func<IBasketService> BasketFactory , Func<ICacheService> CacheFactory)
        {
            //_productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
            _productService = new Lazy<IProductService>(ProductFactory);
            _basketService = new Lazy<IBasketService> (BasketFactory);
            _cacheService = new Lazy<ICacheService>(CacheFactory);
        }


        //public IProductService ProductService => _productService.Value;
        public IProductService ProductService => _productService.Value;
        public IBasketService BasketService => _basketService.Value;

        public ICacheService CacheService => _cacheService.Value;
    }
}
