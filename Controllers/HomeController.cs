using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Management_System.Models;
using Employee_Management_System.Repositary;

namespace Employee_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact form)
        {
            ContactRepositary ContactRepositary = new ContactRepositary();
            try
            {
                if (ContactRepositary.AddContactDetails(form))
                {
                    ViewBag.Message = "User details added successfully";
                    //return RedirectToAction("Index");
                    return View();
                }

            }
            catch { }
            return View();
        }
    }
}