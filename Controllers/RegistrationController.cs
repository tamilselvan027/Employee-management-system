using Employee_Management_System.Models;
using Employee_Management_System.Repositary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                    //return View();
                }
                throw new Exception("Please change the username");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = " This username already exist " + error.Message;
            }
            return View();

            
        }

        // Drop town for state
        public ActionResult State()
        {
            string filePath = Server.MapPath("~/Content/JSON/state.json");
            string jsonData = System.IO.File.ReadAllText(filePath);
            return Content(jsonData, "application/json");
        }


        public SqlConnection connect;
        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }

        public ActionResult GetUserByUsername(string username)
        {
            try
            {
                string Isusername = null;
                SqlCommand cmd = new SqlCommand("select * from Employees_Details where UserName = @username", connect);
                cmd.Parameters.AddWithValue("@username", username);
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Isusername = (string)reader["UserName"];
                }
                return Content(Isusername);

            }
            catch (Exception ex) { }
            connect.Close();
            return null;
        }

        public ActionResult GetUserByEmail(string email)
        {
            try
            {
                string Isusername = null;
                SqlCommand cmd = new SqlCommand("select * from Employees_Details where Email = @Email", connect);
                cmd.Parameters.AddWithValue("@Email", email);
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Isusername = (string)reader["Email"];
                }
                return Content(Isusername);

            }
            catch (Exception ex) { }
            connect.Close();
            return null;
        }
    }
}
