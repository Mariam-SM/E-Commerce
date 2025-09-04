using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Abstraction.Models.Products
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; } // Foreign Key to ProductCategory Entity
        public string Category { get; set; } = null!;
        public int? BrandId { get; set; } // Foreign Key to ProductBrand Entity
        public string Brand { get; set; } = null!;
    }

}
