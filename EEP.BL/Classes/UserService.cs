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
        
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                return null;               
            }
            return user;           
        }




    }
}
