using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using QuanLyPhongMach2.DTO;

namespace QuanLyPhongMach2.DAO
{
    class HoaDon
    {
        //Lay ra hoa don thuoc cua mot phieu kham
        public static ChiTietHoaDon LayHoaDon(int MaPK)
        {
            ChiTietHoaDon dh = new ChiTietHoaDon();
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "select TenBN, NgayKham, TienKham, TienThuoc from BenhNhan bn join PhieuKham pk on bn.MaBN = pk.MaBN join HoaDonThuoc hd on hd.MaPK = pk.MaPK where hd.MaPK = " + MaPK;
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    dh = new ChiTietHoaDon(dr["TenBN"].ToString(), (DateTime)dr["NgayKham"], (int)dr["TienKham"], (int)dr["TienThuoc"]);
                }
                dl.DongKetNoi();
            }
            return dh;
        }
        //Cap nhat hoa don
        public static void CapNhapHoaDon(int MaPK, int TienThuoc, int TienKham)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update HoaDonThuoc set TienThuoc = " + TienThuoc + ", TienKham = " + TienKham + "where MaPK = " + MaPK;
                dl.CapNhatDuLieu(sqlString);
            }
        }

    }
}
