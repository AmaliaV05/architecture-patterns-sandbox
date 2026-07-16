using AdminTool.Features.Common;
using AdminTool.Infrastructure.Data.Entities;
using AutoMapper;

namespace AdminTool.Infrastructure.Helpers
{
    public class AdminToolMappingProfile : Profile
    {
        public AdminToolMappingProfile()
        {
            CreateMap<Setting, SettingDto>().ReverseMap();
        }
    }
}
