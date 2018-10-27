using EEP.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EEP.Entities
{
    public class ParticipationHistoryInProject
    {
        [Key, ForeignKey("Employee")]
        [Column("EmployeeId", Order = 0)]
        public int EmployeeIdId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Key, ForeignKey("Project")]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        [Required]
        public Project Project { get; set; }

        [Required]
        public TypeOfParticipationInProject Schedule { get; set; }

        [Required]
        public bool ScheduleIsDayOfWeek { get; set; }

        [Required]
        public int Employment { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime? RealEndDate { get; set; }
    }
}
