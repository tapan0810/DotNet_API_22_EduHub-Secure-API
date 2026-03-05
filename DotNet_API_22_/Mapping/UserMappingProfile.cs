using AutoMapper;
using DotNet_API_22_.Entities.Dtos.UserDtos;
using DotNet_API_22_.Entities.Models;

namespace DotNet_API_22_.Mapping
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
