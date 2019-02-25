using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using QuanLyPhongMach2.DTO;

namespace QuanLyPhongMach2.DAO
{
    class PhieuKham
    {
        //LẤy ds bệnh nhân khám bệnh trong 1 ngày
        public static List<ChiTietPhieuKham> DSKhamBenh(string hoten)
        {
            DuLieu dl = new DuLieu();
            List<ChiTietPhieuKham> pk = new List<ChiTietPhieuKham>();
            if (dl.MoKetNoi())
            {
                string sqlString = "select TenBN as 'Họ tên', NgayKham as 'Ngày Khám', LoaiBenh as 'Loại bệnh', TrieuChung as 'Triệu chứng' from BenhNhan bn join PhieuKham pk on bn.MaBN = pk.MaBN where bn.TenBN = N'" + hoten + "'";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                int STT = 0;
                while (dr.Read())
                {
                    STT++;
                    pk.Add(new ChiTietPhieuKham(STT, dr["Họ tên"].ToString(), (DateTime)dr["Ngày Khám"], dr["Loại bệnh"].ToString(), dr["Triệu chứng"].ToString()));
                }
                dl.DongKetNoi();
            }
            return pk;
        }

        //Tìm theo tên bênh nhân
        //public static List<ChiTietPhieuKham> DSKhamBenhTheoTen(string tenBN)
        //{
        //    DuLieu dl = new DuLieu();
        //    List<ChiTietPhieuKham> pk = new List<ChiTietPhieuKham>();
        //    if (dl.MoKetNoi())
        //    {
        //        string sqlString = "select TenBN as 'Họ tên', NgayKham as 'Ngày Khám', LoaiBenh as 'Loại bệnh', TrieuChung as 'Triệu chứng' from BenhNhan bn join PhieuKham pk on bn.MaBN = pk.MaBN where TenBN like N'%" + tenBN + "%'";
        //        SqlDataReader dr = dl.LayDuLieu(sqlString);
        //        int STT = 0;
        //        while (dr.Read())
        //        {
        //            STT++;
        //            pk.Add(new ChiTietPhieuKham(STT, dr["Họ tên"].ToString(), (DateTime)dr["Ngày Khám"], dr["Loại bệnh"].ToString(), dr["Triệu chứng"].ToString()));
        //        }
        //        dl.DongKetNoi();
        //    }
        //    return pk;
        //}

        //Lấy ra Triệu chứng  và Loại bệnh của 1 Phiếu khám khi biết Mã phiếu khám

        public static void LayDuLieu(int MaPK, out string LoaiBenh, out string TrieuChung)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "select LoaiBenh, TrieuChung from PhieuKham where MaPK = " + MaPK;
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    LoaiBenh = dr["LoaiBenh"].ToString();
                    TrieuChung = dr["TrieuChung"].ToString();
                    return;
                }
            }
            LoaiBenh = "";
            TrieuChung = "";
        }
        //Tạo Phiếu khám gồm Ngày sinh và Mã bệnh nhân
        public static void TaoPhieuKham(string ngayKham, int MaBN)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "insert PhieuKham(NgayKham,MaBN) values('" + ngayKham + "'," + MaBN + ")";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Tìm 1 Phiếu khám dựa trên Ngày khám và Mã bệnh nhân
        public static int TimPhieuKham(string NgayKham, int MaBN)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {

                string sqlString = "select MaPK from PhieuKham where NgayKham = '" + NgayKham + "' and MaBN = " + MaBN;
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    return (int)dr[0];
                }
            }
            return 0;
        }
        //Tìm một bệnh nhân có Phiếu khám bệnh
        public static bool TimBenhNhan(int ID)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {

                string sqlString = "select MaPK from PhieuKham where MaBN = " + ID;
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    return true;//Tìm thấy
                }
            }
            return false;//Không tìm thấy
        }
        //Xóa Phiếu khám bệnh
        public static void XoaPhieuKham(int ID)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Delete from PhieuKham where MaPK = " + ID;
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Cập nhật Phiếu khám
        public static void CapNhapPhieuKham(int ID, string TrieuChung, string LoaiBenh)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update PhieuKham set TrieuChung = N'" + TrieuChung + "', LoaiBenh = N'" + LoaiBenh + "' where MaPK = " + ID;
                dl.CapNhatDuLieu(sqlString);
            }
        }
    }
}
