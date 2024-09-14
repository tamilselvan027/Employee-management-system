using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webApplicationmvc.Models;

namespace webApplicationmvc.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            Demo demo = new Demo();
            demo.test();
            return View();
        }
    }
}