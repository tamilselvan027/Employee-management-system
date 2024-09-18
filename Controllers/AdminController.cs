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
        //This for employee details page action link
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


        // there only department action link and linked with departmants repo 
        //Department details
        public ActionResult GetDepartments()
        {
            DepartmentRepositary departmentrepositary = new DepartmentRepositary();
            ModelState.Clear();
            return View(departmentrepositary.SelectDataDetails());
        }

        // GET: Add new departmaent
        [HttpGet]
        public ActionResult AddDepartments()
        {
            return View();
        }

        // POST: Registration
        [HttpPost]
        public ActionResult AddDepartments(Departments departments)
        {
            DepartmentRepositary departmentrepositary = new DepartmentRepositary();
            try
            {
                if (departmentrepositary.AddDepartments(departments))
                {
                    ViewBag.Message = "Department details added successfully";
                    return RedirectToAction("GetDepartments", "Admin");
                }
                throw new Exception("Please change the username");
            }
            catch (Exception error)
            {
            }
            return View();
        }


        // GET: /Edit for department 
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
                DepartmentRepositary departmentrepositary = new DepartmentRepositary();
                departmentrepositary.EditDepartmentDetails(departments);
                return RedirectToAction("GetDepartments");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + error.Message;
                //return View();
            }
            return View();
        }
        public ActionResult DeleteDepartment(int id)
        {
            try
            {
                DepartmentRepositary departmentrepositary = new DepartmentRepositary();
                if (departmentrepositary.DeleteDepartment(id))
                {
                    return RedirectToAction("GetDepartments");
                }
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + error.Message;
            }
            return View();
        }
    }
}
