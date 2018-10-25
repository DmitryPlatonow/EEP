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
        private readonly UnitOfWork _unitOfWork;
        
        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        public async Task<User> GetByIdAsync(Guid id)
        {

            var user =  _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                return new OperationResult(false, result.Errors.FirstOrDefault(), "");

                return new OperationResult(true, "Registration successfully complited", "");
            }
            else
            {
                return new OperationResult(false, "This user is already exists", "UserName");
            }

            User user = _unitOfWork.UserRepository.
        }




    }
}
