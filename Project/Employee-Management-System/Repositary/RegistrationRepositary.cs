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
    public class RegistrationRepositary
    {
        public SqlConnection connect;

        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }
        public bool AddRegistrationDetail(Registration obj)
        {
            try
            {
                Connection();
                connect.Open();
                SqlCommand command = new SqlCommand("SPI_AddRegistrationDetails", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", obj.FirstName);
                command.Parameters.AddWithValue("@LastName", obj.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", obj.Gender);
                command.Parameters.AddWithValue("@City", obj.City);
                command.Parameters.AddWithValue("@State", obj.State);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                command.Parameters.AddWithValue("@HireDate", obj.HireDate);
                command.Parameters.AddWithValue("@DepartmentName", obj.DepartmentName);
                command.Parameters.AddWithValue("@EmployeeType", obj.EmployeeType);
                command.Parameters.AddWithValue("@Salery", obj.Salery);
                command.Parameters.AddWithValue("@UserName", obj.UserName);
                command.Parameters.AddWithValue("@password", obj.Password);
                command.Parameters.AddWithValue("@UserType", "user");
                command.Parameters.AddWithValue("@DeleteStatus", "no");

                //connect.Open();
                int i = command.ExecuteNonQuery();
                //connect.Close();
                if (i >= 1)
                {
                    return true;
                }
                else { return false; }

            }
            catch
            {
                return false;
            }
               
        }

    }
}