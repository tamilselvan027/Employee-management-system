using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Repositary
{
    public class AdminApprovedStatusRepositary
    {
        public SqlConnection connect;
        public void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }

        public List<Admin> GetNewUser()
        {
            Connection();
            List<Admin> reglist = new List<Admin>();
            SqlCommand command = new SqlCommand("SPS_GetNewUser", connect);
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
                        AdminStatus = Convert.ToString(dr["AdminStatus"])
                    });
            return reglist;
        }

        //Update status approved
        public bool AdminApproved(int Id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_ApprovedNewUser", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", Id);

            connect.Open();
            int i = command.ExecuteNonQuery();
            connect.Close();
            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public bool AdminRejected(int Id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_RejectedNewUser", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeID", Id);

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