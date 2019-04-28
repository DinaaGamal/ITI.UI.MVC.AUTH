using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.AuthLab.Models.Entities
{
    [Table("Department")] //adelo esm f l db
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Empolyee> Empolyees { get; set; }
    }
}