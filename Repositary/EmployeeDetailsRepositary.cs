using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Employee_Management_System.Repositary
{
    public class EmployeeDetailsRepositary
    {

        public SqlConnection connect;

        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }

        //Select employee details
        public List<EmployeeDetails> SelectDataDetails()
        {
            Connection();
            List<EmployeeDetails> reglist = new List<EmployeeDetails>();
            SqlCommand command = new SqlCommand("SPS_GetEmployeeDetails", connect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connect.Open();
            adapter.Fill(dt);
            connect.Close();

            foreach (DataRow dr in dt.Rows)
                reglist.Add(
                    new EmployeeDetails
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

        //Edit employee details
        public bool EditdataDetails(EmployeeDetails update)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_UpdateDetails", connect);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EmployeeID", update.EmployeeID);
            command.Parameters.AddWithValue("@FirstName", update.FirstName);
            command.Parameters.AddWithValue("@LastName", update.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", update.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", update.Gender);
            command.Parameters.AddWithValue("@City", update.City);
            command.Parameters.AddWithValue("@State", update.State);
            command.Parameters.AddWithValue("@Email", update.Email);
            command.Parameters.AddWithValue("@PhoneNumber", update.PhoneNumber);
            command.Parameters.AddWithValue("@HireDate", update.HireDate);
            command.Parameters.AddWithValue("@DepartmentName", update.DepartmentName);
            command.Parameters.AddWithValue("@EmployeeType", update.EmployeeType);
            command.Parameters.AddWithValue("@UserName", update.UserName);

            connect.Open();
            int i = command.ExecuteNonQuery();
            connect.Close();
            if (i >= 1)
            {
                return true;
            }
            else { return false; }
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
    }
}