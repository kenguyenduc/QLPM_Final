using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongMach2.DTO
{
    public class ChiTietNguoiDung
    {
        #region(Các thuộc tính và phương thức khởi tạo)
        public ChiTietNguoiDung()
        { }
        public ChiTietNguoiDung(int STT, string TenDangNhap, string ChucVu, string TenND, DateTime NgaySinh, bool GioiTinh, string DiaChi, string SDT)
        {
            sTT = STT;
            tenND = TenND;
            chucVu = ChucVu;
            ngaySinh = NgaySinh;
            gioiTinh = GioiTinh;
            diaChi = DiaChi;
            sDT = SDT;
            tenDangNhap = TenDangNhap;
        }

        int sTT;
        public int STT
        {
            get { return sTT; }
            set { sTT = value; }
        }

        string tenDangNhap;
        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        string chucVu;
        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }

        string tenND;

        public string TenND
        {
            get { return tenND; }
            set { tenND = value; }
        }

        DateTime ngaySinh;
        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        bool gioiTinh;
        public bool GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        string sDT;
        public string SDT
        {
            get { return sDT; }
            set { sDT = value; }
        }
        #endregion
    }
}
