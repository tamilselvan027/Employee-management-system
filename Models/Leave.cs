using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class Leave
    {

        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string FullName {  get; set; }

        [Required]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Required]
        [Display(Name = "Type of leave")]
        public string LeaveType { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Leave count")]
        public int LeaveCount { get; set; }

        [Required]
        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Display(Name = "Leave status")]
        public string LeaveStatus { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        public int SickLeaveCount { get; set; }
        public int CasualLeaveCount { get; set; }
        public int VacationLeaveCount { get; set; }
        public int OptionalLeaveCount { get; set; }


        public int TotalSickLeave = 5;
        public int TotalCasualLeave = 7;
        public int TotalVacationLeave = 12;
        public int TotalOptionalLeave = 4;

    }
}