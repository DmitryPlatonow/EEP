using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EEP.Entities
{
    public class Employee
    {
        [Key]
        [ForeignKey("User")]
        public Guid Id { get; set; }

        [Required]
        public User User { get; set; }

        public virtual ICollection<ProjectParticipationHistory> ParticipationHistoryInProject { get; set; }

        public double Employment { get; set; }



    }
}
