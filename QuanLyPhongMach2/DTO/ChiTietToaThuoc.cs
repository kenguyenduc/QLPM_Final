using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongMach2.DTO
{
    class ChiTietToaThuoc
    {
        #region(Các thuộc tính và phương thức khởi tạo)
        public ChiTietToaThuoc(int MaThuoc, int STT, string TenThuoc, string DonVi, int SoLuong, string CachDung)
        {
            maThuoc = MaThuoc;
            stt = STT;
            tenThuoc = TenThuoc;
            donVi = DonVi;
            soLuong = SoLuong;
            cachDung = CachDung;
        }
        int maThuoc;

        public int MaThuoc
        {
            get { return maThuoc; }
            set { maThuoc = value; }
        }
        int stt;

        public int STT
        {
            get { return stt; }
            set { stt = value; }
        }
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
        int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        string cachDung;

        public string CachDung
        {
            get { return cachDung; }
            set { cachDung = value; }
        }
        #endregion
    }
}
