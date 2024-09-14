using CRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace CRUD_MVC.Repositary
{
    public class RegistrationRepositary
    {
        public SqlConnection connect;

        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }

        public bool AddDataDetails(Registration obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("AddData", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@first_name", obj.FirstName);
            cmd.Parameters.AddWithValue("@last_name", obj.LastName);
            cmd.Parameters.AddWithValue("@phone", obj.Phone);
            cmd.Parameters.AddWithValue("@username", obj.UserName);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@password", obj.Password);

            connect.Open();
            int i = cmd.ExecuteNonQuery();
            connect.Close();
            if (i >= 1)
            {
                return true;
            }
            else { return false; }

        }
        public List<Registration> SelectDataDetails() { 
            Connection();
            List<Registration> reglist = new List<Registration>();
            SqlCommand cmd = new SqlCommand("SelectData", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connect.Open();
            adapter.Fill(dt);
            connect.Close();

            foreach (DataRow dr in dt.Rows)
                reglist.Add(
                    new Registration
                    {
                        id = Convert.ToInt32(dr["id"]),
                        FirstName = Convert.ToString(dr["first_name"]),
                        LastName = Convert.ToString(dr["last_name"]),
                        Phone = Convert.ToString(dr["phone"]),
                        UserName = Convert.ToString(dr["username"]),
                        Email = Convert.ToString(dr["email"]),
                        Password = Convert.ToString(dr["password"])
                    });
            return reglist;
        }

        public bool EditdataDetails( Registration obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("UpdateData", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@first_name", obj.FirstName);
            cmd.Parameters.AddWithValue("@last_name", obj.LastName);
            cmd.Parameters.AddWithValue("@phone", obj.Phone);
            cmd.Parameters.AddWithValue("@username", obj.UserName);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            //cmd.Parameters.AddWithValue("@password", obj.Password);

            connect.Open();
            int i = cmd.ExecuteNonQuery();
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
            SqlCommand cmd = new SqlCommand("DeleteData", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            connect.Open();
            int i = cmd.ExecuteNonQuery();
            connect.Close();
            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }
    }
}