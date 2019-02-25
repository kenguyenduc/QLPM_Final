using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using QuanLyPhongMach2.DTO;

namespace QuanLyPhongMach2.DAO
{
    public class NguoiDung
    {
        //Thêm người dùng mới
        public static void ThemNguoiDung(string TenND, DateTime NgaySinh, int GioiTinh, string DiaChi, string SDT, string TenDangNhap, string MatKhau, string ChucVu)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "insert NguoiDung(TenND,NgaySinh,GioiTinh ,DiaChi ,SDT ,TenDangNhap,MatKhau,ChucVu) values(N'" + TenND + "','" + NgaySinh.ToString() + "'," + GioiTinh + ",N'" + DiaChi + "','" + SDT + "','" + TenDangNhap + "','" + MatKhau + "',N'" + ChucVu + "')";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Xóa người dùng
        public static void XoaNguoiDung(string TenDangNhap)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Delete from NguoiDung where TenDangNhap = '" + TenDangNhap + "'";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Cập nhật thông tin người dùng
        public static void CapNhatThongTin(string TenDangNhap, string TenND, DateTime NgaySinh, int GioiTinh, string DiaChi, string SDT)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update NguoiDung set TenND = N'" + TenND + "', NgaySinh = '" + NgaySinh.ToString() + "',GioiTinh = " + GioiTinh + ", DiaChi = N'" + DiaChi + "', SDT = '" + SDT + "' where TenDangNhap = '" + TenDangNhap + "'";
                dl.CapNhatDuLieu(sqlString);
             }
        }
        //Lấy thông tin người dùng dựa vào tenDN
        public static ChiTietNguoiDung LayThongTin(string TenDangNhap)
        {
            ChiTietNguoiDung nd = new ChiTietNguoiDung();
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Select TenND, NgaySinh, GioiTinh, DiaChi, SDT, TenDangNhap, ChucVu from NguoiDung where TenDangNhap = '" + TenDangNhap + "'";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    nd = new ChiTietNguoiDung(0, dr["TenDangNhap"].ToString(), dr["ChucVu"].ToString(), dr["TenND"].ToString(), (DateTime)dr["NgaySinh"], (bool)dr["GioiTinh"], dr["DiaChi"].ToString(), dr["SDT"].ToString());
                }
                dl.DongKetNoi();
            }
            return nd;
        }

        public static List<ChiTietNguoiDung> DSNguoiDungTheoTen(string TenDN)
        {
            List<ChiTietNguoiDung> nd = new List<ChiTietNguoiDung>();
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "select TenND as 'Họ tên' from NguoiDung where TenDangNhap = N'" + TenDN + "'";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                while (dr.Read())
                {
                    nd.Add(new ChiTietNguoiDung(int.Parse(dr["STT"].ToString()), dr["TenDangNhap"].ToString(), dr["ChucVu"].ToString(), dr["TenND"].ToString(), (DateTime)dr["NgaySinh"], (bool)dr["GioiTinh"], dr["DiaChi"].ToString(), dr["SDT"].ToString()));
                }
                dl.DongKetNoi();
            }
            return nd;
        }
        //Lấy dữ liệu của người dùng
        public static List<ChiTietNguoiDung> LayDSNguoiDung()
        {
            List<ChiTietNguoiDung> nd = new List<ChiTietNguoiDung>();
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Select row_number() over(order by TenND) as STT, TenND,ChucVu, NgaySinh, GioiTinh, DiaChi, SDT, TenDangNhap from NguoiDung";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                while (dr.Read())
                {
                    nd.Add(new ChiTietNguoiDung(int.Parse(dr["STT"].ToString()), dr["TenDangNhap"].ToString(), dr["ChucVu"].ToString(), dr["TenND"].ToString(), (DateTime)dr["NgaySinh"], (bool)dr["GioiTinh"], dr["DiaChi"].ToString(), dr["SDT"].ToString()));
                }
                dl.DongKetNoi();
            }
            return nd;
        }
        //Đổi mật khẩu mới cho người dùng
        public static int DoiMatKhau(string TenDangNhap, string MatKhauMoi, string MatKhauCu)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update NguoiDung set MatKhau = '" + MatKhauMoi + "' where TenDangNhap = '" + TenDangNhap + "' and MatKhau = '" + MatKhauCu + "'";
                return dl.CapNhatDuLieu(sqlString);
            }
            return 0;
        }

        public static DataTable GetDataTable(SqlConnection connection, string sql)
        {
            DuLieu dl = new DuLieu();
            try
            {
                SqlDataAdapter DataA = new SqlDataAdapter(sql, connection);
                dl.OpenConnection(connection);
                DataTable DataT = new DataTable();
                DataA.Fill(DataT);
                return DataT;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dl.CloseConnection(connection);
            }
        }
    }
}
