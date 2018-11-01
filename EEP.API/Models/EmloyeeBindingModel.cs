using EEP.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EEP.API.Models
{
    public class EmloyeeBindingModel
    {

        [Required]
        public User User { get; set; }

        public ICollection<ProjectParticipationHistory> ParticipationHistoryInProject { get; set; }
    }
}