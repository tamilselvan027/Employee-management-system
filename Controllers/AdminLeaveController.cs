﻿using Employee_Management_System.Models;
using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class AdminLeaveController : Controller
    {
        //// GET Leave Details
        [HttpGet]
        public ActionResult GetLeaveDetails()
        {
            AdminLeaveRepositary adminleaverepositary = new AdminLeaveRepositary();
            ModelState.Clear();
            return View(adminleaverepositary.SelectLeaveDetails());
        }

        // GET: /EditDetails/5
        [HttpGet]
        public ActionResult EditDetails(int id)
        {
            AdminLeaveRepositary adminleaverepositary = new AdminLeaveRepositary();
            return View(adminleaverepositary.SelectLeaveDetails().Find(leaveregistor => leaveregistor.Id == id));
        }

        // POST: /EditDetails/5
        [HttpPost]
        public ActionResult EditDetails(int id, Leave registration)
        {
            try
            {
                AdminLeaveRepositary adminleaverepositary = new AdminLeaveRepositary();

                adminleaverepositary.EditLeaveDetails(registration);
                return RedirectToAction("GetLeaveDetails");
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
