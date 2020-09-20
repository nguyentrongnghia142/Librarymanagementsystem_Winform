using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Thuvien.Server
{
    class QueryData
    {
        private static String constring = @"Data Source=DESKTOP-JNT1M4V\MSSQLSERVER01;Initial Catalog=QLTV;Integrated Security=True";
        public static SqlConnection Connect_Server()
        {
            try
            {
                SqlConnection connect = new SqlConnection(QueryData.constring);
                return connect;
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối!!!", "Error", MessageBoxButtons.OK);
                return null;
            }
        }
        
        public static bool ExecuteNonQueryBook(SqlConnection connect,String query)
        {
            try
            {
                connect.Open();
                SqlDataAdapter SDA = new SqlDataAdapter(query, connect);
                SDA.SelectCommand.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (SqlException)
            {
                connect.Close();
                MessageBox.Show("Book already existed or information book invalid!");
                return false;
            }
        }
        public static bool ExecuteNonQueryUser(SqlConnection connect, String query)
        {
            try
            {
                connect.Open();
                SqlDataAdapter SDA = new SqlDataAdapter(query, connect);
                SDA.SelectCommand.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (SqlException)
            {
                connect.Close();
                MessageBox.Show("Your username already existed!");
                return false;
            }
        }

        public static DataTable Queryresult(SqlConnection connect,String query)
        {
            try
            {
                DataTable dt = new DataTable();
                connect.Open();
                SqlDataAdapter SDA = new SqlDataAdapter(query, connect);
                SDA.Fill(dt);
                connect.Close();
                return dt;
            }
            catch (SqlException)
            {
                connect.Close();
                MessageBox.Show("Connect server fail!");
                return null;
            }
        }
        public static bool procborrowed(SqlConnection connect,int idb,int amount)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("spUpdateamout", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idbook", SqlDbType.Int).Value = idb;
                cmd.Parameters.Add("@getamount", SqlDbType.Int).Value = amount;
                cmd.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(Exception)
            {
                connect.Close();
                MessageBox.Show("Out of stock");
                return false;
            }
        }
        public static bool procDuedate(SqlConnection connect)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("spUpdatestatus", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception)
            {
                connect.Close();
                MessageBox.Show("Connect fail!");
                return false;
            }
        }
    }
}
