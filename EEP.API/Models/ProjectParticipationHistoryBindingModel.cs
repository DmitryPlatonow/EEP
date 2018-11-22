using EEP.Entities;
using EEP.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EEP.API.Models
{
    public class ProjectParticipationHistoryBindingModel
    {

        public Guid? Id { get; set; }        

        public int? ProjectId { get; set; }

        public User User { get; set; }

        [Required]
        public TypeOfParticipationInProject Schedule { get; set; }


        public bool ScheduleIsDayOfWeek { get; set; }

        public int Employment { get; set; }

        public List<DaysOfWeek> DaysOfWeek { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDateParticipation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDateParticipation { get; set; }


    }
}