using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Entities.Products;

namespace Talabat.Domain.Contracts.Specifications
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndCategorySpecifications(string? sort, int? brandId, int? categoryId) 
            : base( P =>
                    (!brandId.HasValue || P.BrandId == brandId)
                    &&
                    (!categoryId.HasValue || P.CategoryId ==categoryId)
                  )

        {
            AddIncludes();
            AddSorting(sort);

        }

        public ProductWithBrandAndCategorySpecifications(int id) : base(id)
        {
            AddIncludes();
        }
        private protected override void AddIncludes()
        {
            base.AddIncludes();
            Includes.Add(p => p.ProductBrand!);
            Includes.Add(p => p.ProductCategory!);
        }


        private protected override void AddSorting(string? sort)
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc ( p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
        
    }
}
