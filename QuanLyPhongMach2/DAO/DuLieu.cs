using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongMach2.DAO
{
    public class DuLieu
    {
        SqlConnection conn;

        public static string constring = "Data Source=" + Environment.MachineName + ";Initial Catalog=QLPM;Integrated Security=True";

        public bool MoKetNoi()
        {
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool MoKetNoi(string conString)
        {
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void DongKetNoi()
        {
            conn.Close();
        }



        public DuLieu()
        {
        }
        public SqlConnection Connect()
        {
            try
            {
                conn = new SqlConnection(constring);
                return conn;
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối với cơ sở dữ liệu ");
                throw;
            }
        }

        public void OpenConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể kết nối với cơ sở dữ liệu ");
            }
        }
        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể kết nối với cơ sở dữ liệu ");
            }
        }

        public static void SetConn(string connStr)
        {
            if (connStr != string.Empty)
                constring = connStr;
        }

        //Lấy dữ liệu câu truy vấn sqlString
        public SqlDataReader LayDuLieu(string sqlString)
        {
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        //Cập nhật (thêm, xóa, sửa) dữ liệu theo câu truy vấn sqlString
        public int CapNhatDuLieu(string sqlString)
        {
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            cmd.CommandType = CommandType.Text;
            int ret = cmd.ExecuteNonQuery();
            return ret;
        }
    }
}
