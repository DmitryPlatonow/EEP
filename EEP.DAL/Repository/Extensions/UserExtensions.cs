using EEP.Entities;
using System;
using System.Linq;


namespace EEP.DAL.Repository.Extensions
{
    public static class UserExtensions
    {
        public static  User GetSingleByEmail(this GenericRepository<User> userRepository, string email)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Email == email);
        }
    }
}
