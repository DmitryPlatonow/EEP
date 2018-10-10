using EEP.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EEP.Entities
{
    public class Employee
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        public User User { get; set; }

        public Schedule Schedule { get; set; }

        public bool ScheduleIsDayOfWeek { get; set; }

        public int Employment { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

    }
}
