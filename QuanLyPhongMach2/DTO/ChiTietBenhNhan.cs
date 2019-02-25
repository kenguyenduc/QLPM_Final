using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongMach2.DTO
{
    class ChiTietBenhNhan
    {
        #region(Các thuộc tính và phương thức khởi tạo)
        public ChiTietBenhNhan(int MaBN, int STT, string TenBN, bool GioiTinh, DateTime NgaySinh, string DiaChi)
        {
            maBN = MaBN;
            sTT = STT;
            tenBN = TenBN;
            gioiTinh = GioiTinh;
            ngaySinh = NgaySinh;
            diaChi = DiaChi;
        }
        int sTT;

        public int STT
        {
            get { return sTT; }
            set { sTT = value; }
        }
        int maBN;

        public int MaBN
        {
            get { return maBN; }
            set { maBN = value; }
        }
        string tenBN;

        public string TenBN
        {
            get { return tenBN; }
            set { tenBN = value; }
        }
        bool gioiTinh;

        public bool GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        DateTime ngaySinh;

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        #endregion
    }
}
