using AutoMapper;
using SearchTool.Features.SearchProducts;
using SearchTool.Infrastructure.Data.Entities;

namespace AdminTool.Infrastructure.Helpers
{
    public class SearchToolMappingProfile : Profile
    {
        public SearchToolMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
