using QuanLyPhongMach2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach2.DAO
{
    class BaoCaoThuoc
    {
        //Lầy dữ liệu cho bảng báo cáo thuốc
        public static List<ChiTietBaoCaoThuoc> LayDuLieu(int thang, int nam)
        {
            SqlConnection conn;
            conn = new SqlConnection(DuLieu.constring);
            List<ChiTietBaoCaoThuoc> bc = new List<ChiTietBaoCaoThuoc>();
            SqlCommand cmd = new SqlCommand("BCSDThuoc", conn);
            //Lấy dữ liệu từ proce
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bc.Add(new ChiTietBaoCaoThuoc(int.Parse(dr["STT"].ToString()), dr["TenThuoc"].ToString(), dr["DonVi"].ToString(), (int)dr["TongSoLuong"], (int)dr["SoLanDung"]));
            }
            return bc;
        }
    }
}
