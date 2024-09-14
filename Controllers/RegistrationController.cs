using Employee_Management_System.Models;
using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult AddRegistrationPage()
        {
            return View();
        }

        // POST: Registration
        [HttpPost]
        public ActionResult AddRegistrationPage(Registration registration)
            {
            RegistrationRepositary registor = new RegistrationRepositary();
            try
            {   
               if (registor.AddRegistrationDetail(registration))
               { 
                    ViewBag.Message = "User details added successfully";
                    return RedirectToAction("LoginPage", "Login");
               }
                throw new Exception("Please change the username");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = " This username already exist " + error.Message;
            }
            return View();
        }
    }
}
