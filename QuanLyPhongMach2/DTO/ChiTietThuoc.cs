using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongMach2.DTO
{
    class ChiTietThuoc
    {
        #region(Các thuộc tính và phương thức khởi tạo)
        public ChiTietThuoc(int MaThuoc, int STT, string TenThuoc, string DonVi, int DonGia)
        {
            maThuoc = MaThuoc;
            tenThuoc = TenThuoc;
            donVi = DonVi;
            donGia = DonGia;
        }
        int maThuoc;

        public int MaThuoc
        {
            get { return maThuoc; }
            set { maThuoc = value; }
        }
        //public int sTT;
        string tenThuoc;

        public string TenThuoc
        {
            get { return tenThuoc; }
            set { tenThuoc = value; }
        }
        string donVi;

        public string DonVi
        {
            get { return donVi; }
            set { donVi = value; }
        }
        int donGia;

        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        #endregion
    }
}
