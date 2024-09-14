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
    public class ContactRepositary
    {
        public SqlConnection connect;

        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect= new SqlConnection(constr);
        }

        public bool AddContactDetails(Contact obj)
        {
            connection();
            SqlCommand comment = new SqlCommand("SPI_AddContactDetails", connect);
            comment.CommandType = CommandType.StoredProcedure;
            comment.Parameters.AddWithValue("@Name", obj.Name);
            comment.Parameters.AddWithValue("@Email", obj.Email);
            comment.Parameters.AddWithValue("@Subject", obj.Subject);
            comment.Parameters.AddWithValue("@Message", obj.Message);

            connect.Open();
            int i = comment.ExecuteNonQuery();
            connect.Close();

            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}