using Employee_Management_System.Models;
using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class LeaveController : Controller
    {

        // GET Details
        [HttpGet]
        public ActionResult GetLeaveStatus()
        {
            try
            {
                int id = (int)Session["EmployeeID"];
                ViewBag.UserName = Session["Username"]; // used viewbag(username)
                LeaveRepositary leaverepositary = new LeaveRepositary();
                ModelState.Clear();
                var leaveDetails = leaverepositary.GetLeaveDetails(id);
                var leaveHistory = leaverepositary.GetLeaveHistory(id);

                var viewModel = new LeaveView
                {
                    SingleLeave = leaveDetails, // Single Leave object
                    LeaveHistoryList = leaveHistory // List of Leave objects
                };

                return View(viewModel);

                //leaverepositary.GetLeaveDetails(id);
                //leaverepositary.GetLeaveHistory(id);
                //return View();
                //return View(leaverepositary.GetLeaveDetails(id));
            }
            catch (Exception error)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving leave status. Please try again later." + error.Message;
                return View();
            }
        }


        // GET Method
        [HttpGet]
        public ActionResult LeavePage()
        {
            return View();
        }

        // GET Method
        [HttpPost]
        public ActionResult LeavePage(Leave leave)
        {
            LeaveRepositary leaverepositary = new LeaveRepositary();
            try
            {
                int id = (int)Session["EmployeeID"]; // pass employee id to leave form

                if (leaverepositary.AddLeaveDetails(leave, id))
                {
                    TempData["AlertMessage"] = "Applied successfully";
                    return RedirectToAction("GetLeaveStatus");
                }

            }
            catch { }
            return View();
        }

        [HttpGet]
        public ActionResult LeaveHistory()
        {
            LeaveRepositary leaverepositary = new LeaveRepositary();
            try
            {
                int id = (int)Session["EmployeeID"];
                leaverepositary.GetLeaveHistory(id);
                return View();
            }
            catch
            { }
            return View();
        }
    }
}
