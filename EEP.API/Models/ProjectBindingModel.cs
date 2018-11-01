using EEP.Entities;
using EEP.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EEP.API.Models
{
    public class ProjectBindingModel
    {
        [MaxLength(75), MinLength(2)]
        public string ProjectName { get; set; }

        [MaxLength(-1)]
        public string Description { get; set; }

        [Required]
        [DataType("datetime2")]
        public DateTime StartProjectDate { get; set; }

        [Required]
        [DataType("datetime2")]
        public DateTime EndProjectDate { get; set; }

        [Required]
        public ProjectStatus ProjectState { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
