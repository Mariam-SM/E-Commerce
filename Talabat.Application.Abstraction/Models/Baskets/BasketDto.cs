using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Abstraction.Models.Baskets
{
    public record BasketDto
    {
        public required string Id { get; set; }
        public IEnumerable<BasketItemDto> Items { get; set; } = null!;
    }
}
