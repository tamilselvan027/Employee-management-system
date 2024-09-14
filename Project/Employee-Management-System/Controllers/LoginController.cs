using Employee_Management_System.Models;
using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult LoginPage(Login login)
        
        {
            try
            {
                LoginRepositary loginRepositary = new LoginRepositary();
                var redirct = loginRepositary.Verification(login);

                Session["EmployeeID"] = login.EmployeeID; // save employeeid in session
                Session["Username"] = login.Username; // save user name in session
                Session["DepartmentName"] = login.DepartmentName; // save user name in session

                if (redirct == "admin")
                {
                    ViewBag.AlertMsg = "Login successfully";
                    return RedirectToAction("GetAllDetails", "Admin");
                }
                else if (redirct == "user")
                {
                    ViewBag.AlertMsg = "Login successfully";
                    return RedirectToAction("GetEmployeeProfile", "EmployeeDetails");
                }
                else
                {
                    throw new Exception("No matching records found for the provided credentials.");
                }

            }
            catch {
                TempData["AlertMessage"] = "Failed to Login details. Please try again.";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
