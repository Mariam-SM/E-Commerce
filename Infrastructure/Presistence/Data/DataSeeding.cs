using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Data
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
                // apply only once
                // 
                var PendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                {
                    _dbContext.Database.MigrateAsync();
                }

                if (!_dbContext.ProductBrands.Any())
                {
                    //var productBransdData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistence\Data\DataSeedData\brands.json");
                    var productBransdData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeedData\brands.json");
                    // convert the data (string) to  C# object [ProductBrand] ...= Deserialize
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBransdData);

                    if (ProductBrands is not null && ProductBrands.Any())
                        _dbContext.ProductBrands.AddRangeAsync(ProductBrands);
                }

                if (!_dbContext.ProductTypes.Any())
                {
                    var productTypesData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeedData\types.json");
                    // Deseialize

                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypesData);

                    if (ProductTypes is not null && ProductTypes.Any())
                        _dbContext.ProductTypes.AddRangeAsync(ProductTypes);
                }


                if (!_dbContext.Products.Any())
                {
                    var productsData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeedData\products.json");
                    // Deseialize

                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsData);
                    if (products is not null && products.Any())
                        await _dbContext.Products.AddRangeAsync(products);
                }

                _dbContext.SaveChangesAsync();

                //if (_dbContext.Products.Any())
                //{
                //    var productsData = File.ReadAllText(@"..\Infrastructure\Presistence\Data\DataSeedData\products.json");
                //    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                //    if (products is not null && products.Any())
                //        _dbContext.Products.AddRange(products);
                //}
            }
            catch (Exception ex)
            {

                // TODO
                throw;
            }
        }
    }
}
