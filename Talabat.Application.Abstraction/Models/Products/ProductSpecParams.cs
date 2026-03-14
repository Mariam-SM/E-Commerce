using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Abstraction.Models.Products
{
    public class ProductSpecParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; } = 1;

        private int pageSize =10;

        private int maxPageSize = 100;
        public int PageSize
        {
            get => pageSize;
            set { pageSize = value > maxPageSize ? maxPageSize : value; }
        }

        private string? search;
        public string? Search
        {
            get => search;
            set { search = value!.ToUpper(); }
        }
    }
}
