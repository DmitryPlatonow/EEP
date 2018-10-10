using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EEP.Entities
{
    public class HistoryParticipation
    {

        [Key, ForeignKey("Employee")]
        [Column("EmployeeId", Order = 0)]
        public int EmployeeIdId { get; set; }

        [Key, ForeignKey("Project")]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        public Employee Employee { get; set; }

        public Project Project { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RealEndDate { get; set; }
    }
}
