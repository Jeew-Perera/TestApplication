﻿using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer.CategoryDto;
using EntityLayer.CustomerDto;
using EntityLayer.ProductDto;

namespace DataAccessLayer.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerForLoginDto>();
            CreateMap<Customer, CustomerProfileDto>();
            CreateMap<CustomerForRegisterDto, Customer>()
            .ForMember(c => c.Password, option => option.Ignore());

            CreateMap<Product, ProductListViewDto>();
            CreateMap<Product, ProductDetailViewDto>();

            CreateMap<Category, CategoryDisplayDto>();

        }
    }
}
