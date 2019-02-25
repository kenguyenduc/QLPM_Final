using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach2.DTO
{
    class ChiTietBaoCaoThuoc
    {
        #region(Các trường, thuộc tính và phương thức khởi tạo)
        public ChiTietBaoCaoThuoc(int STT, string TenThuoc, string DonVi, int TongSoLuong, int SoLanDung)
        {
            sTT = STT;
            tenThuoc = TenThuoc;
            donVi = DonVi;
            tongSoLuong = TongSoLuong;
            soLanDung = SoLanDung;
        }
        int sTT;

        public int STT
        {
            get { return sTT; }
            set { sTT = value; }
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
        int tongSoLuong;

        public int TongSoLuong
        {
            get { return tongSoLuong; }
            set { tongSoLuong = value; }
        }
        int soLanDung;

        public int SoLanDung
        {
            get { return soLanDung; }
            set { soLanDung = value; }
        }
        #endregion
    }
}
