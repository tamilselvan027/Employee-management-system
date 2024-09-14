using Employee_Management_System.Models;
using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class AdminController : Controller
    {
        // GET Details
        [HttpGet]
        public ActionResult GetAllDetails()
        {
            AdminRepositary adminrepositary = new AdminRepositary();
            ModelState.Clear();
            return View(adminrepositary.SelectDataDetails());
        }

        //delete record
        public ActionResult DeleteDetails(int id)
        {
            try
            {
                AdminRepositary adminrepositary = new AdminRepositary();
                if (adminrepositary.DeletedataDetails(id))
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
                return RedirectToAction("GetAllDetails");
            }
        }

        //Department details

        public ActionResult GetDepartments()
        {
            DepartmentRepositary departmentrepositary = new DepartmentRepositary();
            ModelState.Clear();
            return View(departmentrepositary.SelectDataDetails());
        }

        // GET: /EditDetails/5
        [HttpGet]
        public ActionResult EditDetails(int id)
        {
            try
            {
                DepartmentRepositary departmentrepositary = new DepartmentRepositary();
                return View(departmentrepositary.SelectDataDetails().Find(registor => registor.DepartmentID == id));
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + error.Message;
                //return View();
            }
            return View();
        }

        // POST: /EditDetails/5
        [HttpPost]
        public ActionResult EditDetails(int id, Departments departments)
        {
            try
            {
                AdminRepositary adminrepositary = new AdminRepositary();

                adminrepositary.EditDepartmentDetails(departments);
                return RedirectToAction("GetDepartments");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + error.Message;
                //return View();
            }
            return View();
        }
    }
}
