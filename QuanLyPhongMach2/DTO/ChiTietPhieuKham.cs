using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongMach2.DTO
{
    class ChiTietPhieuKham
    {
        #region(Các thuộc tính và phương thức khởi tạo)
        public ChiTietPhieuKham(int STT, string HoTen, DateTime NgayKham, string LoaiBenh, string TrieuChung)
        {
            sTT = STT;
            hoTen = HoTen;
            ngayKham = NgayKham;
            loaiBenh = LoaiBenh;
            trieuChung = TrieuChung;
        }
        int sTT;

        public int STT
        {
            get { return sTT; }
            set { sTT = value; }
        }
        string hoTen;

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        DateTime ngayKham;

        public DateTime NgayKham
        {
            get { return ngayKham; }
            set { ngayKham = value; }
        }
        string loaiBenh;

        public string LoaiBenh
        {
            get { return loaiBenh; }
            set { loaiBenh = value; }
        }
        string trieuChung;

        public string TrieuChung
        {
            get { return trieuChung; }
            set { trieuChung = value; }
        }
        #endregion
    }
}
