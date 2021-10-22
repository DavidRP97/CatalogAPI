using AutoMapper;
using CatalogAPI_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.DTOs.Mappings
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<Product, ProductCategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Categories, CategoryDTO>().ReverseMap();
        }
    }
}
