using AutoMapper;
using EEP.API.Models;
using EEP.Entities;

namespace EEP.API.Mappers
{
    internal class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<User, RegisterBindingModel>();
            CreateMap<User, LoginBindingModel>();
            CreateMap<Project, ProjectBindingModel>();
        }


        public override string ProfileName
        {
            get
            {
                return "PostProfile";
            }
        }

    }
}