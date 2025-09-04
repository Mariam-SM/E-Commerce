using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Abstraction.Models.Products;
using Talabat.Domain.Entities.Products;

namespace Talabat.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                 .ForMember(d => d.Brand, m => m.MapFrom(src => src.ProductBrand!.Name))
                 .ForMember(d => d.Category, m => m.MapFrom(src => src.ProductCategory!.Name))
                 .ForMember(d => d.PictureUrl, m => m.MapFrom<PictureUrlResolver>());


            CreateMap<ProductBrand, BrandDto>();

            CreateMap<ProductCategory, CategoryDto>();
        }
    }
}
