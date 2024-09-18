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
    public class DepartmentRepositary
    {
        public SqlConnection connect;

        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }

        public List<Departments> SelectDataDetails()
        {
            Connection();
            List<Departments> reglist = new List<Departments>();
            SqlCommand comment = new SqlCommand("SPS_GetDepartmentEmployeeCount", connect);
            comment.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(comment);
            DataTable dt = new DataTable();
            connect.Open();
            adapter.Fill(dt);
            connect.Close();

            foreach (DataRow dr in dt.Rows)
                reglist.Add(
                    new Departments
                    {
                        DepartmentID = Convert.ToInt32(dr["DepartmentID"]),
                        DepartmentName = Convert.ToString(dr["DepartmentName"]),
                        DepartmentHead = Convert.ToString(dr["DepartmentHead"]),
                        EmployeeCount = Convert.ToInt32(dr["Count_of_employees"])
                    });
            return reglist;
        }

        // Edit for add department
        public bool AddDepartments(Departments departments)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_AddDepartment", connect);
            command.CommandType = CommandType.StoredProcedure;
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

        // Edit for department -- in admin side
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

        public bool DeleteDepartment(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPD_DeleteDepartment", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DepartmentID", id);

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