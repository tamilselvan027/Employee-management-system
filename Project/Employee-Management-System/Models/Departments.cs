using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class Departments
    {
        public int DepartmentID { get; set; }

        [Display(Name ="Department name")]
        public string DepartmentName { get; set; }

        [Display(Name ="Department head")]
        public string DepartmentHead { get; set; }

        [Display(Name ="Count of Employees")]
        public int EmployeeCount { get; set; }
    }
}