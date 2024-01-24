using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<CategoryItem,CategoryItemDto>().ReverseMap(); 
        CreateMap<CategoryProduct,CategoryProductDto>().ReverseMap(); 
        CreateMap<City,CityDto>().ReverseMap(); 
        CreateMap<Client,ClientDto>().ReverseMap(); 
        CreateMap<Company,CompanyDto>().ReverseMap(); 
        CreateMap<Country,CountryDto>().ReverseMap(); 
        CreateMap<Deparment,DeparmentDto>().ReverseMap(); 
        CreateMap<Event,EventDto>().ReverseMap(); 
        CreateMap<Invoice,InvoiceDto>().ReverseMap(); 
        CreateMap<Item,ItemDto>().ReverseMap(); 
        CreateMap<Notification,NotificationDto>().ReverseMap(); 
        CreateMap<Order,OrderDto>().ReverseMap(); 
        CreateMap<PaymentMethod,PaymentMethodDto>().ReverseMap(); 
        CreateMap<Product,ProductDto>().ReverseMap(); 
        CreateMap<ProductItem,ProductItemDto>().ReverseMap(); 
        CreateMap<SalesInvoice,SalesInvoiceDto>().ReverseMap(); 
        CreateMap<Supplier,SupplierDto>().ReverseMap(); 
        CreateMap<TypeSupplier,TypeSupplierDto>().ReverseMap(); 
    }
}