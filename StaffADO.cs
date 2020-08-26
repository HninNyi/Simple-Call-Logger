using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogAccess
{
  public  class StaffADO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CallLog"].ToString();
        SqlConnection con;

        public string StaffName { get;  set; }
        public string Position { get;  set; }
        public string Status { get;  set; }
        public int staffid { get;  set; }

        public void INS_Staff()
        {
            try
            {

                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INS_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffName", StaffName);
                cmd.Parameters.AddWithValue("@Position", Position);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                staffid = Convert.ToInt32(cmd.Parameters["@id"].Value);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UPD_Staff()
        {
            try
            {

                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPD_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", staffid);
                cmd.Parameters.AddWithValue("@StaffName", StaffName);
                cmd.Parameters.AddWithValue("@Position", Position);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
