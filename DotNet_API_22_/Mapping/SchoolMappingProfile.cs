using AutoMapper;
using DotNet_API_22_.Entities.Dtos.SchoolDtos;
using DotNet_API_22_.Entities.Models;

namespace DotNet_API_22_.Mapping
{
    public class SchoolMappingProfile:Profile
    {
        public SchoolMappingProfile()
        {
            CreateMap<CreateSchoolDto, School>();

            CreateMap<School, GetAllSchoolDto>();

            CreateMap<School, GetSchoolById>();

            CreateMap<UpdateSchoolDto,School>();
        }
    }
}
