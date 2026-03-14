using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Persitstence.DbInitializer;

namespace Talabat.Infrastructure.Persistence._Common
{
    public abstract class DbInitializer(DbContext _dbContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            var pinndingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

            if (pinndingMigrations.Any())
                await _dbContext.Database.MigrateAsync();
        }

        public abstract Task SeedAsync();
    }
}
