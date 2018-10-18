using EEP.Entities.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EEP.Entities
{
    public class User  : IdentityUser
    {
        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        [Required]
        public EmployeeRoleInProject EmployeeRoleInProject { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

    }
}
