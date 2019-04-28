using ITI.UI.MVC.AuthLab.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.AuthLab.Models.Entities
{
    [Table("Empolyee")]
    public class Empolyee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]

        [Display(Name="Name")]
        public string Name { get; set; }
        [Range(20, 70)]
        public int Age { get; set; }
        [EmailAddress]

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        [ForeignKey("Department")]
        public int FK_DepartmentId { get; set; }
    }
}