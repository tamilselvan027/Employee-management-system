using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_System.Controllers
{
    public class DepartmentsController : Controller
    {
        public ActionResult GetDepartments()
        {
            DepartmentRepositary departmentrepositary = new DepartmentRepositary();
            ModelState.Clear();
            return View(departmentrepositary.SelectDataDetails());
        }


    }
}
