using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Infrastructure.BasketDB_Repository;

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
            return services;
        }
    }
}
