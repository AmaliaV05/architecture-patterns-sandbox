using AutoMapper;
using StatusCheckSystem.Data.Entities;
using StatusCheckSystem.DTOs;

namespace StatusCheckSystem.Helpers
{
    public class StatusCheckSystemMappingProfile : Profile
    {
        public StatusCheckSystemMappingProfile()
        {
            CreateMap<VerificationLog, VerificationDto>().ReverseMap();
        }
    }
}
