﻿using AutoMapper;
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