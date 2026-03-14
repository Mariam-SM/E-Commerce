using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Persitstence.DbInitializer;
using Talabat.Domain.Identity;
using Talabat.Infrastructure.Persistence.Identity;

namespace Talabat.Infrastructure.Persistence._Common
{
    public class StoreIdentityDbInitializer(StoreIdentityDbContext _dbContext, UserManager<ApplicationUser> _userManager) : DbInitializer(_dbContext), IStoreIdentityDbInitializer
    {
        public override async Task SeedAsync()
        {
            var user = new ApplicationUser
            { 
                DisplayName = "Mariam Sayed",
                UserName = "mariam.sayed",
                Email = "mariam.sayed.dev@gmail.com",
                PhoneNumber = "01234567890"
            };

            await _userManager.CreateAsync(user, "P@sWorrd");
            //await _dbContext.SaveChangesAsync();
        }
    }
}
