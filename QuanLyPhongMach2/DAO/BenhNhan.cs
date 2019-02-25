using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using QuanLyPhongMach2.DTO;

namespace QuanLyPhongMach2.DAO
{
    class BenhNhan
    {
        //Xóa Bệnh nhân
        public static void XoaBN(int ID)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Delete from BenhNhan where MaBN = " + ID;
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Chỉnh sửa thông tin Bệnh nhân
        public static void SuaTTBenhNhan(int MaBN, string TenBN, int GioiTinh, DateTime NgaySinh, string DiaChi)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update BenhNhan set TenBN = N'" + TenBN + "',GioiTinh = " + GioiTinh + ",NgaySinh = '" + NgaySinh.ToString() + "',DiaChi = N'" + DiaChi + "' where MaBN = " + MaBN;
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Thêm một Bệnh nhân
        public static void ThemBenhNhan(string TenBN, int GioiTinh, DateTime NgaySinh, string DiaChi)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Insert BenhNhan(TenBN,GioiTinh,NgaySinh,DiaChi) values (N'" + TenBN + "'," + GioiTinh + ",'" + NgaySinh.ToString() + "',N'" + DiaChi + "')";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Kiểm tra một bệnh nhânn (Dựa vào họ tên và ngày sinh) đã có trong ds chưa, nếu có thì lấy ra maBN đó
        public static bool KTBenhNhan(string hoTen, DateTime ngaySinh, out int maBN)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Select MaBN, TenBN, NgaySinh from BenhNhan";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                while (dr.Read())
                {
                    if (dr["TenBN"].ToString() == hoTen && ((DateTime)dr["NgaySinh"]).ToShortDateString() == ngaySinh.ToShortDateString())
                    {
                        maBN = (int)dr["MaBN"];
                        return false; //Có bệnh nhân
                    }
                }
                dl.DongKetNoi();
            }
            maBN = 0;
            return true; //Không có bệnh nhân
        }

        //Lấy ds các Bệnh nhân có trong bảng Bệnh nhân dựa trên Ngày khám bệnh
        public static List<ChiTietBenhNhan> LayDSBenhNhan(string NgayKham)
        {
            DuLieu dl = new DuLieu();
            List<ChiTietBenhNhan> benhNhan = new List<ChiTietBenhNhan>();
            if (dl.MoKetNoi())
            {
                string sqlString = "Select bn.MaBN, TenBN, NgaySinh,GioiTinh,DiaChi from BenhNhan bn join PhieuKham pk on bn.MaBN = pk.MaBN where NgayKham = '" + NgayKham + "'";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    benhNhan.Add(new ChiTietBenhNhan((int)dr["MaBN"], stt, dr["TenBN"].ToString(), (bool)dr["GioiTinh"], (DateTime)dr["NgaySinh"], dr["DiaChi"].ToString()));
                }
                dl.DongKetNoi();
            }
            return benhNhan;
        }
    }
}
