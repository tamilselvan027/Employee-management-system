using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class Login
    {
        [Display(Name = "Username")]
        [Required]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string UserType { get; set; }
        public int EmployeeID { get; set; }
        public string DepartmentName { get; set; }
    }
}