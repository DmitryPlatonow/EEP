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
        public string ProjectName { get; set; }

        [MaxLength(-1)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime StartProjectDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndProjectDate { get; set; }

        [Required]
        public ProjectStatus ProjectStatus { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
