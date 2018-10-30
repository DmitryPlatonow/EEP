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
            CreateMap<RegisterBindingModel, User>();
            CreateMap<LoginBindingModel, User>();
            CreateMap<RegisterBindingModel, UserDto>();
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