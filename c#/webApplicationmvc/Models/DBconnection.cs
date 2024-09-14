using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webApplicationmvc.Models
{
    public class DBconnection
    {
        public List<Employee> DBconnect() 
        { 
            List<Employee> employee = new List<Employee>();
            String connectstr = ConfigurationManager.ConnectionStrings["connect"].ToString ();
            SqlConnection conn = new SqlConnection(connectstr);
            conn.Open ();

            string query = "use sample;";
            String query1 = " select employeeId, firstName, lastName, department, departId from Employee ";

            SqlCommand cmd = new SqlCommand (query, conn);
            SqlCommand cmd2 = new SqlCommand (query1, conn);

            SqlDataReader reader = cmd2.ExecuteReader ();

            while (reader.Read())
            {
                employee.Add(new Employee()
                {
                    Id = (int)reader["employeeId"],
                    FirstName = reader["firstName"].ToString(),
                    LastName = reader["lastName"].ToString(),
                    Department = reader["department"].ToString(),
                    DepartmentId = ( int )reader["departId"]
                });
            }
            return employee;
        }
    }
}