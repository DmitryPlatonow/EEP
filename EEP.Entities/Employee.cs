
using EEP.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EEP.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public User User { get; set; }

        [Required]
        public EmployeeRoleInProject EmployeeRoleInProject { get; set; }

        public virtual ICollection<ProjectParticipationHistory> ParticipationHistoryInProject { get; set; }

    }
}
