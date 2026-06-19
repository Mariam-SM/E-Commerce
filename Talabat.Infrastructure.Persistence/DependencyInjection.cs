using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Domain.Contracts.Persitstence;
using Talabat.Domain.Contracts.Persitstence.DbInitializer;
using Talabat.Domain.Identity;
using Talabat.Infrastructure.Persistence._Common;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Identity;

namespace Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region Store Database

            services.AddDbContext<StoreDbContext>(optionsBuilder =>
               {
                   optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("StoreContext"))
                    .ConfigureWarnings(warnings =>
                   warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
               }
               );

            #endregion

            #region Identity Databse

            services.AddDbContext<StoreIdentityDbContext>(optionsBuilder =>
            {
                optionsBuilder
                 .UseLazyLoadingProxies()
                 .UseSqlServer(configuration.GetConnectionString("IdentityContext"))
                 .ConfigureWarnings(warnings =>
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
            }
           );

            #endregion

            services.AddScoped<IStoreDbContextInitializer, StoreDbContextInitializer>();
            services.AddScoped<IStoreIdentityDbInitializer, StoreIdentityDbInitializer>();

            // Identity services are registered in the host (Program.cs) where AddIdentity extension
            // methods are available via the web SDK. Do not register AddIdentity here to avoid
            // extension method resolution issues in class library projects.
            //services.AddScoped(typeof(IStoreContextInitializer), typeof(StoreContextInitializer));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
