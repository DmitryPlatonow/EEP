using AutoMapper;
using EEP.API.Models;
using EEP.Entities;
using EEP.Entities.Dto;

namespace EEP.API.Mappers
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>();
            CreateMap<LoginViewModel, User>();
            CreateMap<RegisterViewModel, UserDto>();
        }

        public override string ProfileName
        {
            get
            {
                return "UserProfile";
            }
        }
    }
}