using Talabat.Domain.Contracts.Persitstence.DbInitializer;

namespace Talabat.APIs.Extensions
{
    public static class InitializerExtensions
    {
        public static async Task<WebApplication> InitializerStoreContextAsync(this WebApplication app)
        {

            using var scope = app.Services.CreateAsyncScope();  // Dispose itself
            var services = scope.ServiceProvider;
            var storeContextInitializer = services.GetRequiredService<IStoreDbContextInitializer>();
            var storeIdentityContextInitializer = services.GetRequiredService<IStoreIdentityDbInitializer>();
            // Ask Runtime Env for an object of type "StoreContext" Service => Explicitly

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await storeContextInitializer.InitializeAsync();
                await storeContextInitializer.SeedAsync();

                await storeIdentityContextInitializer.InitializeAsync();
                await storeIdentityContextInitializer.SeedAsync();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during applying migrations and data seeding");
            }
            return app;
        }
    }
}
