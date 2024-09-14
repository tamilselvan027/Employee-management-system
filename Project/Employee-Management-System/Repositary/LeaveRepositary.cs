using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Employee_Management_System.Models;
using System.Net.Http.Headers;

namespace Employee_Management_System.Repositary
{
    public class LeaveRepositary
    {
        public SqlConnection connect;

        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect =new SqlConnection(constr);
        }
        public Leave GetLeaveDetails(int id)
        {
            try
            {
                connection();
                SqlCommand command = new SqlCommand("SPS_GetLeaveCount", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connect.Open();
                adapter.Fill(dt);
                connect.Close();

                DataRow dr = dt.Rows[0];

                return new Leave()
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    SickLeaveCount = Convert.ToInt32(dr["SickLeaveCount"]),
                    CasualLeaveCount = Convert.ToInt32(dr["CasualLeaveCount"]),
                    VacationLeaveCount = Convert.ToInt32(dr["VacationLeaveCount"]),
                    OptionalLeaveCount = Convert.ToInt32(dr["OptionalLeaveCount"])

                };
            }
            catch (Exception error)
            {
                return null ;
            }
        }

        public List<Leave> GetLeaveHistory(int id)
        {
            try
            {
                connection();
                List<Leave> leavehistorylist = new List<Leave>();
                SqlCommand command = new SqlCommand("SPS_GetLeaveHistory", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeId", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connect.Open();
                adapter.Fill(dt);
                connect.Close();

                foreach (DataRow dr in dt.Rows)
                    leavehistorylist.Add(
                        new Leave
                        {
                            EmployeeId = id,
                            LeaveType = Convert.ToString(dr["LeaveType"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            EndDate = Convert.ToDateTime(dr["EndDate"]),
                            LeaveCount = Convert.ToInt32(dr["LeaveCount"]),
                            LeaveStatus = Convert.ToString(dr["LeaveStatus"]),
                            Remarks = Convert.ToString(dr["Remarks"])
                        });

                return leavehistorylist;
            }
            catch (Exception error)
            {

                return null;
            }
            
        }



        public bool AddLeaveDetails(Leave leave, int id)
        {
            connection();
            SqlCommand command = new SqlCommand("SPI_AddLeaveDetails", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeId", id);
            command.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
            command.Parameters.AddWithValue("@StartDate", leave.StartDate);
            command.Parameters.AddWithValue("@EndDate", leave.EndDate);
            command.Parameters.AddWithValue("@LeaveCount", leave.LeaveCount);
            command.Parameters.AddWithValue("@Reason", leave.Reason);
            command.Parameters.AddWithValue("@LeaveStatus", "Pending");

            connect.Open();
            int i = command.ExecuteNonQuery();
            connect.Close();

            if (i >= 1)
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