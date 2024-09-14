using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Employee_Management_System.Repositary
{
    public class LoginRepositary
    {
        public SqlConnection connect;

        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }

        public string Verification(Login login)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPS_Verification", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", login.Username);
            command.Parameters.AddWithValue("@password", login.Password);
            connect.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (!dataReader.HasRows)
            {
                connect.Close();
                throw new Exception("No matching records found for the provided credentials.");
            }
            dataReader.Read();
            login.Username = dataReader["UserName"].ToString();
            login.UserType = dataReader["UserType"].ToString();
            login.EmployeeID = (int)dataReader["EmployeeID"];
            login.DepartmentName = dataReader["DepartmentName"].ToString();
            connect.Close();
            return ((login.UserType == "admin") ? "admin" : "user");

        }

        
    }
}