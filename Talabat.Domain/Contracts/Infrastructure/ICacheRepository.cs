using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Domain.Contracts.Infrastructure
{
    public interface ICacheRepository
    {
        public Task<string?> GetTask(string key);
        public Task SetAsync(string key, object value, TimeSpan duration);
    }
}
