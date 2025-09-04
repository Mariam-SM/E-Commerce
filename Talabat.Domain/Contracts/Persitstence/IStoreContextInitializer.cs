using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Domain.Contracts.Persitstence
{
    public interface IStoreContextInitializer
    {
        public Task InitializeAsync();
        public Task SeedAsync();
    }
}
