using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Domain.Contracts.Persitstence;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(optionsBuilder =>
            {
                optionsBuilder
                 .UseLazyLoadingProxies()
                 .UseSqlServer(configuration.GetConnectionString("StoreContext"));
            }
            );


            services.AddScoped<IStoreContextInitializer, StoreContextInitializer>();
            //services.AddScoped(typeof(IStoreContextInitializer), typeof(StoreContextInitializer));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
