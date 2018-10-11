using EEP.Entities;
using System.Security.Principal;

namespace EEP.BL.WorkClasses
{
    public class UserContext
    {
        public IPrincipal Principal { get; set; }
        public User User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
