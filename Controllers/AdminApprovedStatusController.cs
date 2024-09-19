using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminApprovedStatusController : Controller
    {
        // GET new user Details
        [HttpGet]
        public ActionResult GetNewUser()
        {
            try
            {
                AdminApprovedStatusRepositary adminapprovedstatusrepositary = new AdminApprovedStatusRepositary();
                ModelState.Clear();
                return View(adminapprovedstatusrepositary.GetNewUser());
            }
            catch { }
            return View();
        }

        // Admin approved the user 
        public ActionResult Approved(int Id)
        {
            try
            {
                AdminApprovedStatusRepositary adminapprovedstatusrepositary = new AdminApprovedStatusRepositary();
                adminapprovedstatusrepositary.AdminApproved(Id);
                return RedirectToAction("GetNewUser");
            }
            catch { }
            return View();
        }

        // Admin rejected the user 
        public ActionResult Rejected(int Id)
        {
            try
            {
                AdminApprovedStatusRepositary adminapprovedstatusrepositary = new AdminApprovedStatusRepositary();
                adminapprovedstatusrepositary.AdminRejected(Id);
                return RedirectToAction("GetNewUser");
            }
            catch {}
            return View();
        }

    }
}
