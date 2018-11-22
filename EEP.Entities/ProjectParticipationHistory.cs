using EEP.Entities.Enums;
using EEP.Entities.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EEP.Entities
{
    public class ProjectParticipationHistory
    {

        public User User { get; set; }

        [Key, ForeignKey("Project")]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        [Required]
        public Project Project { get; set; }

        [Required]
        public TypeOfParticipationInProject Schedule { get; set; }

        [Required]
        public bool ScheduleIsDayOfWeek { get; set; }
        
        public int Employment { get; set; }

        public List<DaysOfWeek> DaysOfWeek { get; set; }

        [Required]
        public EmployeeRoleInProject EmployeeRoleInProject { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [JsonConverter(typeof(DateFormatConverter), "YYYY-MM-DD")]
        public DateTime StartDateParticipation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime EndDateParticipation { get; set; }

        [Column(TypeName = "date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? RealEndDateParticipation { get; set; }
    }
}
