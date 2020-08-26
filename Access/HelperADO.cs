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
   public class HelperADO
    {

        string connectionString = ConfigurationManager.ConnectionStrings["CallLog"].ToString();
        SqlConnection con;
        int count;
        string _value;

    

        public decimal Convert_Decimal(string val)
        {
            Decimal returnval;
            count = val.Length;
            _value = "";
            for (int i = 0; i < val.Length; i++)
            {
                if (val.Substring(i, 1) != ",")
                {
                    if (val.Substring(i, 1) != ".")
                        _value += Convert.ToString(Char.GetNumericValue(Convert.ToChar(val.Substring(i, 1))));
                    else
                        _value += val.Substring(i, 1);
                }

            }

            returnval = Convert.ToDecimal(_value);
            return returnval;
        }
        public int MAXNo(string TableName, string ColumnName)
        {
            int i;
            string query = "SELECT ISNULL(MAX(" + ColumnName + "),0)+1 FROM " + TableName + "";
            con = new SqlConnection(connectionString);

            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Connection.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return i;

            }
        }

        public DataTable GET_Data(string query)
        {
            try
            {
                con = new SqlConnection(connectionString);
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Exec_Query(string query)
        {
            try
            {
                con = new SqlConnection(connectionString);
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public String GET_Scalar(string query)
        {
            try
            {
                con = new SqlConnection(connectionString);
                string returnvalue;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                returnvalue = Convert.ToString(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return returnvalue;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DateTime GET_Date(string query)
        {
            try
            {
                con = new SqlConnection(connectionString);
                DateTime returnvalue;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                returnvalue = Convert.ToDateTime(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return returnvalue;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DateTime.Now;
            }
        }
        public int GET_Int(string query)
        {
            try
            {
                con = new SqlConnection(connectionString);
                int returnvalue;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return returnvalue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }

        public void DEL_Data(string query)
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                //int i = cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
