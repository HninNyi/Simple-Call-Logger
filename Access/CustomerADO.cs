using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access
{
   public  class CustomerADO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CallLog"].ToString();
        SqlConnection con;

        public string CustomerName { get;  set; }
        public string PhoneNo { get;  set; }
        public string Address { get;  set; }
        public string Status { get;  set; }
        public int customerid { get;  set; }

        public void INS_Customer()
        {
            try
            {

                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                customerid = Convert.ToInt32(cmd.Parameters["@id"].Value);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UPD_Customer()
        {
            try
            {

                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPD_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerid);
                cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                cmd.Parameters.AddWithValue("@Address", Address);
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
