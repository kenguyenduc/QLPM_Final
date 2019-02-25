using QuanLyPhongMach2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyPhongMach2.DAO
{
    class Thuoc
    {
        //Tìm một loại thuốc dựa vào tên và đơn giá
        public static int TimThuoc(string TenThuoc, int DonGia)
        {
            DuLieu dl = new DuLieu();
            int MaThuoc = 0;
            if (dl.MoKetNoi())
            {
                string sqlString = "Select MaThuoc from Thuoc where TenThuoc = N'" + TenThuoc + "' and DonGia = " + DonGia;
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    MaThuoc = (int)dr[0];
                }
                dl.DongKetNoi();
            }
            return MaThuoc;
        }

        //Cập nhật dữ liệu cho một loại thuốc
        public static void CapNhatThuoc(int MaThuoc, string TenThuoc, string DonVi, int DonGia)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update Thuoc set TenThuoc = N'" + TenThuoc + "', DonVi = N'" + DonVi + "', DonGia = " + DonGia + " where MaThuoc = " + MaThuoc;
                dl.CapNhatDuLieu(sqlString);
            }
        }

        //Xóa một loại thuốc
        public static void XoaThuoc(int MaThuoc)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "delete from Thuoc where MaThuoc = " + MaThuoc;
                dl.CapNhatDuLieu(sqlString);
            }
        }

        //Thêm một loại thuốc mới
        public static void ThemThuoc(string TenThuoc, string DonVi, int DonGia)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "insert Thuoc(TenThuoc, DonVi, DonGia) values (N'" + TenThuoc + "',N'" + DonVi + "'," + DonGia + ")";
                dl.CapNhatDuLieu(sqlString);
            }
        }

        //Lấy đơn vị của một loại thuốc
        public static string LayDonViThuoc(int MaThuoc)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Select DonVi from Thuoc where MaThuoc = " + MaThuoc;
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    return dr[0].ToString();
                }
                dl.DongKetNoi();
            }
            return null;
        }

        //Lấy tất cả dữ liệu của bảng thuốc
        public static List<ChiTietThuoc> LayThuoc()
        {
            SqlConnection conn;
            conn = new SqlConnection(DuLieu.constring);
            List<ChiTietThuoc> bc = new List<ChiTietThuoc>();
            SqlCommand cmd = new SqlCommand("LayThuoc", conn);
            //Lấy dữ liệu từ StoreProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    bc.Add(new ChiTietThuoc(int.Parse(dr["MaThuoc"].ToString()), int.Parse(dr["STT"].ToString()), dr["TenThuoc"].ToString(), dr["DonVi"].ToString(), int.Parse(dr["DonGia"].ToString())));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return bc;
        }

        public static int DemThuoc()
        {
            SqlConnection conn;
            conn = new SqlConnection(DuLieu.constring);
            SqlCommand cmd = new SqlCommand("DemThuoc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            int ret = (int)cmd.ExecuteScalar();
            return ret;
        }
    }
}
