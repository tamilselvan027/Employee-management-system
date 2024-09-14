using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Repositary
{
    public class AdminLeaveRepositary
    {

        public SqlConnection connect;
        public void Connection()
        {
            String constr = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
            connect = new SqlConnection(constr);
        }

        //Select employee details
        public List<Leave> SelectLeaveDetails()
        {
            Connection();
            List<Leave> reglist = new List<Leave>();
            SqlCommand command = new SqlCommand("SPS_GetLeaveDetails", connect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connect.Open();
            adapter.Fill(dt);
            connect.Close();

            foreach (DataRow dr in dt.Rows)
                reglist.Add(
                    new Leave
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                        LeaveType = Convert.ToString(dr["LeaveType"]),
                        StartDate = Convert.ToDateTime(dr["StartDate"]),
                        EndDate = Convert.ToDateTime(dr["EndDate"]),
                        LeaveCount = Convert.ToInt32(dr["LeaveCount"]),
                        Reason = Convert.ToString(dr["Reason"]),
                        LeaveStatus = Convert.ToString(dr["LeaveStatus"])
                    });
            return reglist;
        }

        //Edit employee details
        public bool EditLeaveDetails(Leave update)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_UpdateLeaveDetails", connect);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", update.Id);
            command.Parameters.AddWithValue("@EmployeeId", update.EmployeeId);
            command.Parameters.AddWithValue("@LeaveType", update.LeaveType);
            command.Parameters.AddWithValue("@StartDate", update.StartDate);
            command.Parameters.AddWithValue("@EndDate", update.EndDate);
            command.Parameters.AddWithValue("@LeaveCount", update.LeaveCount);
            command.Parameters.AddWithValue("@Reason", update.Reason);
            command.Parameters.AddWithValue("@LeaveStatus", update.LeaveStatus);
            command.Parameters.AddWithValue("@Remarks", update.Remarks);

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