using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer.CategoryDto;
using EntityLayer.CustomerDto;
using EntityLayer.OrderDto;
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

            CreateMap<OrderDto, Order>()
                .ForMember(des => des.OrderProduct, opt => opt.MapFrom(src => src.OrderedProducts))
                .ForMember(des => des.Payment, opt => opt.MapFrom(src => src.cardDetails))
                .ForMember(des => des.ShippingAddress, opt => opt.MapFrom(src => src.ReceiverAddress))
                .ForMember(des => des.CustomerId, opt => opt.MapFrom(src => src.BillingDetails.CustomerId))
                .ReverseMap();
            //CreateMap<OrderDto, Order>().ForMember(des => des.Payment, opt => opt.MapFrom(src => src.cardDetails)).ReverseMap();

            CreateMap<OrderProductDto, OrderProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<PaymentDto, Payment>()
                .ForMember(c => c.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(c => c.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(c => c.Cvn, opt => opt.MapFrom(src => src.CvnNumber))
                .ForMember(c => c.ExpirationDate, opt => opt.MapFrom(src => src.ExpDate));
        }
    }
}
