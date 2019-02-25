using QuanLyPhongMach2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongMach2.DAO
{
    public class BaoCaoDoanhThu
    {
        public static List<ChiTietBaoCaoDoanhThu> LayDuLieu(int thang, int nam)
        {
            SqlConnection conn;
            conn = new SqlConnection(DuLieu.constring);
            List<ChiTietBaoCaoDoanhThu> bc = new List<ChiTietBaoCaoDoanhThu>();
            SqlCommand cmd = new SqlCommand("BCDoanhThu", conn);
            //Lấy dữ liệu từ storedProce
            cmd.CommandType = CommandType.StoredProcedure;
            //Các parameter cua proce
            cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int stt = 0;
            try
            {
                while (dr.Read())
                {
                    stt++;
                    bc.Add(new ChiTietBaoCaoDoanhThu(stt, dr["NgayKham"].ToString(), (int)dr["SoBN"], (int)dr["DoanhThu"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return bc;

        }
    }
}
