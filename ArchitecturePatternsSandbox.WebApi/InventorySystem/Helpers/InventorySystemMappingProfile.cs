using AutoMapper;
using InventorySystem.Data.Entities;
using InventorySystem.DTOs;

namespace InventorySystem.Helpers
{
    public class InventorySystemMappingProfile : Profile
    {
        public InventorySystemMappingProfile()
        {
            CreateMap<OrderDto, SaleItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap();

            CreateMap<OrderProductDto, Product>()
                .ForMember(dest => dest.RowVersion, opt => opt.ConvertUsing<Base64ToByteArrayConverter, string>(src => src.RowVersion))
                .ReverseMap()
                .ForPath(dest => dest.RowVersion, opt => opt.MapFrom(src => new ByteArrayToBase64Converter().Convert(src.RowVersion, null)));

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.MinStock, opt => opt.MapFrom(src => src.MinStock))
                .ForMember(dest => dest.RowVersion, opt => opt.ConvertUsing<Base64ToByteArrayConverter, string>(src => src.RowVersion))
                .ReverseMap()
                .ForPath(dest => dest.RowVersion, opt => opt.MapFrom(src => new ByteArrayToBase64Converter().Convert(src.RowVersion, null)));
        }
    }
}
