using AutoMapper;
using EEP.API.Models;
using EEP.Entities;

namespace EEP.API.Mappers
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterBindingModel, User>();
            CreateMap<LoginBindingModel, User>();
            CreateMap<ProjectBindingModel, Project>();
            CreateMap<EmloyeeBindingModel, Employee>();
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