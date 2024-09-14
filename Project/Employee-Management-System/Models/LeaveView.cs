using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class LeaveView
    {
        public Leave SingleLeave { get; set; }
        public IEnumerable<Leave> LeaveHistoryList { get; set; }
    }
}