using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Education2
{
    public class DataSQL
    {
          string connstr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;

        

        //DataSet 获取数据
        public DataSet GetRows(string sql)
        {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }

        public string Getcounts(string sql)
        {

            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            string a = Convert.ToString(com.ExecuteScalar());
            con.Close();
            return a;
        }

        public int GetcountsInt(string sql)
        {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            int b = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            return b;
        }


        public SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection con = new SqlConnection(connstr);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader myReader = com.ExecuteReader(CommandBehavior.CloseConnection);
                con.Close();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }


    }
}