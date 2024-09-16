using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Repositary
{
    public class AdminRepositary
    {
        public SqlConnection connect;

        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }
        public List<Admin> SelectDataDetails()
        {
            Connection();
            List<Admin> reglist = new List<Admin>();
            SqlCommand command = new SqlCommand("SPS_GetEmployeeDetails", connect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connect.Open();
            adapter.Fill(dt);
            connect.Close();

            foreach (DataRow dr in dt.Rows)
                reglist.Add(
                    new Admin
                    {
                        EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        Email = Convert.ToString(dr["Email"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        HireDate = Convert.ToDateTime(dr["HireDate"]),
                        DepartmentName = Convert.ToString(dr["DepartmentName"]),
                        EmployeeType = Convert.ToString(dr["EmployeeType"]),
                        UserName = Convert.ToString(dr["username"]),
                        Password = Convert.ToString(dr["password"])
                    });
            return reglist;
        }

        public bool DeletedataDetails(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPD_DeleteData", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", id);

            connect.Open();
            int i = command.ExecuteNonQuery();
            connect.Close();
            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }


        // Edit for Departments
        public bool EditDepartmentDetails(Departments departments)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_UpdateDepartmentDetails", connect);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DepartmentID", departments.DepartmentID);
            command.Parameters.AddWithValue("@DepartmentName", departments.DepartmentName);
            command.Parameters.AddWithValue("@DepartmentHead", departments.DepartmentHead);
            

            connect.Open();
            int i = command.ExecuteNonQuery();
            connect.Close();
            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }
    }
}