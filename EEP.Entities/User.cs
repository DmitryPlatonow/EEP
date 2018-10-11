using EEP.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EEP.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string PhoneNumber { get; set; }

        [MaxLength(100), MinLength(10)]
        public string Email { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Role Role { get; set; }
    }
}
