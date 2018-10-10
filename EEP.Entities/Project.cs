using EEP.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EEP.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [MaxLength(75), MinLength(2)]
        public string Name { get; set; }

        [MaxLength(-1)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public ProjectStatus ProjectStatus { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
