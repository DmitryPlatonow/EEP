using EEP.Entities.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EEP.Entities
{
    public class User  : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
      //  public string Email { get; set; }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        //[MaxLength(50), MinLength(2)]
        //public string FirstName { get; set; }

        //[MaxLength(50), MinLength(2)]
        //public string LastName { get; set; }

        //[MaxLength(50), MinLength(2)]
        //public string PhoneNumber { get; set; }

        ////[MaxLength(100), MinLength(10)]
        ////public string Email { get; set; }

        ////[Required]
        ////public string Salt { get; set; }

        ////[Required]
        ////public string HashedPassword { get; set; }

        //[Required]
        //public EmployeeRoleInProject EmployeeRoleInProject { get; set; }

        //[Required]
        //public bool IsLocked { get; set; }

        //[Required]
        //public DateTime DateCreated { get; set; }

        //[Required]
        //public virtual Role Role { get; set; }
    }
}
