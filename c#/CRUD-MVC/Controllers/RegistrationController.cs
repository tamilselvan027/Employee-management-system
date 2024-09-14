using CRUD_MVC.Models;
using CRUD_MVC.Repositary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC.Controllers
{
    public class RegistrationController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllDetails()
        {
            RegistrationRepositary registor = new RegistrationRepositary();
            ModelState.Clear();
            return View(registor.SelectDataDetails());
        }

        // GET: Registration
        [HttpGet]
        public ActionResult AddRegistrationDetails()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRegistrationDetails(Registration registration)
        {
            RegistrationRepositary registor = new RegistrationRepositary();
            try
            {
                if (ModelState.IsValid)
                {
                    //RegistrationRepositary conn = new RegistrationRepositary();
                    if (registor.AddDataDetails(registration))
                    {
                        ViewBag.Message = "User details added successfully";
                        //return View(registration);
                        return RedirectToAction("GetAllDetails");
                    }
                }
            }
            catch { }
                return View();
        }

        // GET: /EditDetails/5
        [HttpGet]
        public ActionResult EditDetails(int id)
        {
            RegistrationRepositary registor = new RegistrationRepositary();

            return View(registor.SelectDataDetails().Find(reg => reg.id == id));
        }

        // POST: /EditDetails/5
        [HttpPost]
        public ActionResult EditDetails(int id, Registration registration)
        {
            try
            {
                RegistrationRepositary registor = new RegistrationRepositary();

                registor.EditdataDetails(registration);
                return RedirectToAction("GetAllDetails");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + ex.Message;
                //return View();
            }
            return View();
        }

        //delete record
        public ActionResult DeleteDetails(int id)
        {
            try
            {
                RegistrationRepositary registor = new RegistrationRepositary();
                if(registor.DeletedataDetails(id))
                {
                    ViewBag.AlertMsg = "Deleted details successfully";
                }
                return RedirectToAction("GetAllDetails");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred: " + ex.Message;
                //return View();
            }
            return View();
        }


    }
}
