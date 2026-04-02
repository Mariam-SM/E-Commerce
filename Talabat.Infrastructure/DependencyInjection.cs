using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Infrastructure.BasketDB_Repository;
using Talabat.Infrastructure.Persistence.Repositories.Cache;


namespace Talabat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IConnectionMultiplexer), (serviceProvider) =>
            {
                var connectionString = config.GetConnectionString("Redis");

                var ConnectionMultiplexerObj = ConnectionMultiplexer.Connect(connectionString!);
                return ConnectionMultiplexerObj;
            });
            services.AddScoped<IBasketDBRepoistory, BasketDBRepoistory>();
            services.AddScoped<ICacheRepository,CacheRepository>();
            return services;
        }
    }
}
