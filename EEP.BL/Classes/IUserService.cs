using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public interface IUserService : IDisposable
    {
        Task<User> CreateUser(User userDto);
        Task<ClaimsIdentity> ValidateUser(User userDto);
      //  Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
