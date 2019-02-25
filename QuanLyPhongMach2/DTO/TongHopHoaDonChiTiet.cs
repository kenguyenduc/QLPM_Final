using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach2.DTO
{
    class TongHopHoaDonChiTiet
    {
        #region(Các thuộc tính và phương thức khởi tạo)

        string tenBN;
        DateTime ngayKham;
        string trieuChung;
        string loaiBenh;
        int tienKham;
        int tienThuoc;

        //string tenThuoc;
        //string donVi;
        //int soLuong;
        //string cachDung;


        public TongHopHoaDonChiTiet()
        { }
        public TongHopHoaDonChiTiet(string TenBN, DateTime NgayKham, string TrieuChung, string LoaiBenh, int TienKham, int TienThuoc)
        {
            tenBN = TenBN;
            ngayKham = NgayKham;
            trieuChung = TrieuChung;
            loaiBenh = LoaiBenh;
            tienKham = TienKham;
            tienThuoc = TienThuoc;
            //tenThuoc = TenThuoc;
            //donVi = DonVi;
            //soLuong = SoLuong;
            //cachDung = CachDung;

        }

        public string TenBN
        {
            get { return tenBN; }
            set { tenBN = value; }
        }

        public DateTime NgayKham
        {
            get { return ngayKham; }
            set { ngayKham = value; }
        }

        public int TienKham
        {
            get { return tienKham; }
            set { tienKham = value; }
        }

        public int TienThuoc
        {
            get { return tienThuoc; }
            set { tienThuoc = value; }
        }

        public string LoaiBenh
        {
            get { return loaiBenh; }
            set { loaiBenh = value; }
        }

        public string TrieuChung
        {
            get { return trieuChung; }
            set { trieuChung = value; }
        }

        //public string TenThuoc
        //{
        //    get { return tenThuoc; }
        //    set { tenThuoc = value; }
        //}
        //public string DonVi
        //{
        //    get { return donVi; }
        //    set { donVi = value; }
        //}
        //public int SoLuong
        //{
        //    get { return soLuong; }
        //    set { soLuong = value; }
        //}
        //public string CachDung
        //{
        //    get { return cachDung; }
        //    set { cachDung = value; }
        //}
        #endregion
    }
}
