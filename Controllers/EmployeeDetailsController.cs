using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Management_System.Models;
using System.Web.Security;

namespace Employee_Management_System.Controllers
{
    [Authorize(Roles = "user")]
    public class EmployeeDetailsController : Controller
    {
        // GET Details
        [HttpGet]
        public ActionResult GetEmployeeProfile()
        {
            ViewBag.Id = (int)Session["EmployeeID"]; // save employee id in viewbag
            string departmentName = Session["DepartmentName"]?.ToString().ToUpper();
            ViewBag.DepartmentName = departmentName; //save department data in view bag
            string username = Session["Username"].ToString().ToUpper();
            ViewBag.UserName = username; // used viewbag(username)
            return View();
        }


        // GET: /EditDetails/5
        [HttpGet]
        public ActionResult EditDetails()
        {
            int id = (int)Session["EmployeeID"];
            EmployeeDetailsRepositary employeedetailsrepositary = new EmployeeDetailsRepositary();
            return View(employeedetailsrepositary.SelectDataDetails().Find(registor => registor.EmployeeID == id));
        }

        // POST: /EditDetails/5
        [HttpPost]
        public ActionResult EditDetails( EmployeeDetails registration)
        {
            try
            {
                EmployeeDetailsRepositary employeedetailsrepositary = new EmployeeDetailsRepositary();

                employeedetailsrepositary.EditdataDetails(registration);
                return RedirectToAction("GetEmployeeProfile");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + error.Message;
                //return View();
            }
            return View();
        }

        //delete record
        public ActionResult DeleteDetails(int id)
        {
            try
            {
                EmployeeDetailsRepositary employeedetailsrepositary = new EmployeeDetailsRepositary();
                if (employeedetailsrepositary.DeletedataDetails(id))
                {
                    TempData["AlertMessage"] = "Deleted details successfully";
                }
                else
                {
                    TempData["AlertMessage"] = "Failed to delete details. Please try again.";
                }
                return RedirectToAction("GetAllDetails");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + error.Message;
                return RedirectToAction("EditDetails");
            }
        }



    }
}
