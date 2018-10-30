using EEP.DAL.Interfaces;
using AutoMapper;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EEP.Entities.Dto;
using EEP.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using EEP.DAL.UnitOfWork;
using EEP.DAL.Repository.Extensions;

namespace EEP.BL.Classes
{
    public class UserService : IUserService
                                    
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager _userManager;
        
        public UserService(IUnitOfWork unitOfWork, UserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var user = await _userManager.() .FindByIdAsync(id);

            if (user == null)
            {
                return null;               
            }
            return user;           
        }

        public async Task<User> Ge(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return null;
            }
            return user;
        }


    }
}
