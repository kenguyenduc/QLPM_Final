using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using QuanLyPhongMach2.DTO;

namespace QuanLyPhongMach2.DAO
{
    class ToaThuoc
    {
        //Lấy ra chi tiết đơn thuốc của một Phiếu khám bệnh
        public static List<ChiTietToaThuoc> LayChiTietDonThuoc(int MaPK)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "select t.MaThuoc,TenThuoc,DonVi,SoLuong,CachDung from Thuoc t join ChiTietToaThuoc ct on t.MaThuoc = ct.MaThuoc where MaPK = " + MaPK;
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                List<ChiTietToaThuoc> cthd = new List<ChiTietToaThuoc>();
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    cthd.Add(new ChiTietToaThuoc((int)dr["MaThuoc"], stt, dr["TenThuoc"].ToString(), dr["DonVi"].ToString(), (int)dr["SoLuong"], dr["CachDung"].ToString()));
                }
                dl.DongKetNoi();
                return cthd;
            }
            return null;
        }
        //Thêm dữ liệu vào Chi tiết toa thuốc
        public static void ThemDuLieu(int MaPK, int MaThuoc, int SoLuong, string CachDung)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "insert ChiTietToaThuoc values(" + MaPK + "," + MaThuoc + "," + SoLuong + ",N'" + CachDung + "')";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Xóa Chi tiết toa thuốc
        public static void XoaDuLieu(int MaPK, int MaThuoc)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "delete from ChiTietToaThuoc where MaPK = " + MaPK + " and MaThuoc = " + MaThuoc;
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Cập nhật dữ liệu Chi tiết toa thuốc
        public static void CapNhatDL(int MaPK, int MaThuoc, int SoLuong, string CachDung)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "update ChiTietToaThuoc set SoLuong = " + SoLuong + ", CachDung = N'" + CachDung + "' where MaPK = " + MaPK + " and MaThuoc = " + MaThuoc;
                dl.CapNhatDuLieu(sqlString);
            }
        }
    }
}
