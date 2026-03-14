using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Entities.Products;

namespace Talabat.Domain.Contracts.Specifications
{
    public class ProductForCountSpec : BaseSpecifications<Product, int>
        
    {
        public ProductForCountSpec(int? brandId , int? categoryId , string? search)
            : base (P=>
                        (string.IsNullOrEmpty(search) || P.Name.Contains(search!))
                        &&
                        (!brandId.HasValue || P.BrandId == brandId.Value )
                        &&
                        (!categoryId.HasValue || P.CategoryId == categoryId.Value)
                   )
        {
        }
    }
}
