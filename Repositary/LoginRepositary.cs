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

            //SqlCommand command = new SqlCommand("SPS_LoginVerification", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", login.Username);

            //var Text = DecodeFrom64(login.Password);

            command.Parameters.AddWithValue("@password", login.Password);
            connect.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (!dataReader.HasRows)
            {
                connect.Close();
                throw new Exception("No matching records found for the provided credentials.");
            }
            dataReader.Read();

            //String encrypt = dataReader["password"].ToString();
            //string decryptpassword = DecodeFrom64(encrypt);

            //if (login.Password != decryptpassword)
            //{
            //    connect.Close();
            //    throw new Exception("Invalid password.");
            //}

            login.Username = dataReader["UserName"].ToString();
            login.UserType = dataReader["UserType"].ToString();
            login.EmployeeID = (int)dataReader["EmployeeID"];
            login.DepartmentName = dataReader["DepartmentName"].ToString();
            connect.Close();
            return ((login.UserType == "admin") ? "admin" : "user");

        }

        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }


    }
}