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
    }
}