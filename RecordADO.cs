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
 public   class RecordADO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CallLog"].ToString();
        SqlConnection con;

        public int CustomerID { get;  set; }
        public string StartTime { get;  set; }
        public int StaffID { get;  set; }
        public decimal Duration { get;  set; }
        public string EndTime { get;  set; }
        public string Status { get;  set; }
        public string Note { get;  set; }
        public int recordid { get;  set; }

        public void INS_Record()
        {
            try
            {

                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INS_Record", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", StaffID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@StartTime", StartTime);
                cmd.Parameters.AddWithValue("@EndTime", EndTime);
                cmd.Parameters.AddWithValue("@Duration", Duration);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                recordid = Convert.ToInt32(cmd.Parameters["@id"].Value);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UPD_Record()
        {
            try
            {

                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPD_Record", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecordID", recordid);
                cmd.Parameters.AddWithValue("@StaffID", StaffID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@StartTime", StartTime);
                cmd.Parameters.AddWithValue("@EndTime", EndTime);
                cmd.Parameters.AddWithValue("@Duration", Duration);
                cmd.Parameters.AddWithValue("@Note", Note);
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
