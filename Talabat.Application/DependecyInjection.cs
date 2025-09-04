using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Mapping;
using Talabat.Application.Services;

namespace Talabat.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add AutoMapper
            // auto mapper version 11 : 14
            //services.AddAutoMapper(typeof(MappingProfile));
            //services.AddAutoMapper.AddProfile<MappingProfile>();
            //services.AddAutoMapper(typeof(MappingProfile).Assembly);


            //------  version 15   -------------------
            //services.AddAutoMapper(config =>
            //{
            //    config.AddMaps(typeof(MappingProfile).Assembly);
            //});
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }, typeof(MappingProfile).Assembly);


            //services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));

            return services;
        }
    }
}
