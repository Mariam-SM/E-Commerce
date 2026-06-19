using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Mapping;
using Talabat.Application.Services;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Domain.Contracts.Persitstence;
using Talabat.Infrastructure.Cache;

namespace Talabat.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Add AutoMapper

                    services.AddAutoMapper(cfg =>
                    {
                        cfg.AddProfile<MappingProfile>();
                    }, typeof(MappingProfile).Assembly);

            #endregion

            services.AddScoped(typeof(Func<IProductService>), serviceProvider =>
            {
                var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
                var mapper = serviceProvider.GetRequiredService<IMapper>();

                return () => new ProductService(unitOfWork, mapper);
            });

            services.AddScoped(typeof(Func<IBasketService>), serviceProvider =>
            {
                var basketRepo = serviceProvider.GetRequiredService<IBasketDBRepoistory>();
                var mapper = serviceProvider.GetRequiredService<IMapper>();
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                return () => new BasketService(basketRepo, mapper, configuration);
            });

            services.AddScoped(typeof(Func<ICacheService>), serviceProvider =>
            {
                var cacheRepository = serviceProvider.GetRequiredService<ICacheRepository>();

                return () => new CacheService(cacheRepository);
            });

            services.AddScoped<IServiceManager, ServiceManager>();

            return services;
        }
    }

}
