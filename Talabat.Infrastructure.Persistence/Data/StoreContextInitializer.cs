using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Persitstence;

namespace Talabat.Infrastructure.Persistence.Data
{
    internal class StoreContextInitializer(StoreContext dbContext) : IStoreContextInitializer
    {
        public async Task InitializeAsync()
        {
            var pinndingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

            if (pinndingMigrations.Any())
                dbContext.Database.MigrateAsync();

        }

        public async Task SeedAsync()
        {
            if (!dbContext.Brands.Any())
            {
                var brandsData = await File.ReadAllTextAsync("../Talabat.Infrastructure.Persistence/Data/Seeds/brands.json");
                //var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData).Select(b=> new ProductBrand 
                //{
                //    Name = b.Name,
                //    CreatedBy = b.CreatedBy,
                //    CreatedOn = b.CreatedOn,
                //    LastModifiedBy = b.LastModifiedBy,
                //    LastModifiedOn = b.LastModifiedOn
                //});

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands?.Count > 0)
                {
                    //await dbContext.Brands.AddRangeAsync(brands);
                    await dbContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync("../Talabat.Infrastructure.Persistence/Data/Seeds/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if (categories?.Count > 0)
                {
                    await dbContext.Set<ProductCategory>().AddRangeAsync(categories);
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../Talabat.Infrastructure.Persistence/Data/Seeds/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products?.Count > 0)
                {
                    await dbContext.Set<Product>().AddRangeAsync(products);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
