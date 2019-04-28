using ITI.UI.MVC.AuthLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.AuthLab.ViewModels
{
    public class EmployeeViewModel
    {
        public Empolyee Empolyee { get; set; }
        public List<Empolyee> Employees { get; set; }
        public List<Department> Departments { get; set; }
    }

}