using EEP.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EEP.Entities
{
    public class ProjectParticipationHistory
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
        [Column(TypeName = "datetime2")]
        public DateTime StartDateParticipation { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndDateParticipation { get; set; }

        [DataType("datetime2")]
        public DateTime? RealEndDateParticipation { get; set; }
    }
}
